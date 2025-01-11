using Newtonsoft.Json;

namespace Novu.Domain.Models.Events;

public class BulkEventCreateData
{
    public BulkEventCreateData()
    {
    }

    public BulkEventCreateData(List<EventCreateData> events)
    {
        Events = events;
    }

    [JsonProperty("events")] public List<EventCreateData> Events { get; set; }
}