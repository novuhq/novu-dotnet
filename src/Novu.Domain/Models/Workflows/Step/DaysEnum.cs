using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Workflows.Step;

[JsonConverter(typeof(StringEnumConverter))]
public enum DaysEnum
{
    [EnumMember(Value = "monday")] Monday = 10,
    [EnumMember(Value = "tuesday")] Tuesday = 20,
    [EnumMember(Value = "wednesday")] Wednesday = 30,
    [EnumMember(Value = "thursday")] Thursday = 40,
    [EnumMember(Value = "friday")] Friday = 50,
    [EnumMember(Value = "saturday")] Saturday = 60,
    [EnumMember(Value = "sunday")] Sunday = 70,
}