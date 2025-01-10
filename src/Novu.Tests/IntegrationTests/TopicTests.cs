using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO;
using Novu.DTO.Subscribers;
using Novu.DTO.Topics;
using Novu.Interfaces;
using Novu.Tests.Factories;
using ParkSquare.Testing.Generators;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class TopicTests(
    TopicFactory topicFactory,
    SubscriberFactory subscriberFactory,
    ITopicClient topicClient,
    Tracker tracker)
    : IAsyncLifetime
{
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await tracker.RemoveAll();
    }

    [Fact]
    public async Task Should_Create_Topic()
    {
        var topic = await topicFactory.Make<Topic>();
        topic.Key.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Add_Subscriber_To_Topic()
    {
        var subscriber = await subscriberFactory.Make<Subscriber>();
        var topic = await topicFactory.Make<Topic>();
        var addSubscribers = await topicFactory.AddSubscriber<SucceedData>(topic, subscriber);

        addSubscribers.Succeeded.Should().ContainSingle();
        addSubscribers.Succeeded.Should().Contain(x => x == subscriber.SubscriberId);
    }

    [Fact]
    public async Task Should_List_Topics()
    {
        await topicFactory.Make<Topic>();
        var topics = await topicClient.Get();
        topics.Data.Should().NotBeEmpty();
        // because of paging, it needs to look through more
        // topics.Data.Should().Contain(dto => dto.Key == topic.Key);
    }

    [Fact]
    public async Task Should_Validate_Topic_Subscriber()
    {
        var subscriber = await subscriberFactory.Make<Subscriber>();
        var topic = await topicFactory.Make<Topic>(null, subscriber);

        await topicClient.Verify(topic.Key, subscriber.SubscriberId!);
    }

    [Fact]
    public async Task Should_Remove_Subscriber_From_Topic()
    {
        var subscriber = await subscriberFactory.Make<Subscriber>();
        var topic = await topicFactory.Make<Topic>(null, subscriber);

        await topicClient.RemoveSubscriber(
            topic.Key,
            new TopicSubscriberCreateData([subscriber.SubscriberId]));
    }

    [Fact]
    public async Task Should_Delete_Topic()
    {
        var topic = await topicFactory.Make<Topic>();
        await topicClient.Delete(topic.Key);
        var result = await topicClient.Get(topic.Key);
        result.Data.Should().BeNull();
    }

    [Fact]
    public async Task Should_Get_Single_Topic()
    {
        var topic = await topicFactory.Make<Topic>();

        var result = await topicClient.Get(topic.Key);
        result.Data.Should().NotBeNull();
        result.Data.Key.Should().Be(topic.Key);
    }

    [Fact]
    public async Task Should_Rename_Topic()
    {
        var topic = await topicFactory.Make<Topic>();

        var newTopicName = $"topic:test:rename-{StringGenerator.LoremIpsum(10)}";
        var result = await topicClient.Rename(topic.Key, new TopicEditData(newTopicName));

        result.Data.Name.Should().Be(newTopicName);
    }
}