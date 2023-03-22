using Newtonsoft.Json;

namespace Novu.NET.DTO;

public partial class DeleteResponseDTO
{
    [JsonProperty("acknowledged")]
    public bool Acknowledged { get; set; }
    
    [JsonProperty("status")]
    public string Status { get; set; }
}