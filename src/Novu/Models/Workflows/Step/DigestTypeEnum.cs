using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.Models.Workflows.Step;

[JsonConverter(typeof(StringEnumConverter))]
public enum DigestTypeEnum
{
    [EnumMember(Value = "regular")] Regular = 10,
    [EnumMember(Value = "backoff")] Backoff = 20,
    [EnumMember(Value = "timed")] Timed = 30,
}