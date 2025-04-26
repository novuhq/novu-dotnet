using Newtonsoft.Json;

namespace Novu.Domain.Models.Events;

public class Tenant
{
    [JsonProperty("identifier")] public string Identifier { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("data")] public object Data { get; set; }
}