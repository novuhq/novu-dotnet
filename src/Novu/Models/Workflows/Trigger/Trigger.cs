using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Models.Workflows.Trigger;

/// <summary>
/// </summary>
/// <remarks>
///     Originally NotificationTrigger
/// </remarks>
public class Trigger
{
    [Required] [JsonProperty("type")] public TriggerTypeEnum Type { get; set; }

    [Required]
    [JsonProperty("identifier")]
    public string Identifier { get; set; }

    [Required] [JsonProperty("variables")] public TriggerVariable[] Variables { get; set; }

    [JsonProperty("subscriberVariables")] public TriggerVariable[] SubscriberVariables { get; set; }
}