using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.Domain.JsonConverters;
using Novu.Domain.Models.Subscribers;
using Xunit;

namespace Novu.Tests.MicroTests.JsonConverters;

public class DataToObjectConverterTests
{
    [Fact]
    public void Write_Null_Is_Empty()
    {
        var actual = new X();
        var json = JsonConvert.SerializeObject(actual);
        json.Should().Be(@"{""data"":{}}");
    }

    [Fact]
    public void Write_Empty_Is_Empty()
    {
        var actual = new X
        {
            Data = [],
        };
        var json = JsonConvert.SerializeObject(actual);
        json.Should().Be(@"{""data"":{}}");
    }

    [Fact]
    public void Read_Empty_Is_Empty()
    {
        var expected = new X
        {
            Data = [],
        };
        var json = @"{""data"":{}}";
        var actual = JsonConvert.DeserializeObject<X>(json);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Read_Null_Is_Empty()
    {
        var expected = new X();
        var json = @"{""data"":{}}";
        var actual = JsonConvert.DeserializeObject<X>(json);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Write_One_Is_Object()
    {
        var actual = new X
        {
            Data =
            [
                new AdditionalData
                {
                    Key = "x",
                    Value = "y",
                },
            ],
        };
        var json = JsonConvert.SerializeObject(actual);
        json.Should().Be(@"{""data"":{""x"":""y""}}");
    }
    [Fact]
    public void Write_Two_Is_Object()
    {
        var actual = new X
        {
            Data =
            [
                new AdditionalData
                {
                    Key = "x",
                    Value = "y",
                },
                new AdditionalData
                {
                    Key = "actual",
                    Value = "z",
                },
            ],
        };
        var json = JsonConvert.SerializeObject(actual);
        json.Should().Be(@"{""data"":{""x"":""y"",""actual"":""z""}}");
    }

    [Fact]
    public void Read_One_Is_Object()
    {
        var expected = new X
        {
            Data =
            [
                new AdditionalData
                {
                    Key = "x",
                    Value = "y",
                },
            ],
        };
        var json = @"{""data"":{""x"":""y""}}";
        var actual = JsonConvert.DeserializeObject<X>(json);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Read_Two_Is_Object()
    {
        var expected = new X
        {
            Data =
            [
                new AdditionalData
                {
                    Key = "x",
                    Value = "y",
                },
                new AdditionalData
                {
                    Key = "actual",
                    Value = "z",
                },
            ],
        };
        var json = @"{""data"":{""x"":""y"",""actual"":""z""}}";
        var actual = JsonConvert.DeserializeObject<X>(json);
        actual.Should().BeEquivalentTo(expected);
    }

    public class X
    {
        [JsonProperty("data")]
        [JsonConverter(typeof(DataToObjectConverter))]
        public List<AdditionalData> Data { get; set; } = [];
    }
}