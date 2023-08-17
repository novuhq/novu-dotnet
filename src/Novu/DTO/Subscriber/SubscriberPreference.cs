using Newtonsoft.Json;
using Novu.Models.Subscriber.Preferences;

namespace Novu.DTO.Subscriber.Preferences;

public class SubscriberPreference
{
    [JsonProperty("template")] public Template Template { get; set; }
    [JsonProperty("preference")] public Preference Preference { get; set; }
}