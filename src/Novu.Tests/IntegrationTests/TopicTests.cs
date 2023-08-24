using System.Collections.Generic;
using FluentAssertions;
using Novu.DTO;
using Novu.DTO.Subscribers;
using Novu.DTO.Topics;
using ParkSquare.Testing.Generators;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class TopicTests : BaseIntegrationTest
{
    public TopicTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async void Should_Create_Topic()
    {
        var topic = await Make<Topic>();
        topic.Key.Should().NotBeNull();
    }

    [Fact]
    public async void Should_Add_Subscriber_To_Topic()
    {
        var subscriber = await Make<Subscriber>();
        var topic = await Make<Topic>();
        var addSubscribers = await Add<SucceedData>(subscriber, topic);

        addSubscribers.Succeeded.Should().ContainSingle();
        addSubscribers.Succeeded.Should().Contain(x => x == subscriber.SubscriberId);
    }

    [Fact]
    public async void Should_List_Topics()
    {
        await Make<Topic>();
        var topics = await Topic.Get();
        topics.Data.Should().NotBeEmpty();
        // because of paging, it needs to look through more
        // topics.Data.Should().Contain(dto => dto.Key == topic.Key);
    }

    [Fact]
    public async void Should_Validate_Topic_Subscriber()
    {
        var subscriber = await Make<Subscriber>();
        var topic = await Make<Topic>(null, subscriber);

        await Topic.Verify(topic.Key, subscriber.SubscriberId!);
    }

    [Fact]
    public async void Should_Remove_Subscriber_From_Topic()
    {
        var subscriber = await Make<Subscriber>();
        var topic = await Make<Topic>(null, subscriber);

        await Topic.RemoveSubscriber(
            topic.Key,
            new TopicSubscriberCreateData(new List<string> { subscriber.SubscriberId }));
    }

    [Fact]
    public async void Should_Delete_Topic()
    {
        var topic = await Make<Topic>();
        await Topic.Delete(topic.Key);
        var result = await Topic.Get(topic.Key);
        result.Data.Should().BeNull();
    }

    [Fact]
    public async void Should_Get_Single_Topic()
    {
        var topic = await Make<Topic>();

        var result = await Topic.Get(topic.Key);
        result.Data.Should().NotBeNull();
        result.Data.Key.Should().Be(topic.Key);
    }

    [Fact]
    public async void Should_Rename_Topic()
    {
        var topic = await Make<Topic>();

        var newTopicName = $"topic:test:rename-{StringGenerator.LoremIpsum(10)}";
        var result = await Topic.Rename(topic.Key, new TopicEditData(newTopicName));

        result.Data.Name.Should().Be(newTopicName);
    }
}