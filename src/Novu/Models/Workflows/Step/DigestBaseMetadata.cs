using Newtonsoft.Json;

namespace Novu.Models.Workflows.Step;

public class DigestBaseMetadata : AmountAndUnit
{
    [JsonProperty("digestKey")] public string DigestKey { get; set; }
}