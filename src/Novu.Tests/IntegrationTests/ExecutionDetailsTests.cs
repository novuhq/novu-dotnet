using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Novu.Clients;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class ExecutionDetailsTests(
    INotificationsClient notificationsClient,
    IExecutionDetailsClient executionDetailsClient,
    ILogger<ExecutionDetailsTests> log)
{
    [Fact]
    public async Task Should_Get_Messages()
    {
        //
        // TODO: should setup its own data (which really makes it an acceptance-style test because it is big
        //

        // fingers cross there are some notifications to check serialisation
        var notifications = await notificationsClient.Get();
        var notification = notifications.Data.FirstOrDefault(x => x.Jobs.Any(y => y.ExecutionDetails.Any()));

        if (notification is not null)
        {
            if (notification.Subscriber is not null)
            {
                await executionDetailsClient.Get(notification.Id, notification.Subscriber.Id);
            }
            else
            {
                log.LogWarning("No real test was run as there is no subscriber on the  data");
            }
        }
        else
        {
            log.LogError("No real test was run as there is no notification data");
        }
    }
}