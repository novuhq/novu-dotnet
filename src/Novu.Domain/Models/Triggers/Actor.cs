using Newtonsoft.Json;

namespace Novu.Domain.Models.Triggers;

public class Actor
{
    [JsonProperty("subscriberId")] public string SubscriberId { get; set; }
}