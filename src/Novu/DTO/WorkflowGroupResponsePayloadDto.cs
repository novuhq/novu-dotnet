using Newtonsoft.Json;

namespace Novu.DTO
{
    public class WorkflowGroupResponsePayloadDto
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("_environmentId")]
        public string EnvironmentId { get; set; }
        [JsonProperty("_organizationId")]
        public string OrganizationId { get; set; }
        [JsonProperty("_parentId")]
        public string ParentId { get; set; }
    }

    public class WorkflowGroupSingleResponseDto
    {
        [JsonProperty("data")]
        public WorkflowGroupResponsePayloadDto PayloadDto { get; set; }
    }

    public class WorkflowGroupBulkResponseDto
    {
        [JsonProperty("data")]
        public List<WorkflowGroupResponsePayloadDto> PayloadDtos { get; set; }
    }
}
