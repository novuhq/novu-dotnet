using Newtonsoft.Json;

namespace Novu.DTO;

public record BroadcastMessageRequest(string Name ,object Payload, string? TransactionId);

public record SendBulkRequest(List<EventTriggerDataDto> Events);
public class EventTriggerDataDto
{
    [JsonProperty("name")]
    public string EventName { get; set; }
    
    [JsonProperty("to")]
    public EventToDto To { get; set; } = new();

    [JsonProperty("payload")]
    public object Payload { get; set; } = new();

    [JsonProperty("override")] public List<object>? Overrides { get; set; }
    
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


