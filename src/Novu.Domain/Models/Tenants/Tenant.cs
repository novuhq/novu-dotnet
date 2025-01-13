using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Tenants;

public class Tenant
{
    [JsonProperty("_id")]
    [Required(AllowEmptyStrings = true)]
    public string Id { get; set; }

    [JsonProperty("identifier")]
    [Required(AllowEmptyStrings = true)]
    public string Identifier { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    //[JsonProperty("data")] public object Data { get; set; }

    [JsonProperty("_environmentId")]
    [Required(AllowEmptyStrings = true)]
    public string EnvironmentId { get; set; }

    [JsonProperty("createdAt")]
    [Required(AllowEmptyStrings = true)]
    public string CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    [Required(AllowEmptyStrings = true)]
    public string UpdatedAt { get; set; }
}