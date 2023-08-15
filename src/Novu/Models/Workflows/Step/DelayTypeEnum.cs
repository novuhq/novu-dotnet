using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Models.Workflows.Step;

[JsonConverter(typeof(StringEnumConverter))]
public enum DelayTypeEnum
{
    [EnumMember(Value = "regular")] Regular = 10,
    [EnumMember(Value = "scheduled")] Scheduled = 20,
}