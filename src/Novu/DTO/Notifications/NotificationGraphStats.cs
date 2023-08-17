using Newtonsoft.Json;

namespace Novu.DTO.Notifications;

public class NotificationGraphStats
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("count")] public int Count { get; set; }

    [JsonProperty("templates")] public string[] Templates { get; set; }

    [JsonProperty("channels")] public string[] Channels { get; set; }
}