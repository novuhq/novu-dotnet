using Newtonsoft.Json;

namespace Novu.Domain.Models.Notifications;

public class Digest
{
    [JsonProperty("timed")] public Timed Timed { get; set; }

    [JsonProperty("events")] public List<object> Events { get; set; }
}