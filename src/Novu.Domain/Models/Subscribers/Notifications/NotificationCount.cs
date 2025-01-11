using Newtonsoft.Json;

namespace Novu.Domain.Models.Subscribers.Notifications;

public class NotificationCount
{
    [JsonProperty("count")] public int Count { get; set; }
}