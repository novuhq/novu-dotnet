using Newtonsoft.Json;

namespace Novu.Domain.Models.Events;

public class EventAcknowledgeData : NovuAcknowledgeData
{
    /// <summary>
    ///     The transactionId within Novu is a unique identifier used to ensure the idempotent nature of notification
    ///     delivery. When you trigger an event to send a notification, you can provide a transactionId. If you do not
    ///     provide one, Novu will generate a UUID for you. This identifier is particularly useful for preventing the same
    ///     notification from being sent multiple times in case the trigger event is inadvertently called more than once. By
    ///     leveraging the transactionId, you can make idempotent requests, which means if the same transactionId is used in
    ///     another request, Novu’s API will recognize it and will not send the same notification again.
    /// </summary>
    [JsonProperty("transactionId")] public string TransactionId { get; set; }
}