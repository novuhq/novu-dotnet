using System.Runtime.Serialization;

namespace Novu.Models.Workflows.Step.Message;

public enum TemplateVariableTypeEnum
{
    [EnumMember(Value = "String")] String = 10,
    [EnumMember(Value = "Array")] Array = 20,
    [EnumMember(Value = "Boolean")] Boolean = 30,
}