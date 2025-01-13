using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.Feeds;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.Factories;

public class FeedFactory(Tracker tracker, IFeedClient client)
{
    public async Task<Feed> Make(FeedCreateData data = null)
    {
        var createData = data ?? new FeedCreateData
        {
            Name = StringGenerator.SequenceOfAlphaNumerics(50),
        };

        var feed = await client.Create(createData);
        tracker.Feeds.Add(feed.Data);
        return feed.Data;
    }
}