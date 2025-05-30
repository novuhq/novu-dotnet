using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Workflows.Step.Message;

public class PushMessageTemplate : BaseMessageTemplate, IMessageTemplate
{
    [JsonProperty("title")] public string Title { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public StepTypeEnum Type { get; set; } = StepTypeEnum.Push;

    public MessageTemplateContentType ContentType { get; set; } = MessageTemplateContentType.CustomHtml;
    public object Content { get; set; }
}