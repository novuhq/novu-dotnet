using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Novu.Domain.Models.WorkflowGroups;

namespace Novu.Domain.Models.Workflows;

public class Workflow
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }

    [JsonProperty("_creatorId")] public string CreatorId { get; set; }

    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }

    /// <remarks>
    ///     This is a workflow group in the api see https://docs.novu.co/api/create-workflow-group/
    /// </remarks>
    [JsonProperty("_notificationGroupId")]
    public string WorkflowGroupId { get; set; }

    [JsonProperty("_parentId")] public string ParentId { get; set; }

    [JsonProperty("name", Required = Required.Always)]
    public string Name { get; set; }

    public string Description { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("draft")] public bool Draft { get; set; }

    [JsonProperty("critical")] public bool Critical { get; set; }

    [JsonProperty("tags")] public string[] Tags { get; set; }

    /// <remarks>
    ///     This is a workflow group in the api see https://docs.novu.co/api/create-workflow-group/
    /// </remarks>
    [JsonProperty("preferenceSettings")]
    public PreferenceChannels PreferenceSettings { get; set; }

    [Required]
    [JsonProperty("steps", Required = Required.Always)]
    public Step.Step[] Steps { get; set; }

    /// <remarks>
    ///     Triggers are not found on the interface but exist on the instance and are not settable.
    /// </remarks>
    [JsonProperty("triggers")]
    public Trigger.Trigger[] Triggers { get; set; }

    [JsonProperty("deleted")] public bool Deleted { get; set; }

    [JsonProperty("deletedAt")] public DateTime DeletedAt { get; set; }

    [JsonProperty("deletedBy")] public string DeletedBy { get; set; }

    [Required]
    [JsonProperty("notificationGroup")]
    public WorkflowGroup WorkflowGroup { get; set; }
}