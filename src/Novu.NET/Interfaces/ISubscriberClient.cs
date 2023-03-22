using Novu.NET.Clients;
using Novu.NET.Models;

namespace Novu.NET.Interfaces;

public interface ISubscriberClient
{
    public Task<SubscribersResponse> GetSubscribers();

    public Task<SubscriberModel> GetSubscriber(string id);

    public Task<SubscriberModel> CreateSubscriber(CreateSubscriberModel model);
    
    public Task<SubscriberModel> UpdateSubscriber(UpdateSubscriberModel model);
    
    public Task<DeleteResponseModel> DeleteSubscriber(string id);

    public Task<SubscriberModel> UpdateSubscriberCredentials(string subscriberId, UpdateSubscriberCredentialsRequest model);

    public Task<SubscriberModel> UpdateSubscriberOnlineStatus(string subscriberId, UpdateSubscriberOnlineStatusRequest model);

    public Task<dynamic> GetSubscriberNotificationFeed();

    public Task<dynamic> GetSubscriberNotificationUnseen();

    public Task<dynamic> UpdateSubscriberMessageAsSeen();
}