using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.Tests.IntegrationTests;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.AcceptanceTests;

public class LayoutTests : BaseIntegrationTest
{
    public LayoutTests(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    ///     This is a flaky test because 'default' operates globally to the application
    /// </summary>
    [Fact]
    public async Task Should_SetStatus()
    {
        // try and find the default layout—there should be one (but still be defensive)
        var layouts = await Layout.Get();
        var originalDefault = layouts.Data.SingleOrDefault(x => x.IsDefault);

        // now, find another layout if there is none
        var layout = layouts.Data.FirstOrDefault(x => !x.IsDefault);
        if (layout is not null)
        {
            await Layout.SetAsDefault(layout.Id);
            var result = await Layout.Get(layout.Id);
            result.Data.IsDefault.Should().BeTrue();
        }

        // cleanup to reinstate the original
        if (originalDefault is not null)
        {
            await Layout.SetAsDefault(originalDefault.Id);
        }
    }
}