using Novu.Domain.Models;
using Novu.Domain.Models.Events;
using Refit;

namespace Novu.Clients;

/// <summary>
///     The event client is the only way to send notifications to subscribers. The trigger identifier is used to
///     match the particular workflow associated with it. Additional information can be passed according to the body
///     interface
///     below.
/// </summary>
/// <remarks>
///     The transactionId within Novu is a unique identifier used to ensure the idempotent nature of notification
///     delivery. When you trigger an event to send a notification, you can provide a transactionId. If you do not
///     provide one, Novu will generate a UUID for you. This identifier is particularly useful for preventing the same
///     notification from being sent multiple times in case the trigger event is inadvertently called more than once. By
///     leveraging the transactionId, you can make idempotent requests, which means if the same transactionId is used in
///     another request, Novu’s API will recognize it and will not send the same notification again.
/// </remarks>
public interface IEventClient
{
    /// <summary>
    /// </summary>
    [Post("/events/trigger")]
    Task<NovuResponse<EventAcknowledgeData>> Create([Body] EventCreateData data);

    [Post("/events/trigger")]
    [Obsolete("Use Create with EventCreateData overload")]
    Task<NovuResponse<EventAcknowledgeData>> Trigger([Body] EventCreateData data);

    /// <summary>
    ///     Trigger a notification to all the subscribers assigned to a topic, which helps to have
    ///     to avoid listing all the subscriber identifiers in the to field of the notification trigger
    ///     see https://docs.novu.co/platform/topics#sending-a-notification-to-a-topic
    /// </summary>
    [Post("/events/trigger")]
    Task<NovuResponse<EventAcknowledgeData>> Create([Body] TopicCreateData data);

    [Post("/events/trigger")]
    [Obsolete("Use Create with EventCreateData overload")]
    Task<NovuResponse<EventAcknowledgeData>> Trigger([Body] TopicCreateData data);

    /// <summary>
    /// </summary>
    [Post("/events/trigger/bulk")]
    Task<NovuResponse<IEnumerable<EventAcknowledgeData>>> Create([Body] BulkEventCreateData data);

    [Post("/events/trigger/bulk")]
    [Obsolete("Use Create with BulkEventCreateData overload")]
    Task<NovuResponse<IEnumerable<EventAcknowledgeData>>> CreateBulk([Body] BulkEventCreateData data);

    [Post("/events/trigger/bulk")]
    [Obsolete("Use Create with BulkEventCreateData overload")]
    Task<NovuResponse<IEnumerable<EventAcknowledgeData>>> Trigger([Body] BulkEventCreateData data);

    /// <summary>
    ///     Trigger a broadcast event to all existing subscribers, could be used to send announcements, etc. In the
    ///     future could be used to trigger events to a subset of subscribers based on defined filter
    /// </summary>
    /// <remarks>
    ///     A broadcast with fail with a 500 error if the workflow and at least one step is enabled.
    /// </remarks>
    [Post("/events/trigger/broadcast")]
    Task<NovuResponse<EventAcknowledgeData>> Create([Body] BroadcastEventCreateData dto);

    [Post("/events/trigger/broadcast")]
    [Obsolete("Use Create with BroadcastEventCreateData overload")]
    Task<NovuResponse<EventAcknowledgeData>> CreateBroadcast([Body] BroadcastEventCreateData dto);

    [Post("/events/trigger/broadcast")]
    [Obsolete("Use Create with BroadcastEventCreateData overload")]
    Task<NovuResponse<EventAcknowledgeData>> Trigger([Body] BroadcastEventCreateData dto);

    [Delete("/events/trigger/{transactionId}")]
    Task Cancel(string transactionId);
}