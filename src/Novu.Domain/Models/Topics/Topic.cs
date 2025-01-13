using Newtonsoft.Json;

namespace Novu.Domain.Models.Topics;

public class Topic
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }

    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }

    [JsonProperty("key")] public string Key { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("subscribers")] public string[] Subscribers { get; set; }
}