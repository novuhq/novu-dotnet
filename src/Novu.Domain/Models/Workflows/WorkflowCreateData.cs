using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows;

public class WorkflowCreateData
{
    /// <remarks>
    ///     This is a workflow group in the api see https://docs.novu.co/api/create-workflow-group/
    /// </remarks>
    [JsonProperty("notificationGroupId")]
    [Required]
    public string WorkflowGroupId { get; set; }

    [Required]
    [JsonProperty("name", Required = Required.Always)]
    public string Name { get; set; }

    [JsonProperty("tags")] public string[] Tags { get; set; }

    [MaxLength(100)]
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    ///     While you can add steps on creation, they are partial (eg senderName, subject) and must be
    ///     added as part of the update
    /// </summary>
    [Required]
    [JsonProperty("steps", Required = Required.Always)]
    public Step.Step[] Steps { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("draft")] public bool Draft { get; set; }

    [JsonProperty("critical")] public bool Critical { get; set; }

    /// <remarks>
    ///     This is a workflow group in the api see https://docs.novu.co/api/create-workflow-group/
    /// </remarks>
    [JsonProperty("preferenceSettings")]
    public PreferenceChannels PreferenceSettings { get; set; }

    [JsonProperty("blueprintId")] public string BlueprintId { get; set; }

    /// <summary>
    ///     NotificationTemplateCustomData is basically an untyped dictionary
    /// </summary>
    [JsonProperty("data")]
    public object Data { get; set; }
}