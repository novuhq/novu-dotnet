using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Workflows.Step.Message;

public class DigestMessageTemplate : BaseMessageTemplate, IMessageTemplate
{
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public StepTypeEnum Type { get; set; } = StepTypeEnum.Digest;

    public object Content { get; set; } = string.Empty;
    public MessageTemplateContentType ContentType { get; set; } = MessageTemplateContentType.Editor;
}