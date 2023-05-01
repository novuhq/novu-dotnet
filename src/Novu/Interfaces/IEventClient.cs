using Novu.DTO;

namespace Novu.Interfaces;

public interface IEventClient
{
    public Task<TriggerResponseDto> Trigger(EventTriggerDataDto dto);

    public Task<TriggerBulkResponseDto> TriggerBulkAsync(List<EventTriggerDataDto> payload);
    
    public Task<TriggerResponseDto> TriggerBroadcastAsync(EventTriggerDataDto dto);
    
    public Task TriggerCancelAsync(Guid transactionId);
}