using Newtonsoft.Json;

namespace Novu.Models.Subscriber.Preferences;

public class Preference
{
    [JsonProperty("enabled")] public bool Enabled { get; set; }
    [JsonProperty("channels")] public Channels Channels { get; set; }
    [JsonProperty("overrides")] public List<Override> Overrides { get; set; }
}