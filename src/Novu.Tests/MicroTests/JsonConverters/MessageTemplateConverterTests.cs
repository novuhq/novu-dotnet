using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.Domain.JsonConverters;
using Novu.Domain.Models.Workflows.Step.Message;
using Xunit;

namespace Novu.Tests.MicroTests.JsonConverters;

public class MessageTemplateConverterTests
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                "empty type throws exception",
                @"{ ""type"": """", }",
                typeof(InAppMessageTemplate),
                true,
            },
            new object[]
            {
                nameof(InAppMessageTemplate),
                @"
                {
                    ""type"": ""in_app"",
                }
                ",
                typeof(InAppMessageTemplate),
                false,
            },
            new object[]
            {
                nameof(EmailMessageTemplate),
                @"
                {
                    ""type"": ""email"",
                }
                ",
                typeof(EmailMessageTemplate),
                false,
            },
            new object[]
            {
                nameof(SmsMessageTemplate),
                @"
                {
                    ""type"": ""sms"",
                }
                ",
                typeof(SmsMessageTemplate),
                false,
            },
            new object[]
            {
                nameof(ChatMessageTemplate),
                @"
                {
                    ""type"": ""chat"",
                }
                ",
                typeof(ChatMessageTemplate),
                false,
            },
            new object[]
            {
                nameof(DigestMessageTemplate),
                @"
                {
                    ""type"": ""digest"",
                }
                ",
                typeof(DigestMessageTemplate),
                false,
            },
            new object[]
            {
                nameof(TriggerMessageTemplate),
                @"
                {
                    ""type"": ""trigger"",
                }
                ",
                typeof(TriggerMessageTemplate),
                false,
            },
            new object[]
            {
                nameof(DelayMessageTemplate),
                @"
                {
                    ""type"": ""delay"",
                }
                ",
                typeof(DelayMessageTemplate),
                false,
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void MessageTemplateType(string test, string json, Type t, bool throws)
    {
        JsonReader reader = new JsonTextReader(new StringReader(json));
        while (reader.TokenType == JsonToken.None)
        {
            if (!reader.Read())
            {
                break;
            }
        }

        if (throws)
        {
            Assert.ThrowsAny<Exception>(() =>
                new MessageTemplateConverter()
                    .ReadJson(reader, t, null, JsonSerializer.CreateDefault()));
        }
        else
        {
            new MessageTemplateConverter()
                .ReadJson(reader, t, null, JsonSerializer.CreateDefault())
                .GetType()
                .Should()
                .Be(t);
        }
    }
}