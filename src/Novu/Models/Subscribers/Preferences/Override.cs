using Newtonsoft.Json;

namespace Novu.Models.Subscribers.Preferences;

public class Override
{
    [JsonProperty("channel")] public string Channel { get; set; }

    [JsonProperty("source")] public string Source { get; set; }
}