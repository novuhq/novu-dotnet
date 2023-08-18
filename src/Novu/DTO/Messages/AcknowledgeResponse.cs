using Newtonsoft.Json;

namespace Novu.DTO.Messages;

/// <summary>
///     see https://docs.novu.co/api/delete-message/
/// </summary>
public class AcknowledgeResponse
{
    [JsonProperty("acknowledged")] public bool Acknowledged { get; set; }
    [JsonProperty("status")] public string Status { get; set; }
}