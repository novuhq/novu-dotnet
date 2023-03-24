using System.Net;
using Newtonsoft.Json;
using Novu.NET.Exceptions;
using Novu.NET.Interfaces;
using Novu.NET.DTO;
using Novu.NET.Utilities;
using RestSharp;

namespace Novu.NET.Clients;

public class SubscriberClient : ApiClient, ISubscriberClient
{
    public SubscriberClient(INovuClientConfiguration config) : base(config)
    {
        
    }
    
    /// <summary>
    /// Get a paginated response of current Subscribers
    /// </summary>
    /// <returns></returns>
    /// <exception cref="HttpRequestException">
    ///  Thrown when the status code does not equal 200.
    /// </exception>
    /// <exception cref="NovuClientException"></exception>
    public async Task<SubscribersDto> GetSubscribers(int page = 0)
    {
        var request = page > 0 
            ? new RestRequest($"/subscribers?page={page}") 
            : new RestRequest($"/subscribers");
        
        var restResponse = await Client.GetAsync(request);
        
        var response = Serializer<SubscribersDto>.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// Get a single Subscriber
    /// </summary>
    /// <param name="id"><see cref="String"/> Subscriber ID</param>
    /// <returns></returns>
    public async Task<SubscriberDto> GetSubscriber(string id)
    {
        var request = new RestRequest($"/subscribers/{id}");
        var restResponse = await Client.GetAsync(request);

        var response = Serializer<SubscriberDto>.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// Create a new Subscriber
    /// </summary>
    /// <param name="dto">
    /// <see cref="CreateSubscriberDto"/> Model to create a new Subscriber
    /// </param>
    /// <returns>
    /// <see cref="SubscriberDto"/> The newly created Subscriber
    /// </returns>
    public async Task<SubscriberDto> CreateSubscriber(CreateSubscriberDto dto)
    {
        var request = new RestRequest("/subscribers");
        var json = Serializer<CreateSubscriberDto>.ToJson(dto);
        request.AddBody(json, ContentType.Json);
        var restResponse = await Client.PostAsync(request);
        
        var response = Serializer<SubscriberDto>.FromJson(restResponse.Content);
        return response;
    }

    /// <summary>
    /// Update a Subscriber
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    public async Task<SubscriberDto> UpdateSubscriber(SubscriberDto requestDto)
    {
        var request = new RestRequest($"/subscribers/{requestDto.SubscriberId}");
        request.AddJsonBody(Serializer<SubscriberDto>.ToJson(requestDto));

        var restResponse = await Client.PutAsync(request);
        var subscriber = Serializer<SubscriberDto>.FromJson(restResponse.Content);
        return subscriber;
    }

    /// <summary>
    /// Delete a Subscriber
    /// </summary>
    /// <param name="id">
    /// <see cref="string"/> Subscriber ID to delete
    /// </param>
    /// <returns>
    /// <see cref="DeleteResponseDto"/>
    /// </returns>
    public async Task<DeleteResponseDto> DeleteSubscriber(string id)
    {
        var request = new RestRequest($"/subscribers/{id}");
        var restResponse = await Client.DeleteAsync(request);
        var response = Serializer<DeleteResponseDto>.FromJson(restResponse.Content);
        return response;
    }

    /// <summary>
    /// Update Subscribers online status
    /// </summary>
    /// <param name="subscriberId"><see cref="SubscriberDto.SubscriberId"/> Subscribers ID</param>
    /// <param name="model"><see cref="SubscriberOnlineDto"/></param>
    /// <returns></returns>
    public async Task<SubscriberDto> UpdateOnlineStatus(string subscriberId, SubscriberOnlineDto model)
    {
        var request = new RestRequest($"/subscribers/{subscriberId}/online-status");
        request.AddJsonBody(model);
        
        var restResponse = await Client.PatchAsync(request);
        var response = Serializer<SubscriberDto>.FromJson(restResponse.Content);

        return response;
    }
}