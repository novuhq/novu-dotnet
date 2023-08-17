using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.DTO;
using Novu.DTO.Integrations;
using Novu.DTO.Notifications;
using Novu.DTO.Subscriber.Preferences;
using Novu.DTO.WorkflowGroup;
using Novu.DTO.Workflows;
using Novu.Interfaces;
using Novu.Models.Subscriber.Preferences;
using Novu.Models.Workflows;
using Novu.Models.Workflows.Step;
using Novu.Models.Workflows.Step.Message;
using Novu.Tests.IntegrationTests;
using ParkSquare.Testing.Generators;
using Polly;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Novu.Tests.AcceptanceTests;

public class NotificationTests : BaseIntegrationTest
{
    public NotificationTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task E2E_InApp_Test()
    {
        var workflowGroup = await Make<WorkflowGroupSingleResponseDto>(new WorkflowGroupDto
        {
            WorkflowGroupName = $"End2EndGroup ({StringGenerator.SequenceOfAlphaNumerics(5)})",
        });
        var workflow = await Make<Workflow>(new WorkflowCreateData
        {
            Name = $"In-App [End2end {StringGenerator.SequenceOfAlphaNumerics(10)}]",
            Description = StringGenerator.LoremIpsum(5),
            WorkflowGroupId = workflowGroup.PayloadDto.Id,
            PreferenceSettings = new PreferenceChannels
            {
                InApp = true,
            },
            Steps = new Step[]
            {
                new()
                {
                    Name = $"In-App [End2end ({StringGenerator.SequenceOfAlphaNumerics(5)})]",
                    Template = new InAppMessageTemplate
                    {
                        Content = "Fantastic move! {{message}}",
                        Variables = new[]
                        {
                            new TemplateVariable
                            {
                                Name = "message",
                                Type = TemplateVariableTypeEnum.String,
                                Required = true,
                            },
                        },
                    },
                    Active = true,
                },
            },
            Active = true,
        });

        var subscriber = await Make<SubscriberDto>();

        // update subscriber preferences
        var preferences = await Subscriber.GetPreferences(subscriber.SubscriberId!);

        // enable notification
        var templateId = preferences.Data.Single(x => x.Template.Name == workflow.Name).Template.Id;

        await Subscriber.UpdatePreference(
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

        var eventName = workflow.Triggers.FirstOrDefault()?.Identifier;

        // Now, ensure that the integration is active. Otherwise, the trigger will not deliver
        // but reports that the subscriber has no active integrations where they problem is that
        // the system has none to offer even though the subscriber has registered
        var existingIntegration = (await Integration.Get())
            .Data
            .SingleOrDefault(x => x.ProviderId == "novu");
        if (existingIntegration is not null && !existingIntegration.Active)
        {
            await Integration.Update(
                existingIntegration.Id,
                new IntegrationEditData
                {
                    Active = true,
                    Identifier = existingIntegration.Identifier,
                    Name = existingIntegration.Name,
                    Credentials = existingIntegration.Credentials,
                    Channel = existingIntegration.Channel,
                    EnvironmentId = existingIntegration.EnvironmentId,
                });
        }
        else if (existingIntegration is null)
        {
            await Make<Integration>(providerId: "novu");
        }


        var trigger = await Event.Trigger(
            new EventTriggerDataDto
            {
                EventName = eventName!,
                To = { SubscriberId = subscriber.SubscriberId },
                Payload = new TestMessage(),
            });

        trigger.TriggerResponsePayloadDto.Acknowledged.Should().BeTrue();

        // PAUSE for system to catch up given it is async
        var maxRetryAttempts = 2;
        var retryPolicy = Policy
            .Handle<XunitException>()
            .WaitAndRetryAsync(maxRetryAttempts, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        await retryPolicy.ExecuteAsync(async () =>
        {
            // check, has it arrived?
            var notificationsForSubscriber = await Get<INotificationsClient>()
                .Get(new NotificationQueryParams { SubscriberIds = new[] { subscriber.SubscriberId } });

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
            var dataCount = (await Subscriber.GetInAppUnseen(subscriber.SubscriberId))
                .Data
                .Count;
            var inAppMessages = await Subscriber.GetInApp(subscriber.SubscriberId);
            dataCount
                .Should()
                .Be(1);

            inAppMessages.Data.Should().NotBeEmpty();

            var z = inAppMessages.Data.Where(x => x.Channels.Contains(ChannelTypeEnum.InApp));
        });
    }
}

public class TestMessage
{
    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; } = "Test Message";
}