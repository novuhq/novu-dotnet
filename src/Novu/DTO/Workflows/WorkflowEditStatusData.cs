using Newtonsoft.Json;

namespace Novu.DTO.Workflows;

public class WorkflowEditStatusData
{
    [JsonProperty("active")] public bool Active { get; set; }
}