using System.Runtime.Serialization;

namespace Novu.Models.Workflows.Trigger;

public enum TriggerTypeEnum
{
    [EnumMember(Value = "event")] Event = 10,
}