using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows.Step;

public class DigestBaseMetadata : AmountAndUnit
{
    [JsonProperty("digestKey")] public string DigestKey { get; set; }
}