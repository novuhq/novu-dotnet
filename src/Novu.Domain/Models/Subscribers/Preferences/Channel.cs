using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Subscribers.Preferences;

public class Channel
{
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public ChannelTypeEnum Type { get; set; }

    [JsonProperty("enabled")] public bool Enabled { get; set; }
}