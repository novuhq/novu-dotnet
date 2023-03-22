using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class UpdateSubscriberOnlineStatusRequestDTO
{
    [JsonProperty("isOnline")]
    public bool IsOnline { get; set; }
}