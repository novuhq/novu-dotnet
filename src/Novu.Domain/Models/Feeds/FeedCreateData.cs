using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Feeds;

public class FeedCreateData
{

    /// <summary>
    ///     User defined custom name and provided by the user that will name the Topic created.
    /// </summary>
    [JsonProperty("name")]
    [Required(AllowEmptyStrings = true)]
    public string Name { get; set; }
}