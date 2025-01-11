using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Workflows.Step;

[JsonConverter(typeof(StringEnumConverter))]
public enum UnitEnum
{
    [EnumMember(Value = "seconds")] Seconds = 10,
    [EnumMember(Value = "minutes")] Minutes = 20,
    [EnumMember(Value = "hours")] Hours = 30,
    [EnumMember(Value = "days")] Days = 40,
    [EnumMember(Value = "weeks")] Weeks = 50,
    [EnumMember(Value = "months")] Months = 60,
}