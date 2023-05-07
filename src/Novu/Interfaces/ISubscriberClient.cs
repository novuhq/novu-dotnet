using System.Threading.Tasks;
using Novu.DTO;

namespace Novu.Interfaces
{
    public interface ISubscriberClient
    {
        Task<SubscribersDto> GetSubscribers(int page = 0);

        Task<SubscriberDto> GetSubscriber(string id);

        Task<SubscriberDto> CreateSubscriber(CreateSubscriberDto dto);

        Task<SubscriberDto> UpdateSubscriber(SubscriberDto requestDto);

        Task<DeleteResponseDto> DeleteSubscriber(string id);

        Task<SubscriberDto> UpdateOnlineStatus(string subscriberId, SubscriberOnlineDto model);
    }
}