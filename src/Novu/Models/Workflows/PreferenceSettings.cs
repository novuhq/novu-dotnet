using Newtonsoft.Json;

namespace Novu.Models.Workflows;

/// <summary>
///     Channel preference settings
///     see https://docs.novu.co/api/create-workflow/ (expand preference settings)
/// </summary>
public class PreferenceChannels
{
    [JsonProperty("email")] public bool Email { get; set; }

    [JsonProperty("sms")] public bool Sms { get; set; }

    [JsonProperty("chat")] public bool Chat { get; set; }

    [JsonProperty("push")] public bool Push { get; set; }

    [JsonProperty("in_app")] public bool InApp { get; set; }
}