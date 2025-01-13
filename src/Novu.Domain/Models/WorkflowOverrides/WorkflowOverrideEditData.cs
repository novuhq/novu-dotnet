using Newtonsoft.Json;
using Novu.Domain.Models.Workflows;

namespace Novu.Domain.Models.WorkflowOverrides;

public class WorkflowOverrideEditData
{
    [JsonProperty("active")] public bool Active { get; set; }
    [JsonProperty("preferenceSettings")] public PreferenceChannels PreferenceSettings { get; set; }
}