using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows.Step.Message;

public class Actor
{
    [JsonProperty("type")] public ActorTypeEnum Type { get; set; }
    [JsonProperty("data")] public string Data { get; set; }
}