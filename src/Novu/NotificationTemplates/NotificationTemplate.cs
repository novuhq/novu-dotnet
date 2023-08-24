using Newtonsoft.Json;

namespace Novu.NotificationTemplates;

public class NotificationTemplate
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }

    [JsonProperty("_creatorId")] public string CreatorId { get; set; }

    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }

    [JsonProperty("_notificationGroupId")] public string NotificationGroupId { get; set; }

    [JsonProperty("_parentId")] public string ParentId { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("draft")] public bool Draft { get; set; }

    [JsonProperty("critical")] public bool Critical { get; set; }

    [JsonProperty("tags")] public string[] Tags { get; set; }

    [JsonProperty("preferenceSettings")] public PreferenceSettings PreferenceSettings { get; set; }

    [JsonProperty("steps")] public Step[] Steps { get; set; }

    [JsonProperty("triggers")] public Trigger[] Triggers { get; set; }

    [JsonProperty("deleted")] public bool Deleted { get; set; }

    [JsonProperty("deletedAt")] public DateTime DeletedAt { get; set; }

    [JsonProperty("deletedBy")] public string DeletedBy { get; set; }

    [JsonProperty("notificationGroup")] public NotificationGroup NotificationGroup { get; set; }
}