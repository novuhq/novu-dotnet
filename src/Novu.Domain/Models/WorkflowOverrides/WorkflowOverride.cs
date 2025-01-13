using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Novu.Domain.Models.Workflows;

namespace Novu.Domain.Models.WorkflowOverrides;

public class WorkflowOverride
{
    [JsonProperty("_id")]
    [Required(AllowEmptyStrings = true)]
    public string Id { get; set; }

    [JsonProperty("_organizationId")]
    [Required(AllowEmptyStrings = true)]
    public string OrganizationId { get; set; }

    [JsonProperty("_environmentId")]
    [Required(AllowEmptyStrings = true)]
    public string EnvironmentId { get; set; }

    [JsonProperty("_workflowId")]
    [Required(AllowEmptyStrings = true)]
    public string WorkflowId { get; set; }

    [JsonProperty("_tenantId")]
    [Required(AllowEmptyStrings = true)]
    public string TenantId { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("preferenceSettings")]
    [Required]
    public PreferenceChannels PreferenceSettings { get; set; } = new();

    [JsonProperty("deleted")] public bool Deleted { get; set; }

    [JsonProperty("deletedAt")] public string DeletedAt { get; set; }

    [JsonProperty("deletedBy")] public string DeletedBy { get; set; }

    [JsonProperty("createdAt")]
    [Required(AllowEmptyStrings = true)]
    public string CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    [Required(AllowEmptyStrings = true)]
    public string UpdatedAt { get; set; }
}