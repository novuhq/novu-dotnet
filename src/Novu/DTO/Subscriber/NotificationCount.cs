using Newtonsoft.Json;

namespace Novu.DTO.Subscriber;

public class NotificationCount
{
    [JsonProperty("count")] public int Count { get; set; }
}