using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class UpdateSubscriberCredentialsRequestDTO
{
    [JsonProperty("providerId")]
    public string ProviderId { get; set; }
    
    [JsonProperty("credentials")]
    public string Credentials { get; set; }
}