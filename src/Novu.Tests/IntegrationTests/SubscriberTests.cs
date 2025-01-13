using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Novu.Clients;
using Novu.Domain.Models.Subscribers;
using Novu.Extensions;
using Novu.Tests.Factories;
using Refit;
using Xunit;
using Xunit.DependencyInjection;

namespace Novu.Tests.IntegrationTests;

public class SubscriberTests(SubscriberFactory subscriberFactory, ISubscriberClient subscriberClient)
{
    [Fact]
    public async Task Should_Create_Subscriber()
    {
        var subscriber = await subscriberFactory.Make();
        Assert.NotNull(subscriber);
    }

    [Fact]
    public async Task Should_Get_One_Subscriber()
    {
        var testSub = await subscriberFactory.Make();
        var subscriber = await subscriberClient.Get(testSub.SubscriberId!);

        Assert.Equal(subscriber.Data.SubscriberId, testSub.SubscriberId);
    }

    [Fact]
    public async Task Should_Get_All_Subscribers()
    {
        async Task<IList<Subscriber>> GetAllSubscribers(
            int page = 0,
            int limit = 30 /* Max 100 */,
            IList<Subscriber> subscribers = null)
        {
            subscribers ??= new List<Subscriber>();
            var next = await subscriberClient.Get(page, limit);

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
    public async Task Should_Update_Subscriber()
    {
        var subToUpdate = await subscriberFactory.Make();

        subToUpdate.FirstName += " Updated";
        subToUpdate.LastName += " Update";

        var updatedSub = await subscriberClient.Update(subToUpdate.SubscriberId!, new SubscriberEditData
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
    public async Task Should_Delete_Subscriber()
    {
        var subscriber = await subscriberFactory.Make();
        var deleteResponse = await subscriberClient.DeleteSubscriber(subscriber.SubscriberId!);
        deleteResponse.Data.Acknowledged.Should().BeTrue();
    }

    [Fact]
    public async Task Should_Delete_Subscriber_DoesNotThrowOnGet()
    {
        var subscriber = await subscriberFactory.Make();
        subscriber.SubscriberId.Should().NotBeNull();
        await subscriberClient.DeleteSubscriber(subscriber.SubscriberId!);
        var response = await subscriberClient.Get(subscriber.SubscriberId);
        // note: return subscriber with null values
        response.Data.Should().BeNull();
    }

    [Theory(Skip = "Implement de-register exception handler")]
    [InlineData(null)]
    public async Task Should_Delete_Twice_Returns_NotFound([FromServices] IServiceCollection services)
    {
        services.RegisterNovuClients(ConfigurationExtensions.GetConfiguration("Integration"));
        services.BuildServiceProvider();

        // override the base exception trap to expose 404
        // DeRegisterExceptionHandler();

        var subscriber = await subscriberFactory.Make();
        var deleteResponse = await subscriberClient.DeleteSubscriber(subscriber.SubscriberId!);
        deleteResponse.Data.Acknowledged.Should().BeTrue();

        await Assert.ThrowsAsync<ApiException>(async () =>
            await subscriberClient.DeleteSubscriber(subscriber.SubscriberId));
    }

    [Fact]
    public async Task Should_Update_Online_Status()
    {
        var subscriber = await subscriberFactory.Make();
        var response = await subscriberClient.UpdateOnlineStatus(
            subscriber.SubscriberId!,
            new SubscriberOnlineEditData
            {
                IsOnline = true,
            });

        response.Data.Should().NotBeNull();
        response.Data.IsOnline.Should().BeTrue();
    }
}