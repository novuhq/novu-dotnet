using Newtonsoft.Json;
using Novu.Domain.Models.Workflows;

namespace Novu.Domain.Models.Events;

/// <summary>
///     see https://docs.novu.co/api-reference/events/events-controller_trigger
///     see https://v0.x-docs.novu.co/api-reference/events/trigger-event
/// </summary>
public abstract class EventData
{
    /// <summary>
    ///     The trigger identifier associated for the workflow you wish to send. <see cref="Workflow.Id" />
    /// </summary>
    [JsonProperty("name")]
    public string EventName { get; set; }

    /// <summary>
    ///     The payload object is used to pass additional custom information that could be used to render the template,
    ///     or perform routing rules based on it. This data will also be available when fetching the notifications
    ///     feed from the API to display certain parts of the UI.
    ///     <remarks>serialize as an empty object if nothing</remarks>
    /// </summary>
    [JsonProperty("payload")]
    public object Payload { get; set; } = new();

    /// <summary>
    ///     This could be used to override provider-specific configurations
    ///     <remarks>serialize as an empty object if nothing</remarks>
    /// </summary>
    [JsonProperty("overrides")]
    public object Overrides { get; set; } = new();

    /// <summary>
    ///     The transactionId within Novu is a unique identifier used to ensure the idempotent nature of notification
    ///     delivery. When you trigger an event to send a notification, you can provide a transactionId. If you do not
    ///     provide one, Novu will generate a UUID for you. This identifier is particularly useful for preventing the same
    ///     notification from being sent multiple times in case the trigger event is inadvertently called more than once. By
    ///     leveraging the transactionId, you can make idempotent requests, which means if the same transactionId is used in
    ///     another request, Novu’s API will recognize it and will not send the same notification again.
    /// </summary>
    [JsonProperty("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>
    ///     If a new actor object is provided, we will create a new subscriber in our system
    ///     see https://docs.novu.co/api-reference/events/events-controller_trigger#request-body
    ///     see https://docs.novu.co/platform/topics/#exclude-actor-from-topic-trigger-event
    ///     To exclude the actor responsible for the action of a triggered topic event, you must add the subscriberId
    ///     of that actor when triggering that event.
    ///     <code>
    ///      const topicKey = 'posts:comment:12345';
    ///      await novu.trigger(
    ///          'REPLACE_WITH_EVENT_NAME_FROM_ADMIN_PANEL',
    ///          {
    ///              to: [
    ///                  { type: 'Topic', topicKey: topicKey }
    ///              ],
    ///              payload: {},
    ///              actor: {
    ///                  subscriberId: 'SUBSCRIBER_ID_OF_ACTOR'
    ///              },
    ///          });
    ///      </code>
    ///     <example>
    ///         Usecase Example:
    ///         User X makes a comment, other users (A, B) who've already commented before should get a notification. So,
    ///         when triggering the notification on that topic, you would usually want to exclude User X from receiving a
    ///         notification about their own comment. To do that - you would need to add User X's subscriberId to the
    ///         trigger event.
    ///     </example>
    ///     <remarks>
    ///         Actor as string was removed from 0.7.0. Upgrade:
    ///         From:
    ///         <code>
    ///             Actor = "subscriberId"
    ///         </code>
    ///         To:
    ///         <code>
    ///             Actor = new Actor { SubscriberId = "subscriberId" }
    ///         </code>
    ///         Upgrade to
    ///     </remarks>
    /// </summary>
    [JsonProperty("actor")]
    public Actor Actor { get; set; }

    /// <summary>
    ///     It is used to specify a tenant context during trigger event. Existing tenants will be updated
    ///     with the provided details.
    ///     see https://docs.novu.co/api-reference/events/events-controller_trigger#request-body
    /// </summary>
    [JsonProperty("tenant")]
    public Tenant Tenant { get; set; }
}