using Newtonsoft.Json;
using Novu.Models.Subscribers.Preferences;

namespace Novu.DTO.Subscribers.Preferences;

public class SubscriberPreference
{
    [JsonProperty("template")] public Template Template { get; set; }
    [JsonProperty("preference")] public Preference Preference { get; set; }
}