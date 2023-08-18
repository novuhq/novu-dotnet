using Newtonsoft.Json;

namespace Novu.Models.Triggers;

public class Actor
{
    [JsonProperty("subscriberId")] public string SubscriberId { get; set; }
}