using Newtonsoft.Json;

namespace Novu.Domain.Models.Notifications;

public class Metadata
{
    [JsonProperty("timed")] public Timed Timed { get; set; }
}