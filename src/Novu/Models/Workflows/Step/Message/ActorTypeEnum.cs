using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Models.Workflows.Step.Message;

[JsonConverter(typeof(StringEnumConverter))]
public enum ActorTypeEnum
{
    [EnumMember(Value = "none")] None = 10,
    [EnumMember(Value = "user")] User = 20,
    [EnumMember(Value = "system_icon")] SystemIcon = 30,
    [EnumMember(Value = "system_custom")] SystemCustom = 40,
}