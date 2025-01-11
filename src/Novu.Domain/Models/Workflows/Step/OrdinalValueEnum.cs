using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Workflows.Step;

[JsonConverter(typeof(StringEnumConverter))]
public enum OrdinalValueEnum
{
    [EnumMember(Value = "day")] Day = 10,
    [EnumMember(Value = "weekday")] Weekday = 20,
    [EnumMember(Value = "weekend")] Weekend = 30,
    [EnumMember(Value = "sunday")] Sunday = 40,
    [EnumMember(Value = "monday")] Monday = 50,
    [EnumMember(Value = "tuesday")] Tuesday = 60,
    [EnumMember(Value = "wednesday")] Wednesday = 70,
    [EnumMember(Value = "thursday")] Thursday = 80,
    [EnumMember(Value = "friday")] Friday = 90,
    [EnumMember(Value = "saturday")] Saturday = 100,
}