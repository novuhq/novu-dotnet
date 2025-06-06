using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class MessageTests(IMessageClient messageClient)
{
   [Fact]
    public async Task Should_Get_Messages()
    {
        // TODO: should really setup its own messages
        var messages = await messageClient.Get();
        messages.Should().NotBeNull();
        // messages.Data.Should().NotBeEmpty();
    }

    [RunnableInDebugOnly]
    public async Task Should_Get_Delete()
    {
        // TODO: should really setup its own messages as in a new system this breaks
        
        var messages = await messageClient.Get();
        var message = messages.Data.FirstOrDefault();
        if (message is not null)
        {
            var response = await messageClient.Delete(message.Id);
            response.Data.Acknowledged.Should().BeTrue();
        }
    }
}