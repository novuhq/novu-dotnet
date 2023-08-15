using Newtonsoft.Json;

namespace Novu.DTO;

public class SubscriberOnlineDto
{
    [JsonProperty("isOnline")] public bool IsOnline { get; set; }
}