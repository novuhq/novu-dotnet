using Newtonsoft.Json;

namespace Novu.NET.Models;

public class UpdateCredentialRequest
{
    [JsonProperty("webhookUrl")]
    public string WebhookUrl { get; set; }
    
    [JsonProperty("deviceTokens")]
    public string[] DeviceTokens { get; set; }
}