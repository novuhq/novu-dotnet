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
            Name = "Test Topic",
            
        };
        
        var topic = await client.Topic.CreateTopicAsync(topicRequest);

        var subscriberList = new TopicSubscriberAdditionRequestDto
        {
            Keys = new List<string>
            {
                "test:subscriber:1",
            }
        };

        var result = await client.Topic.AddSubscriberAsync(topic.Data.Key, subscriberList);
        
        Assert.Single(result.Data.Succeeded);
        
        Assert.Contains(subscriberList.Keys, x => x == result.Data.Succeeded.First());
    }

    [Fact]
    public async void Should_List_Topics()
    {
        var client = _fixture.NovuClient;
            
        Should_Create_Topic();
        
        var topics = await client.Topic.GetTopicsAsync();
        
        Assert.NotEmpty(topics.Data);
    }
}