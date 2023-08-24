using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.NotificationTemplates;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class NotificationTemplatesTests : BaseIntegrationTest
{
    public NotificationTemplatesTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(Skip = "Interface is deprecated")]
    public async Task Should_Get_Notification_Templates()
    {
        var templates = await NotificationTemplates.GetTemplates();
        templates.Should().NotBeNull();
        templates.Page.Should().Be(0);
        templates.Data.Should().NotBeEmpty();
    }

    [Fact(Skip = "Interface is deprecated")]
    public async Task Should_SetStatus()
    {
        var templates = await NotificationTemplates.GetTemplates();
        var template = templates.Data.First();
        var result = await NotificationTemplates.UpdateStatus(template.Id,
            new UpdateTemplateStatusRequest
            {
                Active = !template.Active,
            });
        result.Data.Should().NotBeNull();
        result.Data.Active.Should().Be(!template.Active);
    }
}