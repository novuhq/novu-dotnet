using System.Runtime.Serialization;

namespace Novu.Models.Workflows.Step.Message;

public enum EmailBlockTypeEnum
{
    [EnumMember(Value = "button")] Button = 10,
    [EnumMember(Value = "text")] Text = 20,
}