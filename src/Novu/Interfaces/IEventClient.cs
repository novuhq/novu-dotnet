using Novu.DTO;
using Refit;

namespace Novu.Interfaces;

public interface IEventClient
{
    [Post("/events/trigger")]
    Task<TriggerResponseDto> Trigger([Body]EventTriggerDataDto dto);

    [Post("/events/trigger/bulk")]
    Task<TriggerBulkResponseDto> TriggerBulkAsync([Body] List<EventTriggerDataDto> payload);

    [Post("/events/trigger/broadcast")]
    Task<TriggerResponseDto> TriggerBroadcastAsync([Body]EventTriggerDataDto dto);

    [Delete("/events/trigger/{transactionId}")]
    Task TriggerCancelAsync(Guid transactionId);

    [Post("/events/trigger")]
    Task<TriggerResponseDto> TriggerTopicAsync(EventTopicTriggerDto dto);
}