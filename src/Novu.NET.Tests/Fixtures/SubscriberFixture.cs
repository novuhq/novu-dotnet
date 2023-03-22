using Novu.NET.DTO;

namespace Novu.NET.Tests.Fixtures;

public class SubscriberFixture
{
    public SubscriberDTO Subscriber { get; private set; }
    public NovuClient NovuClient { get; }

    public SubscriberFixture()
    {
        var novuConfiguration = new NovuClientConfiguration
        {
            ApiKey = Environment.GetEnvironmentVariable("NOVU_API_KEY") ?? throw new InvalidOperationException(),
        };
        var novu = new NovuClient(novuConfiguration);

        NovuClient = novu;

        GenerateTestSubscriber().Wait();
    }

    public async Task<SubscriberDTO> GenerateTestSubscriber()
    {
        var additionalData = new List<AdditionalDataDTO>
        {
            new AdditionalDataDTO
            {
                Key = "FRAMEWORK",
                Value = ".NET"
            },
            new AdditionalDataDTO
            {
                Key = "SMS_PREFERENCE",
                Value = "EMERGENT-ONLY"
            }
        };
        
        var subscriber = await NovuClient.Subscriber.CreateSubscriber(new CreateSubscriberDTO
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

        Subscriber = subscriber;

        return subscriber;
    }
}