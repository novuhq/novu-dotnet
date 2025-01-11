using Novu.Domain.Models.Workflows.Step;
using Novu.Tests.Factories.Models;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.IntegrationTests;

/// <summary>
///     Note: active is important for triggers to success and not throw a 500 error
/// </summary>
public static class StepFactory
{
    public static Step DigestScheduleEachMonth()
    {
        return new Step
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
                    MonthDays = [5, 10],
                },
                Amount = 1,
                Unit = UnitEnum.Weeks,
            },
        };
    }

    public static Step InApp(bool active = false)
    {
        return new Step
        {
            Name = $"In-App ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.InAppMessageTemplate(),
            Active = active,
        };
    }

    public static Step Email(bool active = false, string layoutId = null)
    {
        return new Step
        {
            Name = $"Email ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.EmailMessageTemplate(layoutId),
            Active = active,
        };
    }

    public static Step Sms(bool active = false)
    {
        return new Step
        {
            Name = $"Sms ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.SmsMessageTemplate(),
            Active = active,
        };
    }

    public static Step DigestRegular(bool active = false)
    {
        return new Step
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
    }

    public static Step DigestScheduleAtTime()
    {
        return new Step
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
    }

    public static Step DigestScheduleEveryWeekdayAtTime()
    {
        return new Step
        {
            Name = $"Digest Schedule every week day 18:05 ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DigestMessageTemplate(),
            Metadata = new DigestTimedMetadata
            {
                Timed = new TimedConfig
                {
                    AtTime = "18:05",
                    WeekDays = [DaysEnum.Monday, DaysEnum.Thursday],
                },
                Amount = 1,
                Unit = UnitEnum.Weeks,
            },
        };
    }

    public static Step Push(bool active = false)
    {
        return new Step
        {
            Name = $"Push ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.PushMessageTemplate(),
            Active = active,
        };
    }

    public static Step DelayFromVariable()
    {
        return new Step
        {
            Name = $"Delay 5 minutes from variable ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DelayMessageTemplate(),
            Metadata = new DelayScheduledMetadata
            {
                DelayPath = "sendAt",
            },
        };
    }

    public static Step Delay()
    {
        return new Step
        {
            Name = $"Delay 5 minutes Regular ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.DelayMessageTemplate(),
            Metadata = new DelayRegularMetadata
            {
                Amount = 5,
                Unit = UnitEnum.Minutes,
            },
        };
    }

    public static Step Chat(bool active = false)
    {
        return new Step
        {
            Name = $"Chat ({StringGenerator.LoremIpsum(2)})",
            Template = MessageTemplateFactory.ChatMessageTemplate(),
            Active = active,
        };
    }

    public static Step DigestScheduleSecondWeekday()
    {
        return new Step
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
}