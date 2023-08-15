using Newtonsoft.Json;

namespace Novu.Models.Workflows;

public class Child
{
    [JsonProperty("field")] public string Field { get; set; }

    [JsonProperty("value")] public string Value { get; set; }

    [JsonProperty("operator")] public string Operator { get; set; }

    [JsonProperty("on")] public string On { get; set; }
}