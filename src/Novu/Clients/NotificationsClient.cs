using Novu.Interfaces;

namespace Novu.Clients;

public class NotificationsClient : ApiClient, INotificationsClient
{
    public NotificationsClient(INovuClientConfiguration apiConfiguration) : base(apiConfiguration)
    {
    }

    public Task GetNotificationsAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetNotificationStatisticsAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetNotificationGraphStatisticsAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetNotificationAsync(string notificationId)
    {
        throw new NotImplementedException();
    }
}