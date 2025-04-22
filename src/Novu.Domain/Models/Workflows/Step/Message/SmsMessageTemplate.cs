using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Novu.Domain.JsonConverters;

namespace Novu.Domain.Models.Workflows.Step.Message;

public class SmsMessageTemplate : BaseMessageTemplate, IMessageTemplate
{
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public StepTypeEnum Type { get; set; } = StepTypeEnum.Sms;

    /// <summary>
    ///     Polymorphic between string (code) and typed EmailBlock[]
    /// </summary>
    [JsonProperty("content")]
    [JsonConverter(typeof(ArrayObjectOrStringConverter<EmailBlock>))]
    public object Content { get; set; }

    [JsonProperty("contentType")]
    public MessageTemplateContentType ContentType { get; set; } = MessageTemplateContentType.CustomHtml;
}