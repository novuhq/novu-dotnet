using Newtonsoft.Json;

namespace Novu.DTO.WorkflowGroup;

public class WorkflowGroupDto
{
    [JsonProperty("name")] public string WorkflowGroupName { get; set; }
}