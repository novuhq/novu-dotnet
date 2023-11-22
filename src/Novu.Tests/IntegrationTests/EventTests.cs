using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.DTO.Events;
using Novu.DTO.Subscribers;
using Novu.DTO.Workflows;
using ParkSquare.Testing.Generators;
using Refit;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class EventTests : BaseIntegrationTest
{
    public EventTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async void Should_Trigger_Event()
    {
        var subscriber = await Make<Subscriber>();

        var trigger = await Event.Trigger(
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
    public async void Should_Trigger_Bulk_Event()
    {
        var subscriber = await Make<Subscriber>();
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

        var trigger = await Event.CreateBulk(dto);

        trigger.Data.Should().HaveCount(2);
        trigger.Data.Should().AllSatisfy(triggerPayload => Assert.True(triggerPayload.Acknowledged));

        // TODO: how to detect success for a subscriber
    }

    [Fact]
    public async void Should_Trigger_Broadcast_Event()
    {
        var dto = new BroadcastEventCreateData
        {
            Name = await GetActiveEvent(),
            Payload = new TestPayload(),
        };

        var trigger = await Event.CreateBroadcast(dto);
        trigger.Data.Acknowledged.Should().BeTrue();

        // TODO: how to detect success for a subscriber
    }

    [Fact]
    public async void Should_Trigger_Broadcast_Event_FAILS()
    {
        // allow for exception to asserted
        DeRegisterExceptionHandler();

        //
        // WARN: A non-active workflow throws 500 error
        //
        var workflow = await Make<Workflow>( /*steps: new[] { StepFactory.InApp(true) }, active: true*/);
        var eventName = workflow.Triggers.FirstOrDefault()?.Identifier;
        eventName.Should().NotBeNull();

        var dto = new BroadcastEventCreateData
        {
            Name = eventName!,
            Payload = new TestPayload(),
        };

        await Assert.ThrowsAsync<ApiException>(async () => { await Event.CreateBroadcast(dto); });
    }


    /*
    [Fact]
    public async void Should_Trigger_Topic()
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
    public async void Should_Trigger_Cancel_Event()
    {
        var dto = new BroadcastEventCreateData
        {
            Name = await GetActiveEvent(),
            Payload = new TestPayload(),
        };
        var trigger = await Event.CreateBroadcast(dto);

        trigger.Data.Acknowledged.Should().BeTrue();

        await Event.Cancel(trigger.Data.TransactionId);

        // TODO: how to detect success for a subscriber
    }

    /// <summary>
    ///     WARN: Make an active workflow with one step otherwise servers return 500 error (rather than say 404 or 409)
    /// </summary>
    private async Task<string> GetActiveEvent()
    {
        var workflow = await Make<Workflow>(steps: new[] { StepFactory.InApp(true) }, active: true);
        var eventName = workflow.Triggers.FirstOrDefault()?.Identifier;
        eventName.Should().NotBeNull();
        return eventName;
    }

    public record TestPayload
    {
        [JsonProperty("message")] public string Message { get; set; } = StringGenerator.LoremIpsum(20);
    }
}