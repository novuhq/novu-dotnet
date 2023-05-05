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

    /// <inheritdoc />
    public async Task<TopicCreateResponseDto> CreateTopicAsync(TopicCreateDto dto)
    {
        var request = new RestRequest(Endpoints.Topics);

        var json = Serializer<TopicCreateDto>.ToJson(dto);

        request.AddBody(json, ContentType.Json);

        var restResponse = await Client.PostAsync(request);

        var response = Serializer<TopicCreateResponseDto>.FromJson(restResponse.Content);

        return response;
    }

    /// <inheritdoc />
    public async Task<PaginatedResponseDto<TopicDto>> GetTopicsAsync(int page = 0)
    {
        var request = page > 0
            ? new RestRequest($"{Endpoints.Topics}?page={page}")
            : new RestRequest($"{Endpoints.Topics}");

        var restResponse = await Client.GetAsync(request);

        var response = Serializer<PaginatedResponseDto<TopicDto>>.FromJson(restResponse.Content);

        return response;
    }

    /// <inheritdoc />
    public async Task<TopicResponseDto> GetTopicAsync(string topicKey)
    {
        var request = new RestRequest(Endpoints.Topic(topicKey));

        var restResponse = await Client.GetAsync(request);
        
        var response = Serializer<TopicResponseDto>.FromJson(restResponse.Content);
        
        // todo: check response

        return response;
    }

    /// <inheritdoc />
    public async Task<TopicSubscriberAdditionResponseDto> 
        AddSubscriberAsync(string topicKey, TopicSubscriberUpdateDto dto)
    {
        var request = new RestRequest(Endpoints.TopicSubscribers(topicKey));
        
        var json = Serializer<TopicSubscriberUpdateDto>.ToJson(dto);
        
        request.AddBody(json, ContentType.Json);
        
        var restResponse = await Client.PostAsync(request);
        
        var response = Serializer<TopicSubscriberAdditionResponseDto>.FromJson(restResponse.Content);

        return response;
    }

    /// <inheritdoc />
    public async Task<TopicSubscriberDto> VerifySubscriberAsync(string topicKey, string subscriberId)
    {
        var request = new RestRequest(Endpoints.TopicSubscriber(topicKey, subscriberId));
        
        var restResponse = await Client.GetAsync(request);

        var response = Serializer<TopicSubscriberDto>.FromJson(restResponse.Content);

        return response;
    }

    /// <inheritdoc />
    public async Task RemoveSubscriberAsync(string topicKey, TopicSubscriberUpdateDto subscriberKey)
    {
        var request = new RestRequest(Endpoints.TopicRemoveSubscriber(topicKey));
        
        var json = Serializer<TopicSubscriberUpdateDto>.ToJson(subscriberKey);
        
        request.AddBody(json, ContentType.Json);

        await Client.PostAsync(request);
    }

    /// <inheritdoc />
    public async Task DeleteTopicAsync(string topicKey)
    {
        var request = new RestRequest(Endpoints.Topic(topicKey));

        await Client.DeleteAsync(request);
    }

    /// <inheritdoc />
    public async Task<TopicResponseDto> RenameTopicAsync(string topicKey, string newTopicName)
    {
        var dto = new TopicCreateDto
        {
            Name = newTopicName
        };

        var request = new RestRequest(Endpoints.Topic(topicKey));
        
        var json = Serializer<TopicCreateDto>.ToJson(dto);
        
        request.AddBody(json, ContentType.Json);
        
        var restResponse = await Client.PatchAsync(request);
        
        var response = Serializer<TopicResponseDto>.FromJson(restResponse.Content);
        
        return response;
    }
}