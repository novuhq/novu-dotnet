using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Novu.Domain.Models.Tenants;
using Novu.Tests.Factories;
using ParkSquare.Testing.Generators;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class TenantTests(TenantFactory tenantFactory, ITenantClient tenantClient)
{
    [Fact]
    public async Task Should_Create_Tenant()
    {
        var tenant = await tenantFactory.Make();
        tenant.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_Tenant_List()
    {
        await tenantFactory.Make();
        var listOfTenants = await tenantClient.Get();

        Assert.NotNull(listOfTenants);
        Assert.NotEmpty(listOfTenants.Data);
    }

    [Fact]
    public async Task Should_Delete_Tenant()
    {
        var tenant = await tenantFactory.Make();
        await tenantClient.Delete(tenant.Identifier);
    }

    [Fact]
    public async Task Should_Update_Tenant()
    {
        var tenant = await tenantFactory.Make();

        await tenantClient.Update(
            tenant.Identifier,
            new TenantEditData
            {
                Name = NameGenerator.AnyName(),
                Identifier = tenant.Identifier,
            });
    }
}