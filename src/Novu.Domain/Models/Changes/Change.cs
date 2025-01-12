using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Changes;

public class Change
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("_creatorId")]
    [Required(AllowEmptyStrings = true)]
    public string CreatorId { get; set; }

    [JsonProperty("_environmentId")]
    [Required(AllowEmptyStrings = true)]
    public string EnvironmentId { get; set; }

    [JsonProperty("_organizationId")]
    [Required(AllowEmptyStrings = true)]
    public string OrganizationId { get; set; }

    [JsonProperty("_entityId")]
    [Required(AllowEmptyStrings = true)]
    public string EntityId { get; set; }

    [JsonProperty("enabled")] public bool Enabled { get; set; }

    [JsonProperty("type")]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ChangeEnum? Type { get; set; }

    [JsonProperty("change")] [Required] public ChangeItem[] Changes { get; set; } = Array.Empty<ChangeItem>();

    [JsonProperty("createdAt")]
    [Required(AllowEmptyStrings = true)]
    public string CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    [Required(AllowEmptyStrings = true)]
    public string UpdatedAt { get; set; }

    [JsonProperty("_parentId")] public string ParentId { get; set; }
}