using Newtonsoft.Json;

namespace Novu.DTO;

public class SucceedData
{
    [JsonProperty("succeeded")] public string[] Succeeded { get; set; }
}