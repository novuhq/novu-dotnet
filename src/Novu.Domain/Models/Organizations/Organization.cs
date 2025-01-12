using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Organizations;

public class Organization
{
    [JsonProperty("name")]
    [Required(AllowEmptyStrings = true)]
    public string Name { get; set; }

    [JsonProperty("logo")] public string Logo { get; set; }

    [JsonProperty("branding")] [Required] public Branding Branding { get; set; } = new();

    [JsonProperty("partnerConfigurations")]
    public ICollection<PartnerConfiguration> PartnerConfigurations { get; set; }
}