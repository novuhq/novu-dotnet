using Newtonsoft.Json;

namespace Novu.DTO.Topics
{
    public class TopicRenameRequestDto
    {
        /// <summary>
        /// New name of the Topic.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}