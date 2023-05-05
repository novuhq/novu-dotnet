using Novu.Common;
using Novu.DTO;
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

    /// <summary>
    /// todo: add docs
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<TopicCreateResponseDto> CreateTopicAsync(TopicCreateDto dto)
    {
        var request = new RestRequest(Endpoints.Topics);

        var json = Serializer<TopicCreateDto>.ToJson(dto);

        request.AddBody(json, ContentType.Json);

        var restResponse = await Client.PostAsync(request);

        var response = Serializer<TopicCreateResponseDto>.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// todo: add docs
    /// </summary>
    /// <param name="page"></param>
    public async Task<PaginatedResponseDto<TopicDto>> GetTopicsAsync(int page = 0)
    {
        var request = page > 0
            ? new RestRequest($"{Endpoints.Topics}?page={page}")
            : new RestRequest($"{Endpoints.Topics}");

        var restResponse = await Client.GetAsync(request);

        var response = Serializer<PaginatedResponseDto<TopicDto>>.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// todo: implement
    /// </summary>
    /// <param name="topicKey"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task GetTopicAsync(string topicKey)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// todo: add docs
    /// </summary>
    /// <param name="topicKey"></param>
    /// <param name="subscriberKey"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<TopicSubscriberAdditionResponseDto> 
        AddSubscriberAsync(string topicKey, TopicSubscriberAdditionRequestDto subscriberAdditionRequests)
    {
        var request = new RestRequest(Endpoints.TopicSubscribers(topicKey));
        
        var json = Serializer<TopicSubscriberAdditionRequestDto>.ToJson(subscriberAdditionRequests);
        
        request.AddBody(json, ContentType.Json);
        
        var restResponse = await Client.PostAsync(request);
        
        var response = Serializer<TopicSubscriberAdditionResponseDto>.FromJson(restResponse.Content);

        return response;
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