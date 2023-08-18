using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Novu.Models.Workflows.Trigger;

namespace Novu.Models.Triggers;

public class TopicTrigger
{
    public TopicTrigger(string topicKey)
    {
        TopicKey = topicKey;
    }

    public TopicTrigger()
    {
    }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public TriggerTypeEnum Type { get; } = TriggerTypeEnum.Topic;

    [JsonProperty("topicKey")] public string TopicKey { get; set; }
}