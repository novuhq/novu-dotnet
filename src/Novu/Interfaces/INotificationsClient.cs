using Refit;

namespace Novu.Interfaces;

public interface INotificationsClient
{
    [Get("/notifications")]
    public Task GetNotificationsAsync();
    public Task GetNotificationStatisticsAsync();

    public Task GetNotificationGraphStatisticsAsync();
    
    public Task GetNotificationAsync(string notificationId);
}