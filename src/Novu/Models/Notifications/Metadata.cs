using Newtonsoft.Json;

namespace Novu.Models.Notifications;

public class Metadata
{
    [JsonProperty("timed")] public Timed Timed { get; set; }
}