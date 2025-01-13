using Newtonsoft.Json;

namespace Novu.Domain.Models.Subscribers.Preferences;

public class SubscriberPreference
{
    [JsonProperty("template")] public Template Template { get; set; }
    [JsonProperty("preference")] public Preference Preference { get; set; }
}