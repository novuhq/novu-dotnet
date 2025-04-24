using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Novu.Domain.Models;
using Novu.Tests.Factories;
using Xunit;

namespace Novu.Tests.AcceptanceTests;

public class IntegrationTests(IIntegrationClient integrationClient, IntegrationFactory integrationFactory)
{
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
    public async Task AcceptanceTest(string provider)
    {
        var integrations = await integrationClient.Get();

        // providers aren't unique because they move across environments
        var existingIntegrations = integrations.Data
            .Where(x => x.ProviderId == provider)
            .ToList();

        if (existingIntegrations.Count > 0)
        {
            foreach (var existingIntegration in existingIntegrations)
            {
                // delete and not find
                await integrationClient.Delete(existingIntegration.Id);
                var deletedIntegration = await integrationClient.Get(existingIntegration.Id);
                deletedIntegration.Data.Should().BeNull();

                // now remake
                var newIntegration = await integrationFactory.Make(providerId: provider);
                newIntegration.Active.Should().BeTrue();

                // reinstate the integration given this might be a working test system
                await integrationClient.Update(newIntegration.Id, existingIntegration.ToEditData());
            }
        }
        else
        {
            // create 
            var integration = await integrationFactory.Make(providerId: provider);
            integration.Active.Should().BeTrue();

            // teardown here rather than in base
            await integrationClient.Delete(integration.Id);
        }
    }
}