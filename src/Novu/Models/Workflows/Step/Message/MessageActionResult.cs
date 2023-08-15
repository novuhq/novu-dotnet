using Newtonsoft.Json;

namespace Novu.Models.Workflows.Step.Message;

public class MessageActionResult
{
    [JsonProperty("payload")] public object Payload { get; set; }
    [JsonProperty("type")] public ButtonTypeEnum Type { get; set; }
}