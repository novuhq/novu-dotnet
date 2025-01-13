using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Organizations;

public class BrandingEditData
{
    // [JsonProperty("direction")]
    // [JsonConverter(typeof(StringEnumConverter))]
    // public DirectionEnum DirectionEnum { get; set; }

    [JsonProperty("logo")]
    [Required(AllowEmptyStrings = true)]
    public string Logo { get; set; }

    [JsonProperty("color")]
    [Required(AllowEmptyStrings = true)]
    public string Color { get; set; }

    [JsonProperty("fontColor")]
    [Required(AllowEmptyStrings = true)]
    public string FontColor { get; set; }

    [JsonProperty("contentBackground")]
    [Required(AllowEmptyStrings = true)]
    public string ContentBackground { get; set; }

    [JsonProperty("fontFamily")] public string FontFamily { get; set; }
}