using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Models.Workflows.Step.Message;

public class ChatMessageTemplate : BaseMessageTemplate, IMessageTemplate
{
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public StepTypeEnum Type { get; set; } = StepTypeEnum.Chat;

    public object Content { get; set; }
    public MessageTemplateContentType ContentType { get; set; }
}