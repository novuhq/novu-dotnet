using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Domain.Models.Subscribers.Preferences;

[JsonConverter(typeof(StringEnumConverter))]
public enum ChannelTypeEnum
{
    [EnumMember(Value = "in_app")] InApp = 10,
    [EnumMember(Value = "email")] Email = 20,
    [EnumMember(Value = "sms")] Sms = 30,
    [EnumMember(Value = "chat")] Chat = 40,
    [EnumMember(Value = "push")] Push = 50,
}