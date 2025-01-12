using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Environments;

public class ApiKey
{
    [JsonProperty("key")]
    [Required(AllowEmptyStrings = true)]
    public string Key { get; set; }

    [JsonProperty("_userId")]
    [Required(AllowEmptyStrings = true)]
    public string UserId { get; set; }
}