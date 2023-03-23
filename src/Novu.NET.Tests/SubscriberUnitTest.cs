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
  public async void Should_Get_All_Subscribers()
  {
    var subscribers = await _fixture.NovuClient.Subscriber.GetSubscribers();

    Assert.True(subscribers.TotalCount > 0, "subscribers.TotalCount > 0");

    if (subscribers.TotalCount <= subscribers.PageSize) return;
    
    var secondPage = await _fixture.NovuClient.Subscriber.GetSubscribers(1);
    Assert.True(secondPage.TotalCount > 0, "secondPage.TotalCount > 0");
  }

  [Fact]
  public async void Should_Get_One_Subscriber()
  {
    var testSub = await _fixture.GenerateTestSubscriber();
    var subscriber = await _fixture.NovuClient.Subscriber.GetSubscriber(testSub.SubscriberId);
    
    Assert.Equal(subscriber.SubscriberId, testSub.SubscriberId);
  }

  [Fact]
  public async void Should_Update_Subscriber()
  {
    var subToUpdate = await _fixture.GenerateTestSubscriber();
    
    subToUpdate.FirstName = "Updated";
    subToUpdate.LastName = "Subscriber";
    
    var updatedSub = await _fixture.NovuClient.Subscriber.UpdateSubscriber(subToUpdate);
    
    // Check to make sure fields changed
    Assert.Equal(updatedSub.FirstName, subToUpdate.FirstName);
    Assert.Equal(updatedSub.LastName, subToUpdate.LastName);
    
    // Check to make sure field didn't change when it shouldn't have
    Assert.Equal(updatedSub.SubscriberId, subToUpdate.SubscriberId);
  }

  [Fact]
  public async void Should_Delete_Subscriber()
  {
    var subscriber = await _fixture.GenerateTestSubscriber();
    var deleteResponse = await _fixture.NovuClient.Subscriber.DeleteSubscriber(subscriber.SubscriberId);
    
    Assert.True(deleteResponse.Data.Acknowledged);
  }

  [Fact]
  public async void Should_Update_Online_Status()
  {
    var subscriber = await _fixture.GenerateTestSubscriber();
    var updateResponse = await _fixture.NovuClient.Subscriber.UpdateOnlineStatus(subscriber.SubscriberId, new SubscriberOnlineDTO
    {
      IsOnline = true
    });
    
    Assert.True(updateResponse.IsOnline);
  }
  

}