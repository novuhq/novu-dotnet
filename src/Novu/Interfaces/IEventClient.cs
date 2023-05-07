using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Novu.DTO;

namespace Novu.Interfaces
{
    public interface IEventClient
    {
        Task<TriggerResponseDto> Trigger(EventTriggerDataDto dto);

        Task<TriggerBulkResponseDto> TriggerBulkAsync(List<EventTriggerDataDto> payload);

        Task<TriggerResponseDto> TriggerBroadcastAsync(EventTriggerDataDto dto);

        Task TriggerCancelAsync(Guid transactionId);

        /// <summary>
        /// Trigger a notification to a specific Topic of Subscribers.
        /// </summary>
        /// <param name="dto">
        /// <see cref="EventTriggerDataDto"/>
        /// </param>
        /// <returns></returns>
        Task<TriggerResponseDto> TriggerTopicAsync(EventTopicTriggerDto dto);
    }
}