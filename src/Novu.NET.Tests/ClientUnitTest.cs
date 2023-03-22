using Novu.NET.Clients;
using Novu.NET.Models;

namespace Novu.NET.Tests;

public class ClientUnitTest
{
  private readonly NovuClient NovuClient;

  public ClientUnitTest()
  {
    var novuConfiguration = new NovuClientConfiguration
    {
      ApiKey = Environment.GetEnvironmentVariable("NOVU_API_KEY"),
      ApplicationId = Environment.GetEnvironmentVariable("NOVU_APPLICATION_ID")
    };
    var novu = new NovuClient(novuConfiguration);

    NovuClient = novu;
  }

  [Fact]
  public void Client_Should_Create_With_Configuration()
  {
    var novuConfiguration = new NovuClientConfiguration
    {
      ApiKey = Environment.GetEnvironmentVariable("NOVU_API_KEY"),
      ApplicationId = Environment.GetEnvironmentVariable("NOVU_APPLICATION_ID")
    };
    var novu = new NovuClient(novuConfiguration);

    Assert.NotNull(novu);
  }

  [Fact]
  public async void Should_Create_Subscriber()
  {
    // ! Failing test unable to create subscriber - Bug: FFID-3584
    var additionalData = new Dictionary<string, string>
        {
            { "key", "value" },
            { "framework", ".NET"}
        };
    var subscriber = await NovuClient.Subscriber.CreateSubscriber(new CreateSubscriberModel
    {
      Id = "test-subscriber",
      FirstName = "Novu",
      LastName = ".NET",
      Avatar = "https://avatars.githubusercontent.com/u/77433905?s=200&v=4",
      Email = "noreply@novu.co",
      Locale = "en-US",
      Phone = "+11112223333",
      Data = additionalData
    });

    Assert.NotNull(subscriber);

  }

  [Fact]
  public async void Client_Should_Pull_All_Subscribers()
  {
    Assert.NotNull(NovuClient.Subscriber);

    var subscribers = await NovuClient.Subscriber.GetSubscribers();

    Assert.True(subscribers.TotalCount > 0, "subscribers.TotalCount > 0");
  }

  [Fact]
  public async void Client_Should_Pull_One_Subscriber()
  {
    var subscribers = await NovuClient.Subscriber.GetSubscribers();

    Assert.True(subscribers.TotalCount > 0, "subscribers.TotalCount > 0");

    var subscriber = await NovuClient.Subscriber.GetSubscriber(subscribers.Subscribers[0].Id);

    Assert.NotNull(subscriber);

    Assert.Equal(subscriber.Id, subscribers.Subscribers[0].Id);
  }


}