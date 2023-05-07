using Newtonsoft.Json;

namespace Novu.DTO.Topics
{
    public class TopicSubscriberAdditionResponseDto
    {
        [JsonProperty("data")]
        public TopicSubscriberAdditionResponseData Data { get; set; }
    }

    public class TopicSubscriberAdditionResponseData
    {
        [JsonProperty("succeeded")]
        public string[] Succeeded { get; set; }
    }
}