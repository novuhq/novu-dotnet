using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.JsonConverters;
using Novu.Models.Workflows.Step;
using Xunit;

namespace Novu.Tests.JsonConverters;

public class MetaDataConverterTests
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                $"default is {nameof(DigestTimedMetadata)}",
                @"
                {
                    ""timed"": {
                        ""weekDays"": [],
                        ""monthDays"": []
                    }
                }
                ",
                typeof(DigestTimedMetadata),
                false,
            },
            new object[]
            {
                nameof(DigestRegularMetadata),
                @"
                {
                    ""timed"": {
                        ""weekDays"": [],
                        ""monthDays"": []
                    },
                    ""type"": ""regular"",
                    ""unit"": ""seconds"",
                    ""backoffUnit"": ""seconds"",
                    ""backoffAmount"": 5,
                    ""backoff"": true
                }
                ",
                typeof(DigestRegularMetadata),
                false,
            },
            new object[]
            {
                nameof(DigestRegularMetadata),
                @"
                {
                    ""timed"": {
                        ""weekDays"": [],
                        ""monthDays"": []
                    },
                    ""type"": ""backoff"",
                    ""unit"": ""seconds"",
                    ""backoffUnit"": ""seconds"",
                    ""backoffAmount"": 5,
                    ""backoff"": true
                }
                ",
                typeof(DigestRegularMetadata),
                false,
            },
            new object[]
            {
                nameof(DigestTimedMetadata),
                @"
                {
                    ""type"": ""timed"",
                }
                ",
                typeof(DigestTimedMetadata),
                false,
            },
            new object[]
            {
                nameof(DelayRegularMetadata),
                @"
                {
                   ""type"": ""regular"",
                   ""amount"": 5,
                }
                ",
                typeof(DelayRegularMetadata),
                false,
            },
            new object[]
            {
                nameof(DelayScheduledMetadata),
                @"
                {
                    ""type"": ""scheduled"",
                }
                ",
                typeof(DelayScheduledMetadata),
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
                new MetaDataConverter()
                    .ReadJson(reader, t, null, JsonSerializer.CreateDefault()));
        }
        else
        {
            new MetaDataConverter()
                .ReadJson(reader, t, null, JsonSerializer.CreateDefault())
                .GetType()
                .Should()
                .Be(t);
        }
    }
}