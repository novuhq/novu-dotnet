using Novu.Domain.Models;
using Novu.Domain.Models.Notifications;
using Novu.QueryParams;
using Refit;

namespace Novu.Clients;

public interface INotificationsClient
{
    [Get("/notifications")]
    public Task<NovuPaginatedResponse<Notification>> Get([Query] NotificationQueryParams? queryParam = null);

    [Get("/notifications/stats")]
    public Task<NovuResponse<NotificationStats>> GetStats();

    [Get("/notifications/graph/stats")]
    public Task<NovuResponse<NotificationGraphStats[]>> GetGraphStats([Query] int days = 7);

    [Get("/notifications/{id}")]
    public Task Get(string id);
}