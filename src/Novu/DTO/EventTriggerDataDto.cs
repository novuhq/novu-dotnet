using System.Collections.Generic;
using Newtonsoft.Json;

namespace Novu.DTO
{
    public class EventTriggerDataDto
    {
        [JsonProperty("name")]
        public string EventName { get; set; }
    
        [JsonProperty("to")]
        public EventToDto To { get; set; } = new EventToDto();

        [JsonProperty("payload")] 
        public object Payload { get; set; } = new object();

        [JsonProperty("override")] 
        public List<object> Overrides { get; set; }
    
        /// <summary>
        /// A unique identifier for this transaction, will generated a UUID if not provided.
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }
    }

    public class EventToDto
    {
        [JsonProperty("subscriberId")]
        public string SubscriberId { get; set; }
    }
}


