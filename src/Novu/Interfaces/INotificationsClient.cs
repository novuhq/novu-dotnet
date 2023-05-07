using System.Threading.Tasks;

namespace Novu.Interfaces
{
    public interface INotificationsClient
    {
        Task GetNotificationsAsync();

        Task GetNotificationStatisticsAsync();

        Task GetNotificationGraphStatisticsAsync();

        Task GetNotificationAsync(string notificationId);
    }
}