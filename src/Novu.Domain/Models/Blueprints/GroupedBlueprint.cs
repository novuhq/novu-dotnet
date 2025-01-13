using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Blueprints;

public class GroupedBlueprint
{
    [JsonProperty("general")]
    [Required]
    public ICollection<Blueprint> General { get; set; } = new Collection<Blueprint>();

    [JsonProperty("popular")] [Required] public GroupedBlueprint? Popular { get; set; }
}