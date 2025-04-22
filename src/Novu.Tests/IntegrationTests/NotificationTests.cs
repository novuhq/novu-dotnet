using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class NotificationTests(INotificationsClient notificationsClient)
{
    [Fact]
    public async Task Should_Get_Notifications()
    {
        // on a new instance this will be empty—so check null instead
        var integrations = await notificationsClient.Get();
        integrations.Should().NotBeNull();
        integrations.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Get_NotificationsStats()
    {
        var integrations = await notificationsClient.GetStats();
        integrations.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Get_NotificationsGraphStats()
    {
        var integrations = await notificationsClient.GetGraphStats();
        integrations.Should().NotBeNull();
    }
}