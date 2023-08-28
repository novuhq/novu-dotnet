using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO.Integrations;
using Novu.Models;
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
    ///     TODO: have integrations as an enumeration
    /// </summary>
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "novu" },
        };

    /// <summary>
    ///     Sync have their own lifecycle.
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

        // the understanding is that providers are always unique by provider id
        var existingIntegration = integrations.Data.SingleOrDefault(x => x.ProviderId == provider);

        if (existingIntegration is not null)
        {
            // delete and not find
            await Integration.Delete(existingIntegration.Id);
            var deletedIntegration = await Integration.Get(existingIntegration.Id);
            deletedIntegration.Data.Should().BeNull();

            // now remake
            var newIntegration = await Make<Integration>(providerId: provider);
            newIntegration.Active.Should().BeTrue();

            // reinstate the integration given this might be a working test system
            await Integration.Update(newIntegration.Id, existingIntegration.ToEditData());
        }
        else
        {
            // create 
            var integration = await Make<Integration>(providerId: provider);
            integration.Active.Should().BeTrue();

            // teardown here rather than in base
            await Integration.Delete(integration.Id);
        }
    }
}