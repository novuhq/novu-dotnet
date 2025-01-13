using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Changes;

public class ChangeItem
{
    [JsonProperty("op")] public string Op { get; set; }

    [JsonProperty("path")] public IList<string> Paths { get; set; }

    [JsonProperty("val")]
    [Required(AllowEmptyStrings = true)]
    public string Val { get; set; }
}