using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class DeleteResponseDTO
{
    [JsonProperty("data")]
    public DeleteResponseDataDTO Data { get; set; }
}

public class DeleteResponseDataDTO
{
    [JsonProperty("acknowledged")] 
    public bool Acknowledged { get; set; }

    [JsonProperty("status")] 
    public string Status { get; set; }
}