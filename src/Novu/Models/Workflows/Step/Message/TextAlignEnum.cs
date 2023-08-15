using System.Runtime.Serialization;

namespace Novu.Models.Workflows.Step.Message;

public enum TextAlignEnum
{
    [EnumMember(Value = "center")] Center = 10,
    [EnumMember(Value = "left")] Left = 20,
    [EnumMember(Value = "right")] Right = 30,
}