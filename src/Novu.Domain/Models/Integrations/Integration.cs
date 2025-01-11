using Newtonsoft.Json;

namespace Novu.Domain.Models.Integrations;

public class Integration
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }

    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }

    /// <summary>
    ///     Display name of the integration
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    ///     Unique name of the provider, and by conventions usually prefixed by the provider
    /// </summary>
    [JsonProperty("identifier")]
    public string Identifier { get; set; }

    /// <summary>
    ///     Always unique by provider id
    /// </summary>
    /// <remarks>
    ///     Until an enum strategy is implemented see https://github.com/novuhq/novu/blob/next/libs/shared/src/consts/providers/provider.enum.ts
    /// </remarks>
    [JsonProperty("providerId")]
    public string ProviderId { get; set; }

    [JsonProperty("channel")] public string Channel { get; set; }

    [JsonProperty("credentials")] public Credentials Credentials { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    /// <summary>
    ///     A deleted integration can only be PUT and not POSTed on
    /// </summary>
    [JsonProperty("deleted")]
    public bool Deleted { get; set; }

    [JsonProperty("deletedAt")] public string DeletedAt { get; set; }

    [JsonProperty("deletedBy")] public string DeletedBy { get; set; }
}