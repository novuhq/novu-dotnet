using Newtonsoft.Json;

namespace Novu.Domain.Models.Subscribers;

public class SubscriberOnlineEditData
{
    [JsonProperty("isOnline")] public bool IsOnline { get; set; }
}