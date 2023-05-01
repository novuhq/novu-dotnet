using Novu.DTO;

namespace Novu.Interfaces;

public interface ISubscriberClient
{
    public Task<SubscribersDto> GetSubscribers(int page = 0);

    public Task<SubscriberDto> GetSubscriber(string id);

    public Task<SubscriberDto> CreateSubscriber(CreateSubscriberDto dto);
    
    public Task<SubscriberDto> UpdateSubscriber(SubscriberDto requestDto);
    
    public Task<DeleteResponseDto> DeleteSubscriber(string id);
    
    public Task<SubscriberDto> UpdateOnlineStatus(string subscriberId, SubscriberOnlineDto model);
}