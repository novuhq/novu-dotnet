using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Environments;

/// <summary>
///     Named with the Novu prefix to avoid the hassle of System.Environment static class collisions
/// </summary>
public class NovuEnvironment
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("name")]
    [Required(AllowEmptyStrings = true)]
    public string Name { get; set; }

    [JsonProperty("_organizationId")]
    [Required(AllowEmptyStrings = true)]
    public string OrganizationId { get; set; }

    [JsonProperty("identifier")]
    [Required(AllowEmptyStrings = true)]
    public string Identifier { get; set; }

    [JsonProperty("apiKeys")] public ICollection<ApiKey> ApiKeys { get; set; }

    [JsonProperty("_parentId")]
    [Required(AllowEmptyStrings = true)]
    public string ParentId { get; set; }
}