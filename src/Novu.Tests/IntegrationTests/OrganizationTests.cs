using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Novu.Tests.Factories;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class OrganizationTests(OrganizationFactory organizationFactory, IOrganizationClient organizationClient)
{
    [Fact]
    public async Task Should_Create_Organisation()
    {
        var organisation = await organizationFactory.Make();
        organisation.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_Organisation_List()
    {
        await organizationFactory.Make();
        var listOfOrganisations = await organizationClient.Get();

        Assert.NotNull(listOfOrganisations);
        Assert.NotEmpty(listOfOrganisations.Data);
    }

    [Fact]
    public async Task Should_Return_Organisation_Me()
    {
        await organizationFactory.Make();
        var organization = await organizationClient.Me();

        Assert.NotNull(organization);
        Assert.NotNull(organization.Data.Name);
    }

    [Fact(Skip = "Organization cannot be deleted")]
    public Task Should_Delete_Organisation()
    {
        return Task.CompletedTask;
    }
}