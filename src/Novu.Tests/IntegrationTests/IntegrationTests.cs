using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class IntegrationTests : BaseIntegrationTest
{
    public IntegrationTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task Should_Get_Integrations()
    {
        var integrations = await Integration.Get();
        integrations.Should().NotBeNull();
        integrations.Data.Should().NotBeEmpty();
    }
}