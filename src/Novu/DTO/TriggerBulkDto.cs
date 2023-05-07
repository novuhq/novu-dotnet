using System.Collections.Generic;
using Newtonsoft.Json;

namespace Novu.DTO
{
    public class TriggerBulkDto
    {
        [JsonProperty("events")]
        public List<EventTriggerDataDto> Events { get; set; }
    }
}