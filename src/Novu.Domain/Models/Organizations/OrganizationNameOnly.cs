using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Organizations;

public class OrganizationNameOnly
{
    [JsonProperty("name")]
    [Required(AllowEmptyStrings = true)]
    public string Name { get; set; }
}