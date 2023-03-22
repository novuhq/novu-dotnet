using System.Net;
using Novu.NET.Exceptions;
using Novu.NET.Interfaces;
using Novu.NET.Models;
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
    public async Task<SubscribersResponse> GetSubscribers()
    {
        var request = new RestRequest("/subscribers");
        var restResponse = await Client.GetAsync(request);
        
        // TODO: Check restResponse
        
        var response = SubscribersResponse.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// Get a single Subscriber
    /// </summary>
    /// <param name="id"><see cref="String"/> Subscriber ID</param>
    /// <returns></returns>
    public async Task<SubscriberModel> GetSubscriber(string id)
    {
        var request = new RestRequest($"/subscribers/{id}");
        var restResponse = await Client.GetAsync(request);

        var response = SubscriberModel.FromJson(restResponse.Content);

        return response;
    }

    /// <summary>
    /// Create a new Subscriber
    /// </summary>
    /// <param name="model">
    /// <see cref="CreateSubscriberModel"/> Model to create a new Subscriber
    /// </param>
    /// <returns>
    /// <see cref="SubscriberModel"/> The newly created Subscriber
    /// </returns>
    public async Task<SubscriberModel> CreateSubscriber(CreateSubscriberModel model)
    {
        var request = new RestRequest("/subscribers");
        var json = CreateSubscriberModel.ToJson(model);
        request.AddJsonBody(json);
        
        var restResponse = await Client.PostAsync(request);
        
        var subscriber = SubscriberModel.FromJson(restResponse.Content);
        
        return subscriber;
    }

    public async Task<SubscriberModel> UpdateSubscriber(UpdateSubscriberModel model)
    {
        var request = new RestRequest("/subscribers");
        request.AddJsonBody(model);

        var restResponse = await Client.PutAsync(request);
        var subscriber = SubscriberModel.FromJson(restResponse.Content);
        return subscriber;
    }

    public async Task<DeleteResponseModel> DeleteSubscriber(string id)
    {
        var request = new RestRequest($"/subscribers/{id}");
        var restResponse = await Client.DeleteAsync(request);
        var response = DeleteResponseModel.FromJson(restResponse.Content);
        return response;
    }

    public async Task<SubscriberModel> UpdateSubscriberCredentials(string subscriberId, UpdateSubscriberCredentialsRequest model)
    {
        var request = new RestRequest($"/subscribers/{subscriberId}/credentials");
        request.AddJsonBody(model);
        var restResponse = await Client.PutAsync(request);
        var response = SubscriberModel.FromJson(restResponse.Content);
        
        return response;
    }

    public async Task<SubscriberModel> UpdateSubscriberOnlineStatus(string subscriberId, UpdateSubscriberOnlineStatusRequest model)
    {
        var request = new RestRequest($"/subscribers/{subscriberId}/online-status");
        request.AddJsonBody(model);
        var restResponse = await Client.PutAsync(request);
        var response = SubscriberModel.FromJson(restResponse.Content);
        
        return response;
    }

    public async Task<dynamic> GetSubscriberNotificationFeed()
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> GetSubscriberNotificationUnseen()
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> UpdateSubscriberMessageAsSeen()
    {
        throw new NotImplementedException();
    }
}