using Newtonsoft.Json;
using Novu.Models.Workflows.Trigger;

namespace Novu.Models.Notifications;

public class Trigger
{
    [JsonProperty("type")] public TriggerTypeEnum Type { get; set; }

    [JsonProperty("identifier")] public string Identifier { get; set; }

    [JsonProperty("variables")] public List<object> Variables { get; set; }

    [JsonProperty("subscriberVariables")] public List<object> SubscriberVariables { get; set; }
}