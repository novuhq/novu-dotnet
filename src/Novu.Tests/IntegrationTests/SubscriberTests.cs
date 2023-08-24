using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO.Subscribers;
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
        var subscriber = await Make<Subscriber>();
        Assert.NotNull(subscriber);
    }

    [Fact]
    public async void Should_Get_One_Subscriber()
    {
        var testSub = await Make<Subscriber>();
        var subscriber = await Subscriber.Get(testSub.SubscriberId!);

        Assert.Equal(subscriber.Data.SubscriberId, testSub.SubscriberId);
    }

    [Fact]
    public async void Should_Get_All_Subscribers()
    {
        async Task<IList<Subscriber>> GetAllSubscribers(
            int page = 0,
            int limit = 30 /* Max 100 */,
            IList<Subscriber> subscribers = null)
        {
            subscribers ??= new List<Subscriber>();
            var next = await Subscriber.Get(page, limit);

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
        var subToUpdate = await Make<Subscriber>();

        subToUpdate.FirstName += " Updated";
        subToUpdate.LastName += " Update";

        var updatedSub = await Subscriber.Update(subToUpdate.SubscriberId!, new SubscriberEditData
        {
            Data = subToUpdate.Data,
            FirstName = subToUpdate.FirstName,
            LastName = subToUpdate.LastName,
            Locale = subToUpdate.Locale,
            Avatar = subToUpdate.Avatar,
            EnvironmentId = subToUpdate.EnvironmentId,
            Channels = subToUpdate.Channels,
            Deleted = subToUpdate.Deleted,
            Email = subToUpdate.Email,
            Phone = subToUpdate.Phone,
            IsOnline = subToUpdate.IsOnline,
            SubscriberId = subToUpdate.SubscriberId,
            CreatedAt = subToUpdate.CreatedAt,
            OrganizationId = subToUpdate.OrganizationId,
            UpdatedAt = subToUpdate.UpdatedAt,
            LastOnlineAt = subToUpdate.LastOnlineAt,
        });

        updatedSub.Data.Should().NotBeNull();

        if (updatedSub.Data is not null)
        {
            // Check to make sure fields changed
            Assert.Equal(updatedSub.Data.FirstName, subToUpdate.FirstName);
            Assert.Equal(updatedSub.Data.LastName, subToUpdate.LastName);

            // Check to make sure field didn't change when it shouldn't have
            Assert.Equal(updatedSub.Data.SubscriberId, subToUpdate.SubscriberId);
        }
    }

    [Fact]
    public async void Should_Delete_Subscriber()
    {
        var subscriber = await Make<Subscriber>();
        var deleteResponse = await Subscriber.DeleteSubscriber(subscriber.SubscriberId!);
        deleteResponse.Data.Acknowledged.Should().BeTrue();
    }

    [Fact]
    public async void Should_Delete_Subscriber_DoesNotThrowOnGet()
    {
        var subscriber = await Make<Subscriber>();
        subscriber.SubscriberId.Should().NotBeNull();
        await Subscriber.DeleteSubscriber(subscriber.SubscriberId!);
        var response = await Subscriber.Get(subscriber.SubscriberId);
        // note: return subscriber with null values
        response.Data.Should().BeNull();
    }

    [Fact]
    public async void Should_Delete_Twice_Returns_NotFound()
    {
        // override the base exception trap to expose 404
        DeRegisterExceptionHandler();

        var subscriber = await Make<Subscriber>();
        var deleteResponse = await Subscriber.DeleteSubscriber(subscriber.SubscriberId!);
        deleteResponse.Data.Acknowledged.Should().BeTrue();

        await Assert.ThrowsAsync<ApiException>(async () =>
            await Subscriber.DeleteSubscriber(subscriber.SubscriberId));
    }

    [Fact]
    public async void Should_Update_Online_Status()
    {
        var subscriber = await Make<Subscriber>();
        var response = await Subscriber.UpdateOnlineStatus(
            subscriber.SubscriberId!,
            new SubscriberOnlineEditData
            {
                IsOnline = true,
            });

        response.Data.Should().NotBeNull();
        response.Data.IsOnline.Should().BeTrue();
    }
}