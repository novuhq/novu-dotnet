using Novu.DTO;
using Novu.DTO.Triggers;
using Refit;

namespace Novu.Interfaces;

public interface IEventClient
{
    [Post("/events/trigger")]
    Task<TriggerResponseDto> Trigger([Body] EventTriggerDataDto dto);

    /// <summary>
    ///     Trigger a notification to all the subscribers assigned to a topic, which helps to have
    ///     to avoid to list all the subscriber identifiers in the to field of the notification trigger
    /// 
    ///     see https://docs.novu.co/platform/topics#sending-a-notification-to-a-topic
    /// </summary>
    [Post("/events/trigger")]
    Task<TriggerResponseDto> Trigger([Body] TopicTriggerDataDto dto);

    [Post("/events/trigger/bulk")]
    Task<TriggerBulkResponseDto> TriggerBulkAsync([Body] SendBulkRequest payload);

    /// <summary>
    ///     Trigger a broadcast event to all existing subscribers, could be used to send announcements, etc. In the
    ///     future could be used to trigger events to a subset of subscribers based on defined filter
    /// </summary>
    /// <remarks>
    ///     A broadcast with fail with a 500 error if the workflow and at least one step is enabled.
    /// </remarks>
    [Post("/events/trigger/broadcast")]
    Task<TriggerResponseDto> TriggerBroadcastAsync([Body] BroadcastMessageRequest dto);

    [Delete("/events/trigger/{transactionId}")]
    Task TriggerCancelAsync(string transactionId);

    [Post("/events/trigger")]
    Task<TriggerResponseDto> TriggerTopicAsync(EventTopicTriggerDto dto);
}