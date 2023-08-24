    using Newtonsoft.Json;

    namespace Novu.DTO.WorkflowGroups;

public class WorkflowGroupCreateData
{
    [JsonProperty("name")] public string Name { get; set; }
}