using Newtonsoft.Json;
using Novu.Domain.Models.Triggers;

namespace Novu.Domain.Models.Events;

/// <summary>
///     see https://docs.novu.co/platform/topics/#sending-a-notification-to-a-topic
///     Sending a notification to a topic
///     In the section Quick Start it is explained how to trigger a notification for a single subscriber either by
///     passing the subscribers identifier or by passing the full subscriber information if user wants to skip the
///     identify step. Thanks to the topics feature, now it is possible to trigger a notification to all the
///     subscribers assigned to a topic, which helps to have to avoid to list all the subscriber identifiers in
///     the to field of the notification trigger. To trigger a notification to all the subscribers of a topic, Novu's
///     API allows it by doing this:
///     <code>
///     const topicKey = 'posts:comment:12345';
///     
///     await novu.trigger('REPLACE_WITH_EVENT_NAME_FROM_ADMIN_PANEL', {
///         to: [{ type: 'Topic', topicKey: topicKey }],
///         payload: {},
///     });
///  </code>
///     As it is shown, the same call used to send a notification to a single subscriber can be used to send the
///     notification to the subscribers of a topic. The topics feature also added the functionality of sending a
///     notification to multiple topics at the same time, a topic and multiple single subscribers or any combination
///     a user might come with. For that, the to field of the notification trigger can take an array that accepts all
///     those possible destination of the notification:
///     <code>  
///     const topicKey = 'TOPIC-KEY-DEFINED-BY-THE-USER';
///     
///     await novu.trigger('REPLACE_WITH_EVENT_NAME_FROM_ADMIN_PANEL', {
///         to: [
///         { type: 'Topic', topicKey: topicKey },
///         { type: 'Topic', topicKey: 'Another Topic Key' },
///         ],
///         payload: {},
///     });
///   </code>
/// </summary>
public class TopicCreateData
{
    [JsonProperty("name")] public string EventName { get; set; }

    [JsonProperty("to")] public TopicTrigger[] To { get; set; }

    [JsonProperty("payload")] public object Payload { get; set; } = new();

    [JsonProperty("overrides")] public object Overrides { get; set; } = new();

    /// <summary>
    ///     A unique identifier for this transaction, will generated a UUID if not provided.
    /// </summary>
    [JsonProperty("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>
    ///     see https://docs.novu.co/platform/topics/#exclude-actor-from-topic-trigger-event
    ///     To exclude the actor responsible for the action of a triggered topic event, you must add the subscriberId
    ///     of that actor when triggering that event.
    ///     const topicKey = 'posts:comment:12345';
    ///     await novu.trigger('REPLACE_WITH_EVENT_NAME_FROM_ADMIN_PANEL', {
    ///     to: [{ type: 'Topic', topicKey: topicKey }],
    ///     payload: {},
    ///     actor: { subscriberId: 'SUBSCRIBER_ID_OF_ACTOR' },
    ///     });
    ///     Usecase Example
    ///     User X makes a comment, other users (A, B) who've already commented before should get a notification. So,
    ///     when triggering the notification on that topic, you would usually want to exclude User X from receiving a
    ///     notification about their own comment. To do that - you would need to add User X's subscriberId to the
    ///     trigger event.
    /// </summary>
    [JsonProperty("actor")]
    public Actor Actor { get; set; }
}