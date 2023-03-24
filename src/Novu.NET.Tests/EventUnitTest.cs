using Novu.NET.DTO;
using Novu.NET.Tests.Fixtures;

namespace Novu.NET.Tests;

public class EventUnitTest : IClassFixture<SubscriberFixture>
{
    private readonly SubscriberFixture _fixture;

    public EventUnitTest(SubscriberFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async void Should_Trigger_Event()
    {
        var payload = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("framework", ".net") };

        var novuEvent = await _fixture.NovuClient.Event.Trigger("test", new EventTriggerDataDto
        {
            To =
            {
                SubscriberId = "novu.net-test"
            },
            Payload = payload
        });
    }
}