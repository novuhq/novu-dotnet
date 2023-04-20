using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class TriggerBulkDto
{
    [JsonProperty("events")]
    public List<EventTriggerDataDto> Events { get; set; }
}