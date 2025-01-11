using Newtonsoft.Json;
using Novu.Domain.Models.Workflows;

namespace Novu.Domain.Models.Events;

/// <summary>
///     see https://docs.novu.co/api/broadcast-event-to-all/
/// </summary>
public class BroadcastEventCreateData
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