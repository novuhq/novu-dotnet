using Newtonsoft.Json;

namespace Novu.DTO
{
    public class WorkflowGroupDto
    {
        [JsonProperty("name")]
        public string WorkflowGroupName { get; set; }
    }
}
