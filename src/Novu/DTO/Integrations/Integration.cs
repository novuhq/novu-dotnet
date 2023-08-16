using Newtonsoft.Json;
using Novu.Models.Integrations;

namespace Novu.DTO.Integrations;

public class Integration
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }

    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("identifier")] public string Identifier { get; set; }

    [JsonProperty("providerId")] public string ProviderId { get; set; }

    [JsonProperty("channel")] public string Channel { get; set; }

    [JsonProperty("credentials")] public Credentials Credentials { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("deleted")] public bool Deleted { get; set; }

    [JsonProperty("deletedAt")] public string DeletedAt { get; set; }

    [JsonProperty("deletedBy")] public string DeletedBy { get; set; }
}