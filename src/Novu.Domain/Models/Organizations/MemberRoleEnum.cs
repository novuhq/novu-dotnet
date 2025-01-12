using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Organizations;

[JsonConverter(typeof(StringEnumConverter))]
public enum MemberRoleEnum
{
    [EnumMember(Value = @"admin")] Admin = 0,
    [EnumMember(Value = @"member")] Member = 1,
}