using Novu.DTO;
using Novu.Models;

namespace Novu.Tests.Fixtures;

public class SubscriberFixture : IDisposable
{
    private List<SubscriberDto> Subscribers { get; set; } = new List<SubscriberDto>();
    public NovuClient NovuClient { get; }

    public SubscriberFixture()
    {
        var novuConfiguration = new NovuClientConfiguration
        {
            ApiKey = Environment.GetEnvironmentVariable("NOVU_API_KEY") ?? throw new InvalidOperationException(),
        };
        var novu = new NovuClient(novuConfiguration);

        NovuClient = novu;
    }

    public async Task<SubscriberDto> GenerateTestSubscriber()
    {
        var additionalData = new List<AdditionalDataDto>
        {
            new AdditionalDataDto
            {
                Key = "FRAMEWORK",
                Value = ".NET"
            },
            new AdditionalDataDto
            {
                Key = "SMS_PREFERENCE",
                Value = "EMERGENT-ONLY"
            }
        };
        
        var subscriber = await NovuClient.Subscriber.CreateSubscriber(new CreateSubscriberDto
        {
            SubscriberId = Guid.NewGuid().ToString(),
            FirstName = "Novu",
            LastName = ".NET",
            Avatar = "https://avatars.githubusercontent.com/u/77433905?s=200&v=4",
            Email = "noreply@novu.co",
            Locale = "en-US",
            Phone = "+11112223333",
            Data = additionalData
        });

        Subscribers.Add(subscriber);
        
        return subscriber;
    }

    public async void Dispose()
    {
        foreach (var testSubscriber in Subscribers)
        {
            await NovuClient.Subscriber.DeleteSubscriber(testSubscriber.SubscriberId);
        }
    }
}