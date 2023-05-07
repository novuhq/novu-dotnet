using Newtonsoft.Json;

namespace Novu.DTO
{
    public class TriggerResponseDto
    {
        [JsonProperty("data")]
        public TriggerResponsePayloadDto TriggerResponsePayloadDto { get; set; }
    }
}