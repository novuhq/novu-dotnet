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
        //
        // TODO: should setup its own data (which really makes it an acceptance-style test because it is big
        //
        
        // fingers cross there are some notifications to check serialisation
        var notifications = await Notifications.Get();
        var notification = notifications.Data.FirstOrDefault(x => x.Jobs.Any(y => y.ExecutionDetails.Any()));

        if (notification is not null)
        {
            await Get<IExecutionDetailsClient>().Get(notification.Id, notification.Subscriber.Id);
        }
        else
        {
            Output.WriteLine("No real test was run as there is no notification data");
        }
    }
}