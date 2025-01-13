using System.Runtime.Serialization;

namespace Novu.Domain.Models.Workflows.Trigger;

public enum TriggerTypeEnum
{
    [EnumMember(Value = "event")] Event = 10,
}