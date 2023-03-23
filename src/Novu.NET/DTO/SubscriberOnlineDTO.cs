using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class SubscriberOnlineDTO
{
    [JsonProperty("isOnline")]
    public bool IsOnline { get; set; }
}