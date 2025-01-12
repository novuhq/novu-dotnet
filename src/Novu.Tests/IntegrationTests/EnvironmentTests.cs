using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class EnvironmentTests(IEnvironmentClient environmentClient)
{
    [Fact]
    public async Task Should_Return_Environment_Me()
    {
        var me = await environmentClient.Me();

        me.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_Environment_List()
    {
        var listOfEnvironments = await environmentClient.Get();

        listOfEnvironments.Should().NotBeNull();
        listOfEnvironments.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Should_Return_Environment_ApiKeys_List()
    {
        var apiKeys = await environmentClient.ApiKeys();

        apiKeys.Should().NotBeNull();
        apiKeys.Data.Should().NotBeEmpty();
    }
}