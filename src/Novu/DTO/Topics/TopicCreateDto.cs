using Newtonsoft.Json;

namespace Novu.DTO.Topics;

public class TopicCreateDto
{
    /// <summary>
    /// User defined custom key and provided by the user that will be an unique identifier for the Topic created.
    /// </summary>
    [JsonProperty("key")]
    public string Key { get; set; }
    
    /// <summary>
    /// User defined custom name and provided by the user that will name the Topic created.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}

public record RenameTopicRequest(string Name);