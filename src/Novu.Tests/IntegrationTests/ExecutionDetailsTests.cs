using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.Interfaces;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class ExecutionDetailsTests : BaseIntegrationTest
{
    public ExecutionDetailsTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task Should_Get_Messages()
    {
        // TODO: should setup its own data
        var notifications = await Notifications.Get();
        var notification = notifications.Data.FirstOrDefault(x => x.Jobs.Any(y => y.ExecutionDetails.Any()));

        notification.Should().NotBeNull();

        var messages = await Get<IExecutionDetailsClient>()
            .Get(notification?.Id!, notification?.Subscriber?.Id!);
        messages.Data.Should().NotBeNull();
    }
}