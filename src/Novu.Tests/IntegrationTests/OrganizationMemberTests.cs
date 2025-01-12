using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class OrganizationMemberTests(IOrganizationMemberClient organizationMemberClient)
{
    /// <summary>
    ///     There is no need to create an organization because the update is always made on the
    ///     organization tenanted on the apikey provided
    /// </summary>
    [Fact]
    public async Task Should_Get_All_Members()
    {
        var members = await organizationMemberClient.Get();
        members.Should().NotBeNull();
    }
}