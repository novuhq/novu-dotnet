using System.Runtime.Serialization;

namespace Novu.Domain.Models.Changes;

public enum ChangeEnum
{
    [EnumMember(Value = @"Feed")] Feed = 0,

    [EnumMember(Value = @"MessageTemplate")]
    MessageTemplate = 1,

    [EnumMember(Value = @"Layout")] Layout = 2,

    [EnumMember(Value = @"DefaultLayout")] DefaultLayout = 3,

    [EnumMember(Value = @"NotificationTemplate")]
    NotificationTemplate = 4,

    [EnumMember(Value = @"NotificationGroup")]
    NotificationGroup = 5,

    [EnumMember(Value = @"TranslationGroup")]
    TranslationGroup = 6,

    [EnumMember(Value = @"Translation")] Translation = 7,
}