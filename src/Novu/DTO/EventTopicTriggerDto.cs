using Newtonsoft.Json;

namespace Novu.DTO
{
    public class EventTopicTriggerDto
    {
        /// <summary>
        /// Name of the Event to Trigger.
        ///
        /// <example>new-comment</example>
        /// </summary>
        [JsonProperty("name")]
        public string EventName { get; set; }
    
        /// <summary>
        /// Topic to Trigger
        /// </summary>
        [JsonProperty("to")]
        public EventTopicDto Topic { get; set; } = new EventTopicDto();
        
        /// <summary>
        /// Payload to send to the Subscribers
        /// </summary>
        [JsonProperty("payload")]
        public object Payload { get; set; } = new object();
        
        /// <summary>
        /// Overrides for the template and other Novu settings
        /// </summary>
        [JsonProperty("overrides")]
        public object Overrides { get; set; }
    }
    
    public class EventTopicDto
    {
        /// <summary>
        /// Topic Key
        ///
        /// <example>
        /// post:123:comments
        /// </example>
        /// </summary>
        [JsonProperty("topicKey")]
        public string TopicKey { get; set; }
        
        /// <summary>
        /// Type of Subscriber payload. Defaults to Topic which
        /// shouldn't change unless there is a change on the Novu
        /// API.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = "Topic";
    }
}