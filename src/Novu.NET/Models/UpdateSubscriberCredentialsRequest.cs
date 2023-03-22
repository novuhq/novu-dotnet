using Newtonsoft.Json;

namespace Novu.NET.Models;

public class UpdateSubscriberCredentialsRequest
{
    [JsonProperty("providerId")]
    public string ProviderId { get; set; }
    
    [JsonProperty("credentials")]
    public string Credentials { get; set; }
}