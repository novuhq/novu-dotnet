using Newtonsoft.Json;
using Novu.Models.Subscriber.Preferences;

namespace Novu.DTO.Subscriber.Preferences;

public class SubscriberPreferenceEditData
{
    [JsonProperty("channel")] public Channel Channel { get; set; }
}