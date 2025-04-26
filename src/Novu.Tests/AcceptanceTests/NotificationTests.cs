using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.Clients;
using Novu.Domain.Models;
using Novu.Domain.Models.Events;
using Novu.Domain.Models.Subscribers.Preferences;
using Novu.Domain.Models.Triggers;
using Novu.Domain.Models.WorkflowGroups;
using Novu.Domain.Models.Workflows;
using Novu.Domain.Models.Workflows.Step.Message;
using Novu.QueryParams;
using Novu.Tests.Factories;
using ParkSquare.Testing.Generators;
using Polly;
using Xunit;
using Xunit.Sdk;
using Step = Novu.Domain.Models.Workflows.Step.Step;
using Subscriber = Novu.Domain.Models.Subscribers.Subscriber;
using TopicCreateData = Novu.Domain.Models.Events.TopicCreateData;

namespace Novu.Tests.AcceptanceTests;

public class NotificationTests(
    IEventClient eventClient,
    TopicFactory topicFactory,
    INotificationsClient notificationsClient,
    ISubscriberClient subscriberClient,
    WorkflowGroupFactory workflowGroupFactory,
    WorkflowFactory workflowFactory,
    IIntegrationClient integrationClient,
    IntegrationFactory integrationFactory,
    SubscriberFactory subscriberFactory)
{
    [RunnableInDebugOnly]
    public async Task E2E_InApp_Event_Test()
    {
        var (workflow, eventName) = await MakeInAppWorkflow();
        var subscriber = await MakeSubscriberOnWorkflow(workflow);

        var trigger = await eventClient.Create(
            new EventCreateData
            {
                EventName = eventName,
                To = { SubscriberId = subscriber.SubscriberId! },
                Payload = new TestMessage(),
            });

        trigger.Data.Acknowledged.Should().BeTrue();

        await VerifyNotifications(subscriber);
    }

    [RunnableInDebugOnly]
    public async Task E2E_InApp_Topic_Test()
    {
        var (workflow, eventName) = await MakeInAppWorkflow();
        var subscriber = await MakeSubscriberOnWorkflow(workflow);
        var subscriber2 = await MakeSubscriberOnWorkflow(workflow);

        var topic = await topicFactory.Make(
            subscriber: subscriber,
            additionalSubscribers: [subscriber2]);

        var trigger = await eventClient.Create(
            new TopicCreateData
            {
                EventName = eventName,
                To = [new TopicTrigger(topic.Key)],
                Payload = new TestMessage(),
            });

        trigger.Data.Acknowledged.Should().BeTrue();

        await VerifyNotifications(subscriber);
        await VerifyNotifications(subscriber2);
    }


    private async Task VerifyNotifications(Subscriber subscriber)
    {
        // WAIT for system to catch up given it is async
        const int maxRetryAttempts = 3;
        var retryPolicy = Policy
            .Handle<XunitException>()
            .WaitAndRetryAsync(maxRetryAttempts, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        await retryPolicy.ExecuteAsync(async () =>
        {
            // check, has it arrived?
            var notificationsForSubscriber = await notificationsClient
                .Get(new NotificationQueryParams { SubscriberIds = [subscriber.SubscriberId] });

            notificationsForSubscriber
                .Data
                .Should()
                .HaveCount(1);

            var hasFailed = notificationsForSubscriber
                .Data.Any(x => x.Jobs.Any(y => y.Status.Equals("failed", StringComparison.InvariantCultureIgnoreCase)));

            // it may actually be failing for real and need to introspect reason
            if (hasFailed)
            {
                var message = notificationsForSubscriber
                    .Data
                    // Job has a status with specifics inside the execution details 
                    .Where(x => x.Jobs
                        .Any(y => y.Status.Equals("failed", StringComparison.InvariantCultureIgnoreCase)))
                    .SelectMany(s => s.Jobs)
                    // now find the reason/detail
                    .SelectMany(x => x.ExecutionDetails
                        .Where(z => z.Status.Equals("failed", StringComparison.InvariantCultureIgnoreCase)))
                    .Select(x => x.Detail)
                    .FirstOrDefault();

                // If you get here, it is likely the integration itself is turned off 
                // TODO: check that the integration is turned on
                Assert.Fail(message ?? "Reason unknown");
            }
        });

        await retryPolicy.ExecuteAsync(async () =>
        {
            var dataCount = (await subscriberClient.GetInAppUnseen(subscriber.SubscriberId!))
                .Data
                .Count;
            var inAppMessages = await subscriberClient.GetInApp(subscriber.SubscriberId);
            dataCount
                .Should()
                .Be(1);

            inAppMessages.Data.Should().NotBeEmpty();

            // var z = inAppMessages.Data.Where(x => x.Channels.Contains(ChannelTypeEnum.InApp));
        });
    }

    private async Task<(Workflow, string)> MakeInAppWorkflow()
    {
        var workflowGroup = await workflowGroupFactory.Make(new WorkflowGroupCreateData
        {
            Name = $"End2EndGroup ({StringGenerator.SequenceOfAlphaNumerics(5)})",
        });
        var workflow = await workflowFactory.Make(new WorkflowCreateData
        {
            Name = $"In-App [End2end {StringGenerator.SequenceOfAlphaNumerics(10)}]",
            Description = StringGenerator.LoremIpsum(5),
            WorkflowGroupId = workflowGroup.Id,
            PreferenceSettings = new PreferenceChannels
            {
                InApp = true,
            },
            Steps =
            [
                new Step
                {
                    Name = $"In-App [End2end ({StringGenerator.SequenceOfAlphaNumerics(5)})]",
                    Template = new InAppMessageTemplate
                    {
                        Content = "Fantastic move! {{message}}",
                        Variables =
                        [
                            new TemplateVariable
                            {
                                Name = "message",
                                Type = TemplateVariableTypeEnum.String,
                                Required = true,
                            },
                        ],
                    },
                    Active = true,
                },
            ],
            Active = true,
        });


        // Now, ensure that the integration is active. Otherwise, the trigger will not deliver
        // but reports that the subscriber has no active integrations where they problem is that
        // the system has none to offer even though the subscriber has registered
        var existingIntegration = (await integrationClient.Get())
            .Data
            .SingleOrDefault(x => x.ProviderId == "novu");
        if (existingIntegration is not null && !existingIntegration.Active)
        {
            await integrationClient.Update(
                existingIntegration.Id,
                existingIntegration.ToEditData(x => x.Active = true));
        }
        else if (existingIntegration is null)
        {
            await integrationFactory.Make(providerId: "novu");
        }

        var eventName = workflow.Triggers.FirstOrDefault()?.Identifier;
        return (workflow, eventName);
    }

    private async Task<Subscriber> MakeSubscriberOnWorkflow(Workflow workflow)
    {
        var subscriber = await subscriberFactory.Make();

        // update subscriber preferences
        var preferences = await subscriberClient.GetPreferences(subscriber.SubscriberId!);

        // enable notification
        var templateId = preferences.Data.Single(x => x.Template.Name == workflow.Name).Template.Id;

        await subscriberClient.UpdatePreference(
            subscriber.SubscriberId!,
            templateId,
            new SubscriberPreferenceEditData
            {
                Channel = new Channel
                {
                    Type = ChannelTypeEnum.InApp,
                    Enabled = true,
                },
            });
        return subscriber;
    }
}

public class TestMessage
{
    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; } = "Test Message";
}