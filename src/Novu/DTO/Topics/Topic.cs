using Newtonsoft.Json;

namespace Novu.DTO.Topics;

public class Topic
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("key")] public string Key { get; set; }
}