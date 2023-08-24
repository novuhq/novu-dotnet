using Newtonsoft.Json;

namespace Novu.NotificationTemplates;

public class UpdateTemplateStatusRequest
{
    [JsonProperty("active")] public bool Active { get; set; }
}