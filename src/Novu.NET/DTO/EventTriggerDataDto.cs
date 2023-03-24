using Newtonsoft.Json;

namespace Novu.NET.DTO;

public record EventTriggerDataDto
{
    [JsonProperty("to")]
    public EventToDto To { get; set; }
    
    [JsonProperty("payload")]
    public List<KeyValuePair<string, string>> Payload { get; set; }
    
    [JsonProperty("override")]
    public List<KeyValuePair<string, string>>? Overrides { get; set; }
    
    /// <summary>
    /// A unique identifier for this transaction, will generated a UUID if not provided.
    /// </summary>
    [JsonProperty("transactionId")]
    public string? TransactionId { get; set; }
}

public record EventToDto
{
    [JsonProperty("subscriberId")]
    public string SubscriberId { get; set; }
}


