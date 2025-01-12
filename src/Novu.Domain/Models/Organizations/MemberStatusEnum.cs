using System.Runtime.Serialization;

namespace Novu.Domain.Models.Organizations;

public enum MemberStatusEnum
{
    [EnumMember(Value = @"new")] New = 0,

    [EnumMember(Value = @"active")] Active = 1,

    [EnumMember(Value = @"invited")] Invited = 2,
}