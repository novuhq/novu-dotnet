using Novu.DTO.Topics;
using Novu.Interfaces;

namespace Novu.Clients;

public class TopicClient : ApiClient, ITopicClient
{
    public TopicClient(INovuClientConfiguration config) : base(config)
    {
        
    }

    public Task CreateTopicAsync(TopicCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task GetTopicsAsync(int page = 0)
    {
        throw new NotImplementedException();
    }

    public Task GetTopicAsync(string topicKey)
    {
        throw new NotImplementedException();
    }

    public Task AddSubscriberAsync(string topicKey, string subscriberKey)
    {
        throw new NotImplementedException();
    }

    public Task VerifySubscriberAsync(string topicKey, string subscriberKey)
    {
        throw new NotImplementedException();
    }

    public Task RemoveSubscriberAsync(string topicKey, string subscriberKey)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTopicAsync(string topicKey)
    {
        throw new NotImplementedException();
    }

    public Task RenameTopicAsync(string topicKey, string newTopicName)
    {
        throw new NotImplementedException();
    }
}