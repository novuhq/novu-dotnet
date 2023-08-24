using Newtonsoft.Json;

namespace Novu.DTO;

public class AcknowledgeData
{
    [JsonProperty("acknowledged")] public bool Acknowledged { get; set; }
    [JsonProperty("status")] public string Status { get; set; }
}