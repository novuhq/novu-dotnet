using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Changes;

public class ChangesCreateData
{
    /// <summary>
    ///     User defined custom name and provided by the user that will name the Topic created.
    /// </summary>
    [JsonProperty("changeIds")]
    [Required]
    public IList<string> ChangeIds { get; set; }
}