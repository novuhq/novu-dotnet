using Newtonsoft.Json;

namespace Novu.NET.Models;

public class UpdateSubscriberOnlineStatusRequest
{
    [JsonProperty("isOnline")]
    public bool IsOnline { get; set; }
}