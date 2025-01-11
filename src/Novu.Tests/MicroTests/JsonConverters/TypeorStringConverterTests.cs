using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.Domain.JsonConverters;
using Novu.Domain.Models.Workflows.Step.Message;
using Xunit;

namespace Novu.Tests.MicroTests.JsonConverters;

public class TypeOrStringConverterTests
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                "default is string",
                @"
                    ""a value""
                ",
                typeof(string),
                false,
            },
            new object[]
            {
                nameof(EmailBlock),
                @"
                [
                    {""type"": ""text""},
                ]
            ",
                typeof(EmailBlock[]),
                false,
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void MetaDataType(string test, string json, Type t, bool throws)
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
                new TypeOrStringConverter<EmailBlock>()
                    .ReadJson(reader, t, null, JsonSerializer.CreateDefault()));
        }
        else
        {
            new TypeOrStringConverter<EmailBlock>()
                .ReadJson(reader, t, null, JsonSerializer.CreateDefault())
                ?.GetType()
                .Should()
                .Be(t);
        }
    }
}