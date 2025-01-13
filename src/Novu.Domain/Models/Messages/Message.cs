using Newtonsoft.Json;
using Novu.Domain.Models.Notifications;

namespace Novu.Domain.Models.Messages;

public class Message
{
    [JsonProperty("_id")] public string Id { get; set; }
    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }
    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }
    [JsonProperty("channels")] public string Channels { get; set; }
    [JsonProperty("template")] public Template Template { get; set; }
    [JsonProperty("subscriber")] public Models.Notifications.Subscriber Subscriber { get; set; }
    [JsonProperty("jobs")] public Job[] Jobs { get; set; }
}