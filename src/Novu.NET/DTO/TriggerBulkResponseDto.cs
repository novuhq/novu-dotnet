using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class TriggerBulkResponseDto
{
    [JsonProperty("data")]
    public List<TriggerResponsePayloadDto> PayloadDtos { get; set; }
}