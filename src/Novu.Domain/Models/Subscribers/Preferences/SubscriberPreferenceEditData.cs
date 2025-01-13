using Newtonsoft.Json;

namespace Novu.Domain.Models.Subscribers.Preferences;

public class SubscriberPreferenceEditData
{
    [JsonProperty("channel")] public Channel Channel { get; set; }
}