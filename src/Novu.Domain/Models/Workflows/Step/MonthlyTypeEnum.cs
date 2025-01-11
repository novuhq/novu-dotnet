using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Workflows.Step;

[JsonConverter(typeof(StringEnumConverter))]
public enum MonthlyTypeEnum
{
    [EnumMember(Value = "each")] Each = 10,
    [EnumMember(Value = "on")] On = 20,
}