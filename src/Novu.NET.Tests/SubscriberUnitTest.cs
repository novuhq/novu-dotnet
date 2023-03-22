using Novu.NET.Clients;
using Novu.NET.DTO;
using Novu.NET.Tests.Fixtures;

namespace Novu.NET.Tests;

public class SubscriberUnitTest : IClassFixture<SubscriberFixture>
{

  private readonly SubscriberFixture _fixture;

  public SubscriberUnitTest(SubscriberFixture fixture)
  {
    _fixture = fixture;
  }

  [Fact]
  public async void Should_Create_Subscriber()
  {
    var subscriber = await  _fixture.GenerateTestSubscriber();
    Assert.NotNull(subscriber);
    
    // Clean up

    await _fixture.NovuClient.Subscriber.DeleteSubscriber(subscriber.SubscriberId);
  }

  [Fact]
  public async void Client_Should_Pull_All_Subscribers()
  {
    var subscribers = await _fixture.NovuClient.Subscriber.GetSubscribers();

    Assert.True(subscribers.TotalCount > 0, "subscribers.TotalCount > 0");
  }

  [Fact]
  public async void Client_Should_Pull_One_Subscriber()
  {
    var testSub = await _fixture.GenerateTestSubscriber();
    var subscriber = await _fixture.NovuClient.Subscriber.GetSubscriber(testSub.SubscriberId);
    
    Assert.Equal(subscriber.SubscriberId, testSub.SubscriberId);
  }


}