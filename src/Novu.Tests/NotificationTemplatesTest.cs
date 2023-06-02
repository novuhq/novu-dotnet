using FluentAssertions;
using Novu.Models;
using Novu.NotificationTemplates;

namespace Novu.Tests;

public class NotificationTemplatesTest
{
    private readonly NovuClient _client;

    public NotificationTemplatesTest()
    {
        _client = new NovuClient(new NovuClientConfiguration
        {
            ApiKey = Environment.GetEnvironmentVariable("NOVU_API_KEY") ?? throw new InvalidOperationException("NOVU_API_KEY is not set.")
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
        var result = await _client.NotificationTemplates.UpdateStatus(template.Id, new UpdateTemplateStatusRequest
        {
            Active = !template.Active
        });
        result.Data.Should().NotBeNull();
        result.Data.Active.Should().Be(!template.Active);
    }
}