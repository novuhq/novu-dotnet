using Novu.DTO;

namespace Novu.Interfaces;

public interface IEventClient
{
  public Task<TriggerResponseDto> Trigger(EventTriggerDataDto dto);

  public Task<TriggerBulkResponseDto> TriggerBulkAsync(List<EventTriggerDataDto> payload);

  public Task<TriggerResponseDto> TriggerBroadcastAsync(EventTriggerDataDto dto);

  public Task TriggerCancelAsync(Guid transactionId);

  /// <summary>
  /// Trigger a notification to a specific Topic of Subscribers.
  /// </summary>
  /// <param name="dto">
  /// <see cref="EventTriggerDataDto"/>
  /// </param>
  /// <returns></returns>
  public Task<TriggerResponseDto> TriggerTopicAsync(EventTopicTriggerDto dto);
}