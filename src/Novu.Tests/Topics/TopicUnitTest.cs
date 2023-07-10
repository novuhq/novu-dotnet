using Novu.DTO;
using Novu.DTO.Topics;

namespace Novu.Tests.Topics;

public class TopicUnitTest : IClassFixture<Fixture>
{
    public readonly Fixture _fixture;
    
    public TopicUnitTest(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async void Should_Create_Topic()
    {
        var client = _fixture.NovuClient;

        var topicRequest = new TopicCreateDto
        {
            Key = $"test:topic:{Guid.NewGuid().ToString()}",
            Name = "Test Topic",
            
        };

        var topic = await client.Topic.CreateTopicAsync(topicRequest);
        
        Assert.Equal(topicRequest.Key, topic.Data.Key);
    }

    [Fact]
    public async void Should_Add_Subscriber_To_Topic()
    {
        var client = _fixture.NovuClient;

        var topicRequest = new TopicCreateDto
        {
            Key = $"test:topic:{Guid.NewGuid().ToString()}",
            Name = "Test Topic"
        };
        
        var subscriber = await client.Subscriber.CreateSubscriber(new CreateSubscriberDto()
        {
            SubscriberId = "test:subscriber:1",
            Email = "noreply@novu.com",
            Data = new List<AdditionalDataDto>()
            {
                new()
                {
                    Key = "test",
                    Value = "test"
                }
            }
        });
        var topic = await client.Topic.CreateTopicAsync(topicRequest);

        var subscriberList = new TopicSubscriberUpdateDto(new() {"test:subscriber:1" });

        var result = await client.Topic.AddSubscriberAsync(topic.Data.Key, subscriberList);
        
        Assert.Single(result.Data.Succeeded);
        
        Assert.Contains(subscriberList.Subscribers, x => x == result.Data.Succeeded.First());
    }

    [Fact]
    public async void Should_List_Topics()
    {
        var client = _fixture.NovuClient;
            
        Should_Create_Topic();
        
        var topics = await client.Topic.GetTopicsAsync();
        
        Assert.NotEmpty(topics.Data);
    }

    [Fact]
    public async void Should_Validate_Topic_Subscriber()
    {
        var client = _fixture.NovuClient;

        var topic = await client.Topic.CreateTopicAsync(new TopicCreateDto
        {
            Key = $"test:topic:{Guid.NewGuid().ToString()}",
            Name = "Test Topic - Should_Validate_Topic_Subscriber",
        });
        var subscriber = await client.Subscriber.CreateSubscriber(new CreateSubscriberDto()
        {
            SubscriberId = "test:subscriber:1",
            Data = new List<AdditionalDataDto>()
            {
                new()
                {
                    Key = "test",
                    Value = "test"
                }
            }
        });
        var subscriberList = new TopicSubscriberUpdateDto(new() { "test:subscriber:1" });

        await client.Topic.AddSubscriberAsync(topic.Data.Key, subscriberList);
        
        await client.Topic.VerifySubscriberAsync(topic.Data.Key, subscriberList.Subscribers.First());
    }

    [Fact]
    public async void Should_Remove_Subscriber_From_Topic()
    {
        var client = _fixture.NovuClient;

        var subscriber = await client.Subscriber.CreateSubscriber(new CreateSubscriberDto()
        {
            SubscriberId = "test:subscriber:1",
            Email = "noreply@novu.com",
            Data = new List<AdditionalDataDto>()
            {
                new()
                {
                    Key = "test",
                    Value = "test"
                }
            }
        });
        var topic = await client.Topic.CreateTopicAsync(new TopicCreateDto
        {
            Key = $"test:topic:{Guid.NewGuid().ToString()}",
            Name = "Test Topic - Should_Validate_Topic_Subscriber",
        });

        var subscriberList = new TopicSubscriberUpdateDto(new() {subscriber.SubscriberId });

        await client.Topic.AddSubscriberAsync(topic.Data.Key, subscriberList);
        
        await client.Topic.RemoveSubscriberAsync(topic.Data.Key, subscriberList);
    }

    [Fact]
    public async void Should_Delete_Topic()
    {
        var client = _fixture.NovuClient;

        var topic = await client.Topic.CreateTopicAsync(new TopicCreateDto
        {
            Key = $"test:topic:{Guid.NewGuid().ToString()}",
            Name = "Test Topic - Should_Validate_Topic_Subscriber",
        });
        
        await client.Topic.DeleteTopicAsync(topic.Data.Key);
    }

    [Fact]
    public async void Should_Get_Single_Topic()
    {
        var client = _fixture.NovuClient;

        var topic = await client.Topic.CreateTopicAsync(new TopicCreateDto
        {
            Key = $"test:topic:{Guid.NewGuid().ToString()}",
            Name = "Test Topic - Should_Validate_Topic_Subscriber",
        });
        
        var result = await client.Topic.GetTopicAsync(topic.Data.Key);
        
        Assert.Equal(topic.Data.Key, result.Data.Key);
    }

    [Fact]
    public async void Should_Rename_Topic()
    {
        var client = _fixture.NovuClient;

        var topic = await client.Topic.CreateTopicAsync(new TopicCreateDto
        {
            Key = $"test:topic:{Guid.NewGuid().ToString()}",
            Name = "Test Topic - Should_Validate_Topic_Subscriber",
        });
        
        var newTopicName = $"test:topic-rename:{Guid.NewGuid().ToString()}";
        
        var result = await client.Topic.RenameTopicAsync(topic.Data.Key, new RenameTopicRequest(newTopicName));
        
        Assert.Equal(newTopicName, result.Data.Name);
    }
}