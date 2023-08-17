using Newtonsoft.Json;

namespace Novu.Models.Subscriber.Preferences;

public class Channels
{
    [JsonProperty("in_app")] public bool? InApp { get; set; }
    [JsonProperty("email")] public bool? Email { get; set; }
    [JsonProperty("sms")] public bool? Sms { get; set; }
    [JsonProperty("chat")] public bool? Chat { get; set; }
    [JsonProperty("push")] public bool? Push { get; set; }
}