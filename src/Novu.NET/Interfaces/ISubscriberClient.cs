using Novu.NET.Clients;
using Novu.NET.DTO;

namespace Novu.NET.Interfaces;

public interface ISubscriberClient
{
    public Task<SubscribersDTO> GetSubscribers();

    public Task<SubscriberDTO> GetSubscriber(string id);

    public Task<SubscriberDTO> CreateSubscriber(CreateSubscriberDTO dto);
    
    public Task<SubscriberDTO> UpdateSubscriber(UpdateSubscriberRequestDTO requestDto);
    
    public Task<DeleteResponseDTO> DeleteSubscriber(string id);

    public Task<SubscriberDTO> UpdateSubscriberCredentials(string subscriberId, UpdateSubscriberCredentialsRequestDTO model);

    public Task<SubscriberDTO> UpdateSubscriberOnlineStatus(string subscriberId, UpdateSubscriberOnlineStatusRequestDTO model);

    public Task<dynamic> GetSubscriberNotificationFeed();

    public Task<dynamic> GetSubscriberNotificationUnseen();

    public Task<dynamic> UpdateSubscriberMessageAsSeen();
}