using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows.Step.Message;

public class MessageAction
{
    [JsonProperty("status")] public MessageActionStatusEnum Status { get; set; }
    [JsonProperty("buttons")] public MessageCtaData Buttons { get; set; }
    [JsonProperty("result")] public MessageActionResult Result { get; set; }
}