using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Novu.JsonConverters;

namespace Novu.Models.Workflows.Step.Message;

public class SmsMessageTemplate : BaseMessageTemplate, IMessageTemplate
{
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public StepTypeEnum Type { get; set; } = StepTypeEnum.Sms;

    /// <summary>
    ///     Polymorphic between string (code) and typed EmailBlock[]
    /// </summary>
    [JsonProperty("content")]
    [JsonConverter(typeof(TypeOrStringConverter<EmailBlock>))]
    public object Content { get; set; }

    [JsonProperty("contentType")]
    public MessageTemplateContentType ContentType { get; set; } = MessageTemplateContentType.CustomHtml;
}