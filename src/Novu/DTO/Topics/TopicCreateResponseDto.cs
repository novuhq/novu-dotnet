namespace Novu.DTO.Topics
{
    using Newtonsoft.Json;

    public class TopicCreateResponseDto
    {
        [JsonProperty("data")]
        public TopicData Data { get; set; }
    }

    public class TopicData
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}