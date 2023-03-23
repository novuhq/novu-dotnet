using Novu.NET.Clients;
using Novu.NET.DTO;

namespace Novu.NET.Interfaces;

public interface ISubscriberClient
{
    public Task<SubscribersDTO> GetSubscribers(int page = 0);

    public Task<SubscriberDTO> GetSubscriber(string id);

    public Task<SubscriberDTO> CreateSubscriber(CreateSubscriberDTO dto);
    
    public Task<SubscriberDTO> UpdateSubscriber(SubscriberDTO requestDto);
    
    public Task<DeleteResponseDTO> DeleteSubscriber(string id);

    public Task<SubscriberDTO> UpdateSubscriberCredentials(string subscriberId, UpdateSubscriberCredentialsRequestDTO model);

    public Task<SubscriberDTO> UpdateOnlineStatus(string subscriberId, SubscriberOnlineDTO model);

    public Task<PaginatedResponseDTO<dynamic>> GetSubscriberNotificationFeed(
        SubscriberNotificationFeedRequestDTO requestDto);

    public Task<dynamic> GetSubscriberNotificationUnseen();

    public Task<dynamic> UpdateSubscriberMessageAsSeen();
}