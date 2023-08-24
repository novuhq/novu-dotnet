using Newtonsoft.Json;

namespace Novu.DTO.Subscribers;

public class SubscriberOnlineEditData
{
    [JsonProperty("isOnline")] public bool IsOnline { get; set; }
}