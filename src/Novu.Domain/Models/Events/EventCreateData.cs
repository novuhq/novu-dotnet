using Newtonsoft.Json;

namespace Novu.Domain.Models.Events;

public class EventCreateData : EventData
{
    [JsonProperty("to")] public EventTo To { get; set; } = new();
}