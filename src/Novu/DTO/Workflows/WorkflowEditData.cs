using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Novu.Models.Workflows;
using Novu.Models.Workflows.Step;
using Novu.Models.Workflows.Trigger;

namespace Novu.DTO.Workflows;

/// <summary>
///     see
/// </summary>
public class WorkflowEditData
{
    [JsonProperty("name", Required = Required.Always)]
    public string Name { get; set; }

    [JsonProperty("tags", Required = Required.AllowNull)]
    public string[] Tags { get; set; }

    [MaxLength(300)]
    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("identifier")] public string Identifier { get; set; }

    [Required]
    [JsonProperty("steps", Required = Required.Always)]
    public Step[] Steps { get; set; }

    /// <remarks>
    ///     This is a workflow group in the api see https://docs.novu.co/api/create-workflow-group/
    /// </remarks>
    [JsonProperty("notificationGroupId")]
    public string WorkflowGroupId { get; set; }

    [JsonProperty("critical", Required = Required.AllowNull)]
    public bool Critical { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    /// <remarks>
    ///     This is a workflow group in the api see https://docs.novu.co/api/create-workflow-group/
    /// </remarks>
    [JsonProperty("preferenceSettings")]
    public PreferenceChannels PreferenceSettings { get; set; }

    /// <summary>
    ///     NotificationTemplateCustomData is basically an untyped dictionary
    /// </summary>
    [JsonProperty("data")]
    public object Data { get; set; }

    [JsonProperty("triggers")] public Trigger[] Triggers { get; set; }
}