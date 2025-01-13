using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Organizations;

public class MemberUser
{
    [JsonProperty("_id")]
    [Required(AllowEmptyStrings = true)]
    public string Id { get; set; }

    [JsonProperty("firstName")]
    [Required(AllowEmptyStrings = true)]
    public string FirstName { get; set; }

    [JsonProperty("lastName")]
    [Required(AllowEmptyStrings = true)]
    public string LastName { get; set; }

    [JsonProperty("email")]
    [Required(AllowEmptyStrings = true)]
    public string Email { get; set; }
}