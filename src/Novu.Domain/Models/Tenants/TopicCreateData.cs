using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Tenants;

public class TenantCreateData
{
    [JsonProperty("identifier")]
    [Required(AllowEmptyStrings = true)]
    public string Identifier { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("data")] public object Data { get; set; }
}