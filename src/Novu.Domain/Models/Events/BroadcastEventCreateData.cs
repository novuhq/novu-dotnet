using Novu.Domain.Models.Workflows;

namespace Novu.Domain.Models.Events;

/// <summary>
///     see https://docs.novu.co/api/broadcast-event-to-all/
///     <remarks>
///         Broadcast is just an event without the <see cref="EventCreateData.To" />
///     </remarks>
/// </summary>
public class BroadcastEventCreateData : EventData
{
}