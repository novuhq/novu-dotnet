using System.Runtime.Serialization;

namespace Novu.Models.Workflows.Step;

public enum ButtonTypeEnum
{
    [EnumMember(Value = "primary")] Primary = 10,
    [EnumMember(Value = "secondary")] Secondary = 20,
    [EnumMember(Value = "clicked")] Clicked = 30,
}