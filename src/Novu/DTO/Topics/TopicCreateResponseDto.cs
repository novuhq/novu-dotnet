using Newtonsoft.Json;

namespace Novu.DTO.Topics;

public class TopicCreateResponseDto
{
    [JsonProperty("data")] public Topic Data { get; set; }
}