using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Models.Workflows.Step.Message;

public interface IMessageTemplate
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    StepTypeEnum Type { get; set; }

    /// <summary>
    ///     Polymorphic between string (code) and typed EmailBlock[]
    /// </summary>
    object Content { get; set; }

    [JsonProperty("contentType")]
    [JsonConverter(typeof(StringEnumConverter))]
    MessageTemplateContentType ContentType { get; set; }

    [JsonProperty("deleted")] bool Deleted { get; set; }

    [JsonProperty("variables")] TemplateVariable[] Variables { get; set; }
}