using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class NotificationTests : BaseIntegrationTest
{
    public NotificationTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task Should_Get_Notifications()
    {
        var integrations = await Notifications.Get();
        integrations.Should().NotBeNull();
        integrations.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Should_Get_NotificationsStats()
    {
        var integrations = await Notifications.GetStats();
        integrations.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Get_NotificationsGraphStats()
    {
        var integrations = await Notifications.GetGraphStats();
        integrations.Should().NotBeNull();
    }
}