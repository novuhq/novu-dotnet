using Newtonsoft.Json;

namespace Novu.DTO;

public class TriggerBulkResponseDto
{
    [JsonProperty("data")]
    public List<TriggerResponsePayloadDto> PayloadDtos { get; set; }
}