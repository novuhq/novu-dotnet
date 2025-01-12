using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Novu.Domain.Models.Organizations;
using ParkSquare.Testing.Generators;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class OrganizationBrandTests(
    IOrganizationBrandClient organizationBrandClient,
    IOrganizationClient organizationClient)
{
    /// <summary>
    ///     There is no need to create an organization because the update is always made on the
    ///     organization tenanted on the apikey provided
    /// </summary>
    [Fact]
    public async Task Should_Update_Organisation_Branding()
    {
        var color = $"#f4737{NumberGenerator.RandomNumberBetween(0, 9)}";
        await organizationBrandClient.Update(new BrandingEditData
        {
            Color = color,
        });
        var updatedOrganisation = await organizationClient.Me();
        updatedOrganisation.Data.Branding.Color.Should().Be(color);
    }
}