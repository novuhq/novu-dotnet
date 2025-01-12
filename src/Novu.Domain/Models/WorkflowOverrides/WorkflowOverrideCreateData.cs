using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Novu.Domain.Models.Workflows;

namespace Novu.Domain.Models.WorkflowOverrides;

public class WorkflowOverrideCreateData
{

    [JsonProperty("workflowId")]
    [Required(AllowEmptyStrings = true)]
    public string WorkflowId { get; set; }

    [JsonProperty("tenantId")]
    [Required(AllowEmptyStrings = true)]
    public string TenantId { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("preferenceSettings")] public PreferenceChannels PreferenceSettings { get; set; }
}