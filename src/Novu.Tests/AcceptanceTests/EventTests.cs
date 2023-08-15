using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.DTO;
using Novu.DTO.Topics;
using Novu.DTO.Workflows;
using Novu.Tests.IntegrationTests;
using ParkSquare.Testing.Generators;
using Refit;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.AcceptanceTests;

public class EventTests : BaseIntegrationTest
{
    public EventTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async void Should_Trigger_Event()
    {
        var subscriber = await Make<SubscriberDto>();

        var trigger = await Event.Trigger(
            new EventTriggerDataDto
            {
                EventName = await GetActiveEvent(),
                To = { SubscriberId = subscriber?.SubscriberId! },
                Payload = new TestPayload(),
            });
        trigger.TriggerResponsePayloadDto.Acknowledged.Should().BeTrue();

        // TODO: how to detect success for a subscriber
    }

    [Fact]
    public async void Should_Trigger_Bulk_Event()
    {
        var subscriber = await Make<SubscriberDto>();
        var eventName = await GetActiveEvent();

        var dto = new SendBulkRequest(
            new[] { "Hello", "World" }
                .Select(message => new EventTriggerDataDto
                {
                    EventName = eventName!,
                    To = { SubscriberId = subscriber?.SubscriberId! },
                    Payload = new TestPayload { Message = message },
                })
                .ToList());

        var trigger = await Event.TriggerBulkAsync(dto);

        trigger.PayloadDtos.Should().HaveCount(2);
        trigger.PayloadDtos.Should().AllSatisfy(triggerPayload => Assert.True(triggerPayload.Acknowledged));

        // TODO: how to detect success for a subscriber
    }

    [Fact]
    public async void Should_Trigger_Broadcast_Event()
    {
        var dto = new BroadcastMessageRequest
        {
            Name = await GetActiveEvent(),
            Payload = new TestPayload(),
        };

        var trigger = await Event.TriggerBroadcastAsync(dto);
        trigger.TriggerResponsePayloadDto.Acknowledged.Should().BeTrue();

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

        var dto = new BroadcastMessageRequest
        {
            Name = eventName!,
            Payload = new TestPayload(),
        };

        await Assert.ThrowsAsync<ApiException>(async () => { await Event.TriggerBroadcastAsync(dto); });
    }


    [Fact]
    public async void Should_Trigger_Topic()
    {
        var topic = await Make<TopicCreateResponseDto>();

        var dto = new EventTopicTriggerDto
        {
            EventName = await GetActiveEvent(),
            Topic = new EventTopicDto { TopicKey = topic.Data.Key },
            Payload = new TestPayload(),
        };
        var topicTrigger = await Event.TriggerTopicAsync(dto);
        topicTrigger.TriggerResponsePayloadDto.Acknowledged.Should().BeTrue();

        // how to determine delivery?
    }

    [Fact]
    public async void Should_Trigger_Cancel_Event()
    {
        var dto = new BroadcastMessageRequest
        {
            Name = await GetActiveEvent(),
            Payload = new TestPayload(),
        };
        var trigger = await Event.TriggerBroadcastAsync(dto);

        trigger.TriggerResponsePayloadDto.Acknowledged.Should().BeTrue();

        await Event.TriggerCancelAsync(trigger.TriggerResponsePayloadDto.TransactionId);

        // TODO: how to detect success for a subscriber
    }


    /// <summary>
    ///    WARN: Make an active workflow with one step otherwise servers return 500 error (rather than say 404 or 409)
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