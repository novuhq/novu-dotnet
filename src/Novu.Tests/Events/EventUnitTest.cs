using Newtonsoft.Json;
using Novu.DTO;
using Novu.DTO.Topics;
using Novu.Tests.Fixtures;

namespace Novu.Tests.Events;

public class EventUnitTest : IClassFixture<SubscriberFixture>
{
    private readonly SubscriberFixture _fixture;

    public EventUnitTest(SubscriberFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async void Should_Trigger_Event()
    {
        // Create a subscriber to test against.
        var subscriber = await _fixture.GenerateTestSubscriber();

        var client = _fixture.NovuClient;
        
        var testRecord = new TestRecord
        {
            Message = "This is a test message"
        };

        if (subscriber.SubscriberId == null) throw new Exception("Subscriber Id is null");
        
        var dto = new EventTriggerDataDto()
        {
            EventName = "test",
            To =
            {
                SubscriberId = subscriber.SubscriberId
            },
            Payload = testRecord
        };

        var trigger = await client.Event.Trigger(dto);

        if (!trigger.TriggerResponsePayloadDto.Acknowledged)
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }
    }

    [Fact]
    public async void Should_Trigger_Bulk_Event()
    {
        var subscriber = await _fixture.GenerateTestSubscriber();

        var client = _fixture.NovuClient;

        var payload = new List<EventTriggerDataDto>()
        {
            new()
            {
                EventName = "test",
                To = { SubscriberId = subscriber.SubscriberId},
                Payload = new TestRecord(){ Message = "Hello"}
            },
            new()
            {
                EventName = "test",
                To = { SubscriberId = subscriber.SubscriberId},
                Payload = new TestRecord(){ Message = "World"}
            },
        };

        var trigger = await client.Event.TriggerBulkAsync(new SendBulkRequest(payload));

        if (trigger.PayloadDtos.Count != 2)
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }

        if (trigger.PayloadDtos.Any(triggerPayload => !triggerPayload.Acknowledged))
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }
    }

    [Fact]
    public async void Should_Trigger_Broadcast_Event()
    {
        // Create a subscriber to test against.
        var subscriber = await _fixture.GenerateTestSubscriber();

        var client = _fixture.NovuClient;
        
        var testRecord = new TestRecord
        {
            Message = "This is a test message"
        };

        if (subscriber.SubscriberId == null) throw new Exception("Subscriber Id is null");

        var dto = new BroadcastMessageRequest("test", testRecord, default);

        var trigger = await client.Event.TriggerBroadcastAsync(dto);

        if (!trigger.TriggerResponsePayloadDto.Acknowledged)
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }
    }

    [Fact]
    public async void Should_Trigger_Cancel_Event()
    {
        var subscriber = await _fixture.GenerateTestSubscriber();

        var client = _fixture.NovuClient;
        
        var testRecord = new TestRecord
        {
            Message = "This is a test message"
        };

        if (subscriber.SubscriberId == null) throw new Exception("Subscriber Id is null");

        var dto = new BroadcastMessageRequest("test", testRecord, default);

        var trigger = await client.Event.TriggerBroadcastAsync(dto);

        if (!trigger.TriggerResponsePayloadDto.Acknowledged)
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }

        await client.Event.TriggerCancelAsync(trigger.TriggerResponsePayloadDto.TransactionId);
    }

    [Fact]
    public async void Should_Trigger_Topic()
    {
        var client = _fixture.NovuClient;
        
        var testRecord = new TestRecord
        {
            Message = "This is a test message"
        };

        var topic = await client.Topic.CreateTopicAsync(new TopicCreateDto
        {
            Key = $"topic:test:{Guid.NewGuid().ToString()}",
            Name = "Test Topic"
        });

        var dto = new EventTopicTriggerDto
        {
            EventName = "test",
            Topic = new EventTopicDto
            {
                TopicKey = topic.Data.Key
            },
            Payload = testRecord
        };

        var topicTrigger = await client.Event.TriggerTopicAsync(dto);

        Assert.True(topicTrigger.TriggerResponsePayloadDto.Acknowledged);
    }
}

public record TestRecord
{
    [JsonProperty("message")]
    public string Message { get; set; }
}