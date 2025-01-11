using Newtonsoft.Json;

namespace Novu.Domain.Models.WorkflowGroups;

public class WorkflowGroup
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }

    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }

    [JsonProperty("_parentId")] public string ParentId { get; set; }
}