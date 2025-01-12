using System.Runtime.Serialization;

namespace Novu.Domain.Models.Organizations;

public enum PartnerTypeEnum
{
    [EnumMember(Value = @"vercel")] Vercel = 0,
}