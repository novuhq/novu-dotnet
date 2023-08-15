using Newtonsoft.Json;

namespace Novu.Models.Workflows;

public class Filter
{
    [JsonProperty("isNegated")] public bool IsNegated { get; set; }

    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("value")] public string Value { get; set; }

    [JsonProperty("children")] public Child[] Children { get; set; }
}