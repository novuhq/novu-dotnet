using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Organizations;

public class MemberInvite
{
    [JsonProperty("email")]
    [Required(AllowEmptyStrings = true)]
    public string Email { get; set; }

    [JsonProperty("token")]
    [Required(AllowEmptyStrings = true)]
    public string Token { get; set; }

    [JsonProperty("invitationDate")]
    [Required(AllowEmptyStrings = true)]
    public DateTimeOffset InvitationDate { get; set; }

    [JsonProperty("answerDate")] public DateTimeOffset AnswerDate { get; set; }

    [JsonProperty("_inviterId")]
    [Required(AllowEmptyStrings = true)]
    public string InviterId { get; set; }
}