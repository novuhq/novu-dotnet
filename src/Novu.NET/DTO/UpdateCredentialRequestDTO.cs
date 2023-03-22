using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class UpdateCredentialRequestDTO
{
    [JsonProperty("webhookUrl")]
    public string WebhookUrl { get; set; }
    
    [JsonProperty("deviceTokens")]
    public string[] DeviceTokens { get; set; }
}