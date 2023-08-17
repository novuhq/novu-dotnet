using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO.Integrations;
using Novu.Tests.IntegrationTests;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.AcceptanceTests;

public class IntegrationTests : BaseIntegrationTest
{
    public IntegrationTests(ITestOutputHelper output) : base(output)
    {
    }

    /// <summary>
    ///     TODO: add more integrations to this list
    /// </summary>
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "novu" },
        };

    /// <summary>
    ///     Integrations have their own lifecycle.
    ///     - list is not known via API (need to know out of band eg via source code)
    ///     - can't delete—only active or inactive
    ///     - global set of configuration but each integration uses a subset that is undocumented
    /// </summary>
    [Theory]
    [MemberData(nameof(Data))]
    public async Task AcceptanceTest(
        string provider)
    {
        var integrations = await Integration.Get();
        var existingIntegration = integrations.Data.SingleOrDefault(x => x.ProviderId == provider);

        if (existingIntegration is not null)
        {
            // delete and not find
            await Integration.Delete(existingIntegration.Id);
        }

        // create (and delete in is teardown)
        var integration = await Make<Integration>(providerId: provider);
        integration.Active.Should().BeTrue();
    }
}