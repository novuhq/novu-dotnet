using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Models.Workflows.Step;

[JsonConverter(typeof(StringEnumConverter))]
public enum OrdinalEnum
{
    [EnumMember(Value = "1")] First = 10,
    [EnumMember(Value = "2")] Second = 20,
    [EnumMember(Value = "3")] Third = 30,
    [EnumMember(Value = "4")] Fourth = 40,
    [EnumMember(Value = "5")] Fifth = 50,
    [EnumMember(Value = "last")] Last = 60,
}