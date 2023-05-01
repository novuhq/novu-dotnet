namespace Novu.Interfaces;

public interface INotificationsClient
{
    public Task GetNotificationsAsync();

    public Task GetNotificationStatisticsAsync();

    public Task GetNotificationGraphStatisticsAsync();
    
    public Task GetNotificationAsync(string notificationId);
}