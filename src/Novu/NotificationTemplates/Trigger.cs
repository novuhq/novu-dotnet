using Newtonsoft.Json;

namespace Novu.NotificationTemplates;

public class Trigger
{
    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("identifier")] public string Identifier { get; set; }

    [JsonProperty("variables")] public Variable[] Variables { get; set; }

    [JsonProperty("subscriberVariables")] public Variable[] SubscriberVariables { get; set; }
}