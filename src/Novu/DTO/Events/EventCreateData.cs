using Newtonsoft.Json;
using Novu.Models.Events;

namespace Novu.DTO.Events;

public class EventCreateData
{
    [JsonProperty("name")] public string EventName { get; set; }

    [JsonProperty("to")] public EventTo To { get; set; } = new();

    [JsonProperty("payload")] public object Payload { get; set; } = new();

    [JsonProperty("overrides")] public object Overrides { get; set; } = new();

    /// <summary>
    ///     A unique identifier for this transaction, will generated a UUID if not provided.
    /// </summary>
    [JsonProperty("transactionId")]
    public string? TransactionId { get; set; }

    [JsonProperty("actor")] public string Actor { get; set; }
}