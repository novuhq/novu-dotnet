using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO;
using Refit;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class SubscriberTests : BaseIntegrationTest
{
    public SubscriberTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async void Should_Create_Subscriber()
    {
        var subscriber = await Make<SubscriberDto>();
        Assert.NotNull(subscriber);
    }

    [Fact]
    public async void Should_Get_One_Subscriber()
    {
        var testSub = await Make<SubscriberDto>();
        var subscriber = await Subscriber.GetSubscriber(testSub.SubscriberId!);

        Assert.Equal(subscriber.SubscriberId, testSub.SubscriberId);
    }

    [Fact]
    public async void Should_Get_All_Subscribers()
    {
        async Task<IList<SubscriberDto>> GetAllSubscribers(
            int page = 0,
            int limit = 30 /* Max 100 */,
            IList<SubscriberDto> subscribers = null)
        {
            subscribers ??= new List<SubscriberDto>();
            var next = await Subscriber.GetSubscribers(page, limit);

            foreach (var dto in next.Data)
            {
                subscribers.Add(dto);
            }

            if (next.HasMore)
            {
                var i = next.Page + 1;
                await GetAllSubscribers(i, next.PageSize, subscribers);
            }

            return subscribers;
        }

        var subscribers = await GetAllSubscribers();

        subscribers.Should().NotBeNull();
    }

    [Fact]
    public async void Should_Update_Subscriber()
    {
        var subToUpdate = await Make<SubscriberDto>();

        subToUpdate.FirstName += " Updated";
        subToUpdate.LastName += " Update";

        var updatedSub = await Subscriber.UpdateSubscriber(subToUpdate.SubscriberId!, subToUpdate);

        // Check to make sure fields changed
        Assert.Equal(updatedSub.FirstName, subToUpdate.FirstName);
        Assert.Equal(updatedSub.LastName, subToUpdate.LastName);

        // Check to make sure field didn't change when it shouldn't have
        Assert.Equal(updatedSub.SubscriberId, subToUpdate.SubscriberId);
    }

    [Fact]
    public async void Should_Delete_Subscriber()
    {
        var subscriber = await Make<SubscriberDto>();
        var deleteResponse = await Subscriber.DeleteSubscriber(subscriber.SubscriberId!);
        deleteResponse.Data.Acknowledged.Should().BeTrue();
    }

    [Fact]
    public async void Should_Delete_Subscriber_DoesNotThrowOnGet()
    {
        var subscriber = await Make<SubscriberDto>();
        subscriber.SubscriberId.Should().NotBeNull();
        await Subscriber.DeleteSubscriber(subscriber.SubscriberId!);
        subscriber = await Subscriber.GetSubscriber(subscriber.SubscriberId);
        // note: return subscriber with null values
        subscriber.SubscriberId.Should().BeNull();
    }

    [Fact]
    public async void Should_Delete_Twice_Returns_NotFound()
    {
        // override the base exception trap to expose 404
        DeRegisterExceptionHandler();

        var subscriber = await Make<SubscriberDto>();
        var deleteResponse = await Subscriber.DeleteSubscriber(subscriber.SubscriberId!);
        deleteResponse.Data.Acknowledged.Should().BeTrue();

        await Assert.ThrowsAsync<ApiException>(async () =>
            await Subscriber.DeleteSubscriber(subscriber.SubscriberId));
    }

    [Fact]
    public async void Should_Update_Online_Status()
    {
        var subscriber = await Make<SubscriberDto>();
        var updateResponse = await Subscriber.UpdateOnlineStatus(
            subscriber.SubscriberId!,
            new SubscriberOnlineDto
            {
                IsOnline = true,
            });

        updateResponse.IsOnline.Should().BeTrue();
    }
}