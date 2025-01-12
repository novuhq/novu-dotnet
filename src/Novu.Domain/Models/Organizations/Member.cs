using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Organizations;

public class Member
{
    [JsonProperty("_id")]
    [Required(AllowEmptyStrings = true)]
    public string Id { get; set; }

    [JsonProperty("_userId")]
    [Required(AllowEmptyStrings = true)]
    public string UserId { get; set; }

    [JsonProperty("user")] public MemberUser MemberUser { get; set; }

    [JsonProperty("roles")]
    public ICollection<MemberRoleEnum> Roles { get; set; }

    [JsonProperty("invite")] public MemberInvite Invite { get; set; }

    [JsonProperty("memberStatus")]
    [JsonConverter(typeof(StringEnumConverter))]
    public MemberStatusEnum MemberStatusEnum { get; set; }

    [JsonProperty("_organizationId")]
    [Required(AllowEmptyStrings = true)]
    public string OrganizationId { get; set; }
}