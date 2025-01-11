using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Novu.Domain.Models.Workflows.Step.Message;

namespace Novu.Domain.Models.Workflows.Trigger;

/// <summary>
/// </summary>
/// <remarks>
///     Originally NotificationTriggerVariable
/// </remarks>
public class TriggerVariable
{
    [Required] [JsonProperty("name")] public string Name { get; set; }

    /// <summary>
    ///     JSON serialisable form of the value matching the <see cref="Type" />
    /// </summary>
    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("type")] public TemplateVariableTypeEnum Type { get; set; }
}