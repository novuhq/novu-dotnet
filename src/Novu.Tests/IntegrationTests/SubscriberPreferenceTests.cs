using System.Linq;
using FluentAssertions;
using Novu.DTO;
using Novu.DTO.Subscriber.Preferences;
using Novu.DTO.Workflows;
using Novu.Models.Subscriber.Preferences;
using Novu.Models.Workflows;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class SubscriberPreferencesTests : BaseIntegrationTest
{
    public SubscriberPreferencesTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async void Should_Get_Preferences()
    {
        // a preference requires a workflow (so if the system was clean no preferences would be returned)
        await Make<Workflow>(steps: new[] { StepFactory.InApp() });

        var subscriber = await Make<SubscriberDto>();
        subscriber.SubscriberId.Should().NotBeNull();
        var preferences = await Subscriber.GetPreferences(subscriber.SubscriberId!);

        // fire forget test, that it returns something
        preferences.Data.Should().NotBeNull();
    }

    [Fact]
    public async void Should_Update_Preference_InApp()
    {
        // a preference requires a workflow (so if the system was clean no preferences would be returned)
        // The workflow must:
        //   - have the channel
        //   - be ACTIVE
        var workflow = await Make<Workflow>(
            steps: new[] { StepFactory.InApp() },
            active: true,
            preferenceChannels: new PreferenceChannels
            {
                InApp = true,
            });

        var subscriber = await Make<SubscriberDto>();
        subscriber.SubscriberId.Should().NotBeNull();
        var preferences = await Subscriber.GetPreferences(subscriber.SubscriberId!);

        // The current workflow, get its setting
        var inAppPreference = preferences.Data.SingleOrDefault(x => x.Template.Name == workflow.Name);

        // is OFF on init
        inAppPreference.Should().NotBeNull();
        if (inAppPreference?.Preference.Channels.InApp is null)
        {
            return;
        }

        // update to ON
        inAppPreference.Preference.Channels.InApp.Value.Should().BeTrue();
        await Subscriber.UpdatePreference(
            subscriber.SubscriberId!,
            inAppPreference.Template.Id,
            new SubscriberPreferenceEditData
            {
                Channel = new Channel
                {
                    Type = ChannelTypeEnum.InApp,
                    Enabled = true,
                },
            });

        (await Subscriber.GetPreferences(subscriber.SubscriberId!))
            .Data
            .SingleOrDefault(x => x.Preference.Channels.InApp is true && x.Template.Name == workflow.Name)
            .Should()
            .NotBeNull();
    }

    [Fact]
    public async void Should_Get_InApp_Unseen()
    {
        var subscriber = await Make<SubscriberDto>();
        subscriber.SubscriberId.Should().NotBeNull();
        var messagesCount = await Subscriber.GetInAppUnseen(subscriber.SubscriberId!);

        // fire forget test, that it returns something
        messagesCount.Data.Count.Should().BeGreaterOrEqualTo(0);
    }

    [Fact]
    public async void Should_Get_InApp()
    {
        var subscriber = await Make<SubscriberDto>();
        subscriber.SubscriberId.Should().NotBeNull();
        var messages = await Subscriber.GetInApp(subscriber.SubscriberId!);

        // fire forget test, that it returns something
        messages.Data.Should().HaveCountGreaterOrEqualTo(0);
    }
}