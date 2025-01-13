using Newtonsoft.Json;

namespace Novu.Domain.Models.Notifications;

public class Template
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("triggers")] public List<Trigger> Triggers { get; set; }


    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("variables")] public List<object> Variables { get; set; }

    [JsonProperty("content")] public string Content { get; set; }

    [JsonProperty("contentType")] public string ContentType { get; set; }

    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }

    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }

    [JsonProperty("_creatorId")] public string CreatorId { get; set; }

    [JsonProperty("_feedId")] public object FeedId { get; set; }

    [JsonProperty("_layoutId")] public object LayoutId { get; set; }

    [JsonProperty("deleted")] public bool Deleted { get; set; }

    [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }
}