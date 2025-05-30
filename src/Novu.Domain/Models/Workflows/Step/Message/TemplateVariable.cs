using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Workflows.Step.Message;

public class TemplateVariable
{
    [Required]
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public TemplateVariableTypeEnum Type { get; set; }

    [Required] [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("required")] public bool Required { get; set; }

    /// <summary>
    ///     Can be string or bool—hopefully boolean with be okay in stringly form
    /// </summary>
    [JsonProperty("defaultValue")]
    public string DefaultValue { get; set; }
}