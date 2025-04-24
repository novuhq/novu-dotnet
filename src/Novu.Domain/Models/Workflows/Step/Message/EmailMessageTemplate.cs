using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Novu.Domain.JsonConverters;

namespace Novu.Domain.Models.Workflows.Step.Message;

public class EmailMessageTemplate : BaseMessageTemplate, IMessageTemplate
{
    [JsonProperty("senderName")] public string SenderName { get; set; }
    [JsonProperty("subject")] public string Subject { get; set; }
    [JsonProperty("preheader")] public string Preheader { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public StepTypeEnum Type { get; set; } = StepTypeEnum.Email;

    /// <summary>
    ///     Polymorphic between string (code) and typed EmailBlock[]
    /// </summary>
    [JsonProperty("content")]
    [JsonConverter(typeof(TypeOrStringConverter<EmailBlock>))]
    public object Content { get; set; }

    [JsonProperty("contentType")] public MessageTemplateContentType ContentType { get; set; }
}