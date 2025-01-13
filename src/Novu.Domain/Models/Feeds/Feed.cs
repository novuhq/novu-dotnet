using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Feeds;

public class Feed
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("name")]
    [Required(AllowEmptyStrings = true)]
    public string Name { get; set; }

    [JsonProperty("identifier")]
    [Required(AllowEmptyStrings = true)]
    public string Identifier { get; set; }

    [JsonProperty("_environmentId")]
    [Required(AllowEmptyStrings = true)]
    public string EnvironmentId { get; set; }

    [JsonProperty("_organizationId")]
    [Required(AllowEmptyStrings = true)]
    public string OrganizationId { get; set; }

    [JsonProperty("_additionalProperties")]
    public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
}