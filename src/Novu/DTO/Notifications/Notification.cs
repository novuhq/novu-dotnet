using Newtonsoft.Json;
using Novu.Models.Notifications;
using Novu.Models.Subscriber.Preferences;
using Template = Novu.Models.Notifications.Template;

namespace Novu.DTO.Notifications;

public class Notification
{
    [JsonProperty("_id")] public string Id { get; set; }
    [JsonProperty("_templateId")] public string TemplateId { get; set; }
    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }
    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }
    [JsonProperty("transactionId")] public string TransactionId { get; set; }
    [JsonProperty("channels")] public ChannelTypeEnum[] Channels { get; set; }
    [JsonProperty("template")] public Template Template { get; set; }
    [JsonProperty("subscriber")] public Models.Notifications.Subscriber Subscriber { get; set; }
    [JsonProperty("jobs")] public Job[] Jobs { get; set; }
}