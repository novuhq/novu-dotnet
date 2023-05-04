using Novu.Common;
using Novu.DTO.Topics;
using Novu.Interfaces;
using Novu.Utilities;
using RestSharp;

namespace Novu.Clients;

public class TopicClient : ApiClient, ITopicClient
{
    public TopicClient(INovuClientConfiguration config) : base(config)
    {
        
    }

    public async Task<TopicCreateResponseDto> CreateTopicAsync(TopicCreateDto dto)
    {
        var request = new RestRequest(Endpoints.TOPIC_CREATE);

        var json = Serializer<TopicCreateDto>.ToJson(dto);

        request.AddBody(json, ContentType.Json);

        var restResponse = await Client.PostAsync(request);

        var response = Serializer<TopicCreateResponseDto>.FromJson(restResponse.Content);

        return response;
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