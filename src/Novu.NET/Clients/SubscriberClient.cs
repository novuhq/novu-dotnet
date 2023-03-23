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
    public async Task<SubscribersDTO> GetSubscribers(int page = 0)
    {
        var request = page > 0 
            ? new RestRequest($"/subscribers?page={page}") 
            : new RestRequest($"/subscribers");
        
        var restResponse = await Client.GetAsync(request);
        
        var response = Serializer<SubscribersDTO>.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// Get a single Subscriber
    /// </summary>
    /// <param name="id"><see cref="String"/> Subscriber ID</param>
    /// <returns></returns>
    public async Task<SubscriberDTO> GetSubscriber(string id)
    {
        var request = new RestRequest($"/subscribers/{id}");
        var restResponse = await Client.GetAsync(request);

        var response = Serializer<SubscriberDTO>.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// Create a new Subscriber
    /// </summary>
    /// <param name="dto">
    /// <see cref="CreateSubscriberDTO"/> Model to create a new Subscriber
    /// </param>
    /// <returns>
    /// <see cref="SubscriberDTO"/> The newly created Subscriber
    /// </returns>
    public async Task<SubscriberDTO> CreateSubscriber(CreateSubscriberDTO dto)
    {
        var request = new RestRequest("/subscribers");
        var json = Serializer<CreateSubscriberDTO>.ToJson(dto);
        request.AddBody(json, ContentType.Json);
        var restResponse = await Client.PostAsync(request);
        
        var response = Serializer<SubscriberDTO>.FromJson(restResponse.Content);
        return response;
    }

    /// <summary>
    /// Update a Subscriber
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    public async Task<SubscriberDTO> UpdateSubscriber(SubscriberDTO requestDto)
    {
        var request = new RestRequest($"/subscribers/{requestDto.SubscriberId}");
        request.AddJsonBody(Serializer<SubscriberDTO>.ToJson(requestDto));

        var restResponse = await Client.PutAsync(request);
        var subscriber = Serializer<SubscriberDTO>.FromJson(restResponse.Content);
        return subscriber;
    }

    /// <summary>
    /// Delete a Subscriber
    /// </summary>
    /// <param name="id">
    /// <see cref="string"/> Subscriber ID to delete
    /// </param>
    /// <returns>
    /// <see cref="DeleteResponseDTO"/>
    /// </returns>
    public async Task<DeleteResponseDTO> DeleteSubscriber(string id)
    {
        var request = new RestRequest($"/subscribers/{id}");
        var restResponse = await Client.DeleteAsync(request);
        var response = Serializer<DeleteResponseDTO>.FromJson(restResponse.Content);
        return response;
    }

    /// <summary>
    /// Update a Subscriber
    /// </summary>
    /// <param name="subscriberId">Subscriber ID</param>
    /// <param name="model"><see cref="SubscriberDTO"/> with changes.</param>
    /// <returns><see cref="SubscriberDTO"/></returns>
    public async Task<SubscriberDTO> 
        UpdateSubscriberCredentials(string subscriberId, UpdateSubscriberCredentialsRequestDTO model)
    {
        var request = new RestRequest($"/subscribers/{subscriberId}/credentials");
        request.AddJsonBody(model);
        var restResponse = await Client.PutAsync(request);
        var response = Serializer<SubscriberDTO>.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// Update Subscribers online status
    /// </summary>
    /// <param name="subscriberId"><see cref="SubscriberDTO.SubscriberId"/> Subscribers ID</param>
    /// <param name="model"><see cref="SubscriberOnlineDTO"/></param>
    /// <returns></returns>
    public async Task<SubscriberDTO> UpdateOnlineStatus(string subscriberId, SubscriberOnlineDTO model)
    {
        var request = new RestRequest($"/subscribers/{subscriberId}/online-status");
        request.AddJsonBody(model);
        
        var restResponse = await Client.PatchAsync(request);
        var response = Serializer<SubscriberDTO>.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// Not Implemented Yet
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PaginatedResponseDTO<dynamic>> 
        GetSubscriberNotificationFeed(SubscriberNotificationFeedRequestDTO requestDto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Not Implemented Yet
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> GetSubscriberNotificationUnseen()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Not Implemented Yet
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> UpdateSubscriberMessageAsSeen()
    {
        throw new NotImplementedException();
    }
}