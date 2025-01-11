using Newtonsoft.Json;

namespace Novu.Domain.Models.Notifications;

public class To
{
    [JsonProperty("subscriberId")] public string SubscriberId { get; set; }
}