using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Workflows.Step.Message;

public class TriggerMessageTemplate : BaseMessageTemplate, IMessageTemplate
{
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public StepTypeEnum Type { get; set; } = StepTypeEnum.Trigger;

    public object Content { get; set; }
    public MessageTemplateContentType ContentType { get; set; }
}