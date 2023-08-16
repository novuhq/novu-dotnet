using Newtonsoft.Json;
using Novu.DTO.Workflows;

namespace Novu.DTO;

/// <summary>
///     see https://docs.novu.co/api/broadcast-event-to-all/
/// </summary>
public class BroadcastMessageRequest
{
    /// <summary>
    ///     The trigger identifier associated for the workflow you wish to send. <see cref="Workflow.Id" />
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    ///     The payload object is used to pass additional custom information that could be used to render the template,
    ///     or perform routing rules based on it. This data will also be available when fetching the notifications
    ///     feed from the API to display certain parts of the UI.
    /// </summary>
    [JsonProperty("payload")]
    public object Payload { get; set; }

    /// <summary>
    ///     This could be used to override provider specific configurations
    /// </summary>
    [JsonProperty("overrides")]
    public object Overrides { get; set; }

    /// <summary>
    ///     A unique identifier for this transaction, we will generated a UUID if not provided.
    /// </summary>
    [JsonProperty("transactionId")]
    public string? TransactionId { get; set; }

    // TODO: actor
}

public class SendBulkRequest
{
    public SendBulkRequest()
    {
    }

    public SendBulkRequest(List<EventTriggerDataDto> events)
    {
        Events = events;
    }

    [JsonProperty("events")] public List<EventTriggerDataDto> Events { get; set; }
}

public class EventTriggerDataDto
{
    [JsonProperty("name")] public string EventName { get; set; }

    [JsonProperty("to")] public EventToDto To { get; set; } = new();

    [JsonProperty("payload")] public object Payload { get; set; } = new();

    [JsonProperty("overrides")] public object Overrides { get; set; } = new();

    /// <summary>
    ///     A unique identifier for this transaction, will generated a UUID if not provided.
    /// </summary>
    [JsonProperty("transactionId")]
    public string? TransactionId { get; set; }

    [JsonProperty("actor")] public string Actor { get; set; }
}