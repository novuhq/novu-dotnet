using Newtonsoft.Json;

namespace Novu.Domain.Models;

public class NovuSucceedData
{
    [JsonProperty("succeeded")] public string[] Succeeded { get; set; }
}