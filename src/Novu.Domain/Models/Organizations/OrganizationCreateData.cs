using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Organizations;

public class OrganizationCreateData
{
    [JsonProperty("name")]
    [Required(AllowEmptyStrings = true)]
    public string Name { get; set; }

    [JsonProperty("logo")] public string Logo { get; set; }

    [JsonProperty("jobTitle")]
    [JsonConverter(typeof(StringEnumConverter))]
    public JobTitleEnum JobTitleEnum { get; set; }

    [JsonProperty("domain")] public string Domain { get; set; }

    [JsonProperty("productUseCases")] public object ProductUseCases { get; set; }
}