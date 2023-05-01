using Newtonsoft.Json;

namespace Novu.DTO;

public class DeleteResponseDto
{
    [JsonProperty("data")]
    public DeleteResponseDataDto Data { get; set; }
}

public class DeleteResponseDataDto
{
    [JsonProperty("acknowledged")] 
    public bool Acknowledged { get; set; }

    [JsonProperty("status")] 
    public string Status { get; set; }
}