    using Newtonsoft.Json;

    namespace Novu.Domain.Models.WorkflowGroups;

public class WorkflowGroupCreateData
{
    [JsonProperty("name")] public string Name { get; set; }
}