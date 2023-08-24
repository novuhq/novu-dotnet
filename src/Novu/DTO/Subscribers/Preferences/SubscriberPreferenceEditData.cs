using Newtonsoft.Json;
using Novu.Models.Subscribers.Preferences;

namespace Novu.DTO.Subscribers.Preferences;

public class SubscriberPreferenceEditData
{
    [JsonProperty("channel")] public Channel Channel { get; set; }
}