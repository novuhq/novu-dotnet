using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class AdditionalDataDTO
{
    [JsonProperty("key")]
    public string Key { get; set; }
    
    [JsonProperty("value")]
    public string Value { get; set; }
}