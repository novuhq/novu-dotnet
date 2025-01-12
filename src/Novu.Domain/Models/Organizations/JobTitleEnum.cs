using System.Runtime.Serialization;

namespace Novu.Domain.Models.Organizations;

public enum JobTitleEnum
{
    [EnumMember(Value = @"engineer")] Engineer = 0,

    [EnumMember(Value = @"engineering_manager")]
    EngineeringManager = 1,

    [EnumMember(Value = @"architect")] Architect = 2,

    [EnumMember(Value = @"product_manager")]
    ProductManager = 3,

    [EnumMember(Value = @"designer")] Designer = 4,

    [EnumMember(Value = @"other")] Other = 5,
}