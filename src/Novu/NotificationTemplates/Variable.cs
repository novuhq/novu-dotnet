using Newtonsoft.Json;

namespace Novu.NotificationTemplates;

public class Variable
{
    [JsonProperty("name")] public string Name { get; set; }
}