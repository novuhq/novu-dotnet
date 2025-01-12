using System.Runtime.Serialization;

namespace Novu.Domain.Models.Organizations;

public enum DirectionEnum
{
    [EnumMember(Value = @"ltr")] Ltr = 0,

    [EnumMember(Value = @"trl")] Trl = 1,
}