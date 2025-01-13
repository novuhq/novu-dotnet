using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.Clients;
using Novu.Domain.Models.Events;
using Novu.Tests.Factories;
using ParkSquare.Testing.Generators;
using Refit;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class EventTests(SubscriberFactory subscriberFactory, WorkflowFactory workflowFactory, IEventClient eventClient)
{
    [Fact]
    public async Task Should_Trigger_Event()
    {
        var subscriber = await subscriberFactory.Make();

        var trigger = await eventClient.Trigger(
            new EventCreateData
            {
                EventName = await GetActiveEvent(),
                To = { SubscriberId = subscriber?.SubscriberId! },
                Payload = new TestPayload(),
            });
        trigger.Data.Acknowledged.Should().BeTrue();

        // TODO: how to detect success for a subscriber
    }

    [Fact]
    public async Task Should_Create_Subscriber_And_Trigger_Event()
    {
        var subscriber = await subscriberFactory.Make();

        var trigger = await eventClient.Trigger(
            new EventCreateData
            {
                EventName = await GetActiveEvent(),
                To =
                {
                    SubscriberId = subscriber?.SubscriberId! + "-new",
                    Email = subscriber?.Email + ".changed",
                    FirstName = subscriber?.FirstName + " Changed",
                    LastName = subscriber?.FirstName + " Changed",
                    Phone = "+777" + subscriber?.Phone,
                    Avatar = subscriber?.Avatar + "?changed=1",
                    Locale = subscriber?.Locale + ",ro-RO",
                    Data = new
                    {
                        EMAIL_PREFERENCE = "NONE",
                        ADDITIONAL_PROPERTIES = new { IS_TEST_SUBSCRIBER = true },
                    },
                },
                Payload = new TestPayload(),
            });
        trigger.Data.Acknowledged.Should().BeTrue();

        // TODO: how to detect success for a subscriber
    }

    [Fact]
    public async Task Should_Trigger_Bulk_Event()
    {
        var subscriber = await subscriberFactory.Make();
        var eventName = await GetActiveEvent();

        var dto = new BulkEventCreateData(
            new[] { "Hello", "World" }
                .Select(message => new EventCreateData
                {
                    EventName = eventName!,
                    To = { SubscriberId = subscriber?.SubscriberId! },
                    Payload = new TestPayload { Message = message },
                })
                .ToList());

        var trigger = await eventClient.CreateBulk(dto);

        trigger.Data.Should().HaveCount(2);
        trigger.Data.Should().AllSatisfy(triggerPayload => Assert.True(triggerPayload.Acknowledged));

        // TODO: how to detect success for a subscriber
    }

    [Fact]
    public async Task Should_Trigger_Broadcast_Event()
    {
        var dto = new BroadcastEventCreateData
        {
            Name = await GetActiveEvent(),
            Payload = new TestPayload(),
        };

        var trigger = await eventClient.CreateBroadcast(dto);
        trigger.Data.Acknowledged.Should().BeTrue();

        // TODO: how to detect success for a subscriber
    }

    [Fact(Skip = "Not implemented for deregister exception handler")]
    public async Task Should_Trigger_Broadcast_Event_FAILS()
    {
        // allow for exception to asserted
        // DeRegisterExceptionHandler();

        //
        // WARN: A non-active workflow throws 500 error
        //
        var workflow =
            await workflowFactory.Make( /*steps: new[] { StepFactory.InApp(true) }, active: true*/);
        var eventName = workflow.Triggers.FirstOrDefault()?.Identifier;
        eventName.Should().NotBeNull();

        var dto = new BroadcastEventCreateData
        {
            Name = eventName!,
            Payload = new TestPayload(),
        };

        await Assert.ThrowsAsync<ApiException>(async () => { await eventClient.CreateBroadcast(dto); });
    }


    /*
    [Fact]
    public async Task Should_Trigger_Topic()
    {
        var topic = await Make<Topic>();

        var dto = new EventTopicTriggerDto
        {
            EventName = await GetActiveEvent(),
            Topic = new EventTopicDto { TopicKey = topic.Key },
            Payload = new TestPayload(),
        };
        var topicTrigger = await Event.Create(dto);
        topicTrigger.TransactionAcknowledgeData.Acknowledged.Should().BeTrue();

        // how to determine delivery?
    }
    */

    [Fact]
    public async Task Should_Trigger_Cancel_Event()
    {
        var dto = new BroadcastEventCreateData
        {
            Name = await GetActiveEvent(),
            Payload = new TestPayload(),
        };
        var trigger = await eventClient.CreateBroadcast(dto);

        trigger.Data.Acknowledged.Should().BeTrue();

        await eventClient.Cancel(trigger.Data.TransactionId);

        // TODO: how to detect success for a subscriber
    }

    /// <summary>
    ///     WARN: Make an active workflow with one step otherwise servers return 500 error (rather than say 404 or 409)
    /// </summary>
    private async Task<string> GetActiveEvent()
    {
        var workflow = await workflowFactory.Make(steps: [StepFactory.InApp(true)], active: true);
        var eventName = workflow.Triggers.FirstOrDefault()?.Identifier;
        eventName.Should().NotBeNull();
        return eventName;
    }

    public record TestPayload
    {
        [JsonProperty("message")] public string Message { get; set; } = StringGenerator.LoremIpsum(20);
    }
}