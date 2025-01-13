using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Novu.Tests.Factories;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class FeedTests(FeedFactory feedFactory, IFeedClient feedClient)
{   
    [Fact]
    public async Task Should_Create_Feed()
    {
        var feed = await feedFactory.Make();
        feed.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_Feed_List()
    {
        await feedFactory.Make();
        var listOfFeeds = await feedClient.Get();

        Assert.NotNull(listOfFeeds);
        Assert.NotEmpty(listOfFeeds.Data);
    }

    [Fact]
    public async Task Should_Delete_Feed()
    {
        var feed = await feedFactory.Make();
        await feedClient.Delete(feed.Id);
    }
}