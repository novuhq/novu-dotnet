using Newtonsoft.Json;

namespace Novu.Models.Notifications;

public class To
{
    [JsonProperty("subscriberId")] public string SubscriberId { get; set; }
}