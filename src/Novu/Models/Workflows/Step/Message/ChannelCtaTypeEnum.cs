using System.Runtime.Serialization;

namespace Novu.Models.Workflows.Step.Message;

public enum ChannelCtaTypeEnum
{
    [EnumMember(Value = "redirect")] Redirect = 10,
}