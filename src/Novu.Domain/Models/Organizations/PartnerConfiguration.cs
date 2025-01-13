using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Organizations;

public class PartnerConfiguration
{
    [JsonProperty("projectIds")] public ICollection<string> ProjectIds { get; set; }

    [JsonProperty("accessToken")]
    [Required(AllowEmptyStrings = true)]
    public string AccessToken { get; set; }

    [JsonProperty("configurationId")]
    [Required(AllowEmptyStrings = true)]
    public string ConfigurationId { get; set; }

    [JsonProperty("teamId")] public string TeamId { get; set; }

    [JsonProperty("partnerType")]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public PartnerTypeEnum PartnerTypeEnum { get; set; }
}