using Newtonsoft.Json;

namespace Novu.DTO.Workflows;

public class WorkflowStatusEditData
{
    [JsonProperty("active")] public bool Active { get; set; }
}