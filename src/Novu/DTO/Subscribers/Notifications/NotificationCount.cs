using Newtonsoft.Json;

namespace Novu.DTO.Subscribers.Notifications;

public class NotificationCount
{
    [JsonProperty("count")] public int Count { get; set; }
}