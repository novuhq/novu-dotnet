using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO.Layouts;
using Novu.Models.Workflows.Step.Message;
using Refit;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class LayoutTests : BaseIntegrationTest
{
    public LayoutTests(ITestOutputHelper output) : base(output)
    {
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "no body expression", "", Array.Empty<TemplateVariable>(), 0, true },
            new object[] { "body only", LayoutCreateData.BodyExpression, Array.Empty<TemplateVariable>(), 0, false },
            new object[]
                { "body", "test " + LayoutCreateData.BodyExpression, Array.Empty<TemplateVariable>(), 0, false },
            new object[]
                { "html", "<p>dfd,/p> " + LayoutCreateData.BodyExpression, Array.Empty<TemplateVariable>(), 0, false },
            new object[]
            {
                "variables not sent back (does not fail)",
                string.Format(LayoutCreateData.VariableFormat, "subscribe.name") + LayoutCreateData.BodyExpression,
                Array.Empty<TemplateVariable>(),
                1,
                false,
            },
            new object[]
            {
                "variables sent back (does not fail)",
                $"{string.Format(LayoutCreateData.VariableFormat, "subscribe.name")} {LayoutCreateData.BodyExpression}",
                new TemplateVariable[]
                {
                    new()
                    {
                        Name = "subscribe.name",
                        Type = TemplateVariableTypeEnum.String,
                    },
                },
                1,
                false,
            },
            new object[]
            {
                "variables sent back with extras that aren't included throws",
                $"{string.Format(LayoutCreateData.VariableFormat, "subscribe.name")} {LayoutCreateData.BodyExpression}",
                new TemplateVariable[]
                {
                    new()
                    {
                        Name = "subscribe.name",
                        Type = TemplateVariableTypeEnum.String,
                    },
                    new()
                    {
                        Name = "subscribe.longAddress",
                        Type = TemplateVariableTypeEnum.String,
                    },
                },
                1,
                false,
            },
            new object[]
            {
                "variables sent back with extras that aren't included throws",
                $"{string.Format(LayoutCreateData.VariableFormat, "subscribe.name")} {LayoutCreateData.BodyExpression} {string.Format(LayoutCreateData.VariableFormat, "subscribe.longAddress")}",
                new TemplateVariable[]
                {
                    new()
                    {
                        Name = "subscribe.name",
                        Type = TemplateVariableTypeEnum.String,
                    },
                    new()
                    {
                        Name = "subscribe.longAddress",
                        Type = TemplateVariableTypeEnum.Boolean,
                    },
                },
                2,
                false,
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public async Task Should_Create(
        string test,
        string content,
        TemplateVariable[] variables,
        int variableCount,
        bool throws)
    {
        if (!throws)
        {
            var layout = await Make<Layout>(content: content, variables: variables);
            var result = await Layout.Get(layout.Id);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(layout.Id);

            result.Data.Variables.Should().HaveCount(variableCount);
        }
        else
        {
            DeRegisterExceptionHandler();
            await Assert.ThrowsAsync<ApiException>(async () =>
                await Make<Layout>(content: content, variables: variables));
        }
    }


    [Fact]
    public async Task Should_Get_Layouts()
    {
        var layouts = await Layout.Get();
        layouts.Should().NotBeNull();
        layouts.Page.Should().Be(0);
        layouts.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Should_Get_Layout()
    {
        var layout = await Make<Layout>();
        var result = await Layout.Get(layout.Id);
        result.Data.Should().NotBeNull();
        result.Data.Id.Should().Be(layout.Id);
    }

    [Fact]
    public async Task Should_Delete_Layout()
    {
        var layout = await Make<Layout>();
        await Layout.Delete(layout.Id);
        var result = await Layout.Get(layout.Id);
        result.Data.Should().BeNull();
    }

    [Fact]
    public async Task Should_SetStatus()
    {
        var layouts = await Layout.Get();
        var originalDefault = layouts.Data.Single(x => x.IsDefault);

        var layout = layouts.Data.First(x => !x.IsDefault);
        await Layout.SetAsDefault(layout.Id);
        var result = await Layout.Get(layout.Id);
        result.Data.IsDefault.Should().BeTrue();

        // cleanup to reinstate the original
        await Layout.SetAsDefault(originalDefault.Id);
    }
}