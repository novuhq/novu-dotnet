using System.Collections.Generic;
using FluentAssertions;
using Novu.DTO;
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
        var topic = await Make<TopicCreateResponseDto>();
        topic.Data.Key.Should().NotBeNull();
    }

    [Fact]
    public async void Should_Add_Subscriber_To_Topic()
    {
        var subscriber = await Make<SubscriberDto>();
        var topic = await Make<TopicCreateResponseDto>();
        var topicSubscribers = await Add<TopicSubscriberAdditionResponseDto>(subscriber, topic);

        topicSubscribers.Data.Succeeded.Should().ContainSingle();
        topicSubscribers.Data.Succeeded.Should().Contain(x => x == subscriber.SubscriberId);
    }

    [Fact]
    public async void Should_List_Topics()
    {
        await Make<TopicCreateResponseDto>();
        var topics = await Topic.GetTopicsAsync();
        topics.Data.Should().NotBeEmpty();
        // because of paging, it needs to look through more
        // topics.Data.Should().Contain(dto => dto.Key == topic.Data.Key);
    }

    [Fact]
    public async void Should_Validate_Topic_Subscriber()
    {
        var subscriber = await Make<SubscriberDto>();
        var topic = await Make<TopicCreateResponseDto>(null, subscriber);

        await Topic.VerifySubscriberAsync(topic.Data.Key, subscriber.SubscriberId!);
    }

    [Fact]
    public async void Should_Remove_Subscriber_From_Topic()
    {
        var subscriber = await Make<SubscriberDto>();
        var topic = await Make<TopicCreateResponseDto>(null, subscriber);

        await Topic.RemoveSubscriberAsync(
            topic.Data.Key,
            new TopicSubscriberUpdateDto(new List<string> { subscriber.SubscriberId }));
    }

    [Fact]
    public async void Should_Delete_Topic()
    {
        var topic = await Make<TopicCreateResponseDto>();
        await Topic.DeleteTopicAsync(topic.Data.Key);
        var result = await Topic.GetTopicAsync(topic.Data.Key);
        result.Data.Should().BeNull();
    }

    [Fact]
    public async void Should_Get_Single_Topic()
    {
        var topic = await Make<TopicCreateResponseDto>();

        var result = await Topic.GetTopicAsync(topic.Data.Key);
        result.Data.Should().NotBeNull();
        result.Data.Key.Should().Be(topic.Data.Key);
    }

    [Fact]
    public async void Should_Rename_Topic()
    {
        var topic = await Make<TopicCreateResponseDto>();

        var newTopicName = $"topic:test:rename-{StringGenerator.LoremIpsum(10)}";
        var result = await Topic.RenameTopicAsync(topic.Data.Key, new RenameTopicRequest(newTopicName));

        result.Data.Name.Should().Be(newTopicName);
    }
}