using Novu.Models.Workflows.Step;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.IntegrationTests;

/// <summary>
///     Note: active is important for triggers to success and not throw a 500 error
/// </summary>
public static class StepFactory
{
    public static Step DigestScheduleEachMonth() =>
        new()
        {
            Name = $"Digest Schedule each month 18:05 ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DigestMessageTemplate(),
            Metadata = new DigestTimedMetadata
            {
                Timed = new TimedConfig
                {
                    AtTime = "18:05",
                    MonthlyType = MonthlyTypeEnum.Each,
                    OrdinalValue = OrdinalValueEnum.Day,
                    MonthDays = new[] { 5, 10 },
                },
                Amount = 1,
                Unit = UnitEnum.Weeks,
            },
        };

    public static Step InApp(bool active = false) =>
        new()
        {
            Name = $"In-App ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.InAppMessageTemplate(),
            Active = active,
        };

    public static Step Email(bool active = false) =>
        new()
        {
            Name = $"Email ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.EmailMessageTemplate(),
            Active = active,
        };

    public static Step Sms(bool active = false) =>
        new()
        {
            Name = $"Sms ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.SmsMessageTemplate(),
            Active = active,
        };

    public static Step DigestRegular(bool active = false) =>
        new()
        {
            Name = $"Digest Event ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DigestMessageTemplate(),
            Metadata = new DigestRegularMetadata
            {
                Type = DigestTypeEnum.Regular,
                Backoff = true,
                BackoffAmount = 5,
                BackoffUnit = UnitEnum.Seconds,
                Amount = 30,
                Unit = UnitEnum.Seconds,
            },
            Active = active,
        };

    public static Step DigestScheduleAtTime() =>
        new()
        {
            Name = $"Digest Schedule 18:05 ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DigestMessageTemplate(),
            Metadata = new DigestTimedMetadata
            {
                Timed = new TimedConfig
                {
                    AtTime = "18:05",
                },
                Amount = 1,
                Unit = UnitEnum.Days,
            },
        };

    public static Step DigestScheduleEveryWeekdayAtTime() =>
        new()
        {
            Name = $"Digest Schedule every week day 18:05 ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DigestMessageTemplate(),
            Metadata = new DigestTimedMetadata
            {
                Timed = new TimedConfig
                {
                    AtTime = "18:05",
                    WeekDays = new[] { DaysEnum.Monday, DaysEnum.Thursday },
                },
                Amount = 1,
                Unit = UnitEnum.Weeks,
            },
        };

    public static Step Push(bool active = false) =>
        new()
        {
            Name = $"Push ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.PushMessageTemplate(),
            Active = active,
        };

    public static Step DelayFromVariable() =>
        new()
        {
            Name = $"Delay 5 minutes from variable ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DelayMessageTemplate(),
            Metadata = new DelayScheduledMetadata
            {
                DelayPath = "sendAt",
            },
        };

    public static Step Delay() =>
        new()
        {
            Name = $"Delay 5 minutes Regular ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DelayMessageTemplate(),
            Metadata = new DelayRegularMetadata
            {
                Amount = 5,
                Unit = UnitEnum.Minutes,
            },
        };

    public static Step Chat(bool active = false) =>
        new()
        {
            Name = $"Chat ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.ChatMessageTemplate(),
            Active = active,
        };

    public static Step DigestScheduleSecondWeekday() =>
        new()
        {
            Name = $"Digest Schedule on second weekday 18:05 ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DigestMessageTemplate(),
            Metadata = new DigestTimedMetadata
            {
                Timed = new TimedConfig
                {
                    AtTime = "18:05",
                    MonthlyType = MonthlyTypeEnum.On,
                    Ordinal = OrdinalEnum.Second,
                    OrdinalValue = OrdinalValueEnum.Weekday,
                },
                Amount = 1,
                Unit = UnitEnum.Weeks,
            },
        };
}