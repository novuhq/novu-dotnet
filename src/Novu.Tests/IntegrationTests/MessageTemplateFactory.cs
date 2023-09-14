using System.Collections.Generic;
using Novu.Models.Workflows.Step.Message;

namespace Novu.Tests.IntegrationTests;

public static class MessageTemplateFactory
{
    public static DelayMessageTemplate DelayMessageTemplate()
    {
        return new DelayMessageTemplate();
    }

    public static InAppMessageTemplate InAppMessageTemplate()
    {
        return new InAppMessageTemplate
        {
            Content = "Here is just a string {{mail.subject}}",
        };
    }

    public static SmsMessageTemplate SmsMessageTemplate()
    {
        return new SmsMessageTemplate
        {
            Content = "Here is just another string {{mail.subject}}",
        };
    }

    public static ChatMessageTemplate ChatMessageTemplate()
    {
        return new ChatMessageTemplate
        {
            Content = "Here is just another string {{mail.subject}}",
        };
    }

    public static PushMessageTemplate PushMessageTemplate()
    {
        return new PushMessageTemplate
        {
            Title = "A push title",
            Content = "Here is just another string {{mail.subject}}",
        };
    }

    public static DigestMessageTemplate DigestMessageTemplate()
    {
        return new DigestMessageTemplate();
    }

    public static EmailMessageTemplate EmailMessageTemplate(string layoutId = null)
    {
        return new EmailMessageTemplate
        {
            // Type = StepTypeEnum.Email,
            ContentType = MessageTemplateContentType.Editor,
            SenderName = "Hello",
            Subject = "{{mail.subject}}",
            LayoutId = layoutId,
            Content = new List<EmailBlock>
            {
                new()
                {
                    Type = EmailBlockTypeEnum.Text,
                    Content = "Here is a email string {{mail.subject}}",
                    Styles = new[]
                    {
                        new EmailBlockStyle
                        {
                            Type = TextAlignEnum.Center,
                        },
                    },
                },
            },
        };
    }
}