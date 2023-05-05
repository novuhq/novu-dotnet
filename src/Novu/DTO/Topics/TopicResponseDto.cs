using Newtonsoft.Json;

namespace Novu.DTO.Topics;

public class TopicResponseDto
{
    [JsonProperty("data")]
    public TopicDto Data { get; set; }
}