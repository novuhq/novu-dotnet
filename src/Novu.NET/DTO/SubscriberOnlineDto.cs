using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class SubscriberOnlineDto
{
    [JsonProperty("isOnline")]
    public bool IsOnline { get; set; }
}