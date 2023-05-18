using FluentAssertions;
using Novu.Models;

namespace Novu.Tests;

public class NotificationTemplatesTests
{
    private readonly NovuClient _client;

    public NotificationTemplatesTests()
    {
        _client = new NovuClient(new NovuClientConfiguration
        {
            ApiKey = "e59bd17abbed6c194f188f9987331864"
        });
    }
    [Fact]
    public async Task Should_Get_Notification_Templates()
    {
        var templates = await _client.NotificationTemplates.GetTemplates();
        templates.Should().NotBeNull();
        templates.Page.Should().Be(0);
        templates.Data.Should().NotBeEmpty();
    }
    [Fact]
    public async Task Should_Get_Notification_Template()
    {
        // TODO:
    }

    [Fact]
    public async Task Should_Create_Notification_Template()
    {
        // TODO:
    }
    [Fact]
    public async Task Should_Delete_Notification_Template()
    {
        // TODO:
    }

    [Fact]
    public async Task Should_SetStatus()
    {
        var templates = await _client.NotificationTemplates.GetTemplates();
        var template = templates.Data.First();
        var result = await _client.NotificationTemplates.UpdateStatus(template.Id, new(!template.Active));
        result.Data.Should().NotBeNull();
        result.Data.Active.Should().Be(!template.Active);
    }
}