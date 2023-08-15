using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Models.Workflows.Step.Message;

public class DelayMessageTemplate : BaseMessageTemplate, IMessageTemplate
{
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public StepTypeEnum Type { get; set; } = StepTypeEnum.Delay;

    public object Content { get; set; } = string.Empty;
    public MessageTemplateContentType ContentType { get; set; } = MessageTemplateContentType.Editor;
}