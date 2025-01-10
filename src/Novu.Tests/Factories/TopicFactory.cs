using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novu.DTO;
using Novu.DTO.Subscribers;
using Novu.DTO.Topics;
using Novu.Interfaces;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.Factories;

public class TopicFactory(Tracker tracker, ITopicClient client)
{
    public async Task<T> Make<T>(
        TopicCreateData data = null,
        Subscriber subscriber = null,
        List<Subscriber> additionalSubscribers = null)
        where T : Topic
    {
        var createData = data ?? new TopicCreateData
        {
            Key = $"test:{NumberGenerator.RandomNumberBetween(600, 100000)}",
            Name = StringGenerator.LoremIpsum(10),
        };

        var result = await client.Create(createData);
        var topic = result.Data;

        if (subscriber is not null)
        {
            await AddSubscriber<SucceedData>(topic, subscriber, additionalSubscribers);
        }

        if (topic is not null)
        {
            tracker.Topics.Add(topic);
        }

        return topic as T;
    }

    public async Task<T> AddSubscriber<T>(Topic topic,
        Subscriber subscriber,
        List<Subscriber> additionalSubscribers = null)
        where T : SucceedData
    {
        var subscribers = additionalSubscribers is not null
            ? additionalSubscribers.Select(x => x.SubscriberId).Prepend(subscriber.SubscriberId).ToList()
            : [subscriber.SubscriberId];

        var subscriberList = new TopicSubscriberCreateData(subscribers);
        var subscribersResults = await client.AddSubscriber(topic.Key, subscriberList);
        tracker.Topics.Add(topic);
        return subscribersResults.Data as T;
    }
}