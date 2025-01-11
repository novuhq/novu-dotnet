using Newtonsoft.Json;

namespace Novu.Domain.Models;

public class NovuAcknowledgeData
{
    [JsonProperty("acknowledged")] public bool Acknowledged { get; set; }
    [JsonProperty("status")] public string Status { get; set; }
}