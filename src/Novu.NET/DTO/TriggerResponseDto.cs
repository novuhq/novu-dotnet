using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class TriggerResponseDto
{
    [JsonProperty("data")]
    public TriggerResponsePayloadDto TriggerResponsePayloadDto { get; set; }
}