using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows;

public class WorkflowStatusEditData
{
    [JsonProperty("active")] public bool Active { get; set; }
}