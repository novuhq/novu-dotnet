using Novu.DTO;
using Novu.DTO.Notifications;
using Refit;

namespace Novu.Interfaces;

public interface INotificationsClient
{
    [Get("/notifications")]
    public Task<PaginatedResponseDto<Notification>> Get([Query] NotificationQueryParams? queryParam = null);

    [Get("/notifications/stats")]
    public Task<NovuResponse<NotificationStats>> GetStats();

    [Get("/notifications/graph/stats")]
    public Task<NovuResponse<NotificationGraphStats[]>> GetGraphStats([Query] int days = 7);

    [Get("/notifications/{id}")]
    public Task Get(string id);
}