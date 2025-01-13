using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Workflows.Step;

[JsonConverter(typeof(StringEnumConverter))]
public enum StepTypeEnum
{
    [EnumMember(Value = "in_app")] InApp = 10,
    [EnumMember(Value = "email")] Email = 20,
    [EnumMember(Value = "sms")] Sms = 30,
    [EnumMember(Value = "chat")] Chat = 40,
    [EnumMember(Value = "push")] Push = 50,
    [EnumMember(Value = "digest")] Digest = 60,
    [EnumMember(Value = "trigger")] Trigger = 70,
    [EnumMember(Value = "delay")] Delay = 80,
}