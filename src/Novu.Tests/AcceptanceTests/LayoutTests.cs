using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO.Layouts;
using Novu.Models.Workflows.Step.Message;
using Novu.Tests.IntegrationTests;
using Refit;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.AcceptanceTests;

public class LayoutTests : BaseIntegrationTest
{
    public LayoutTests(ITestOutputHelper output) : base(output)
    {
    }
    
    /// <summary>
    ///     This is a flakey test because 'default' operates globally to the applic
    /// </summary>
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