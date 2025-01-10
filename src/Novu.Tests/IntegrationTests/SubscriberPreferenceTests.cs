using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO.Subscribers;
using Novu.DTO.Subscribers.Preferences;
using Novu.DTO.Workflows;
using Novu.Interfaces;
using Novu.Models.Subscribers.Preferences;
using Novu.Models.Workflows;
using Novu.Tests.Factories;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class SubscriberPreferencesTests(
    ISubscriberClient subscriberClient,
    SubscriberFactory subscriberFactory,
    WorkflowFactory workflowFactory)
{
    [Fact]
    public async Task Should_Get_Preferences()
    {
        // a preference requires a workflow (so if the system was clean no preferences would be returned)
        await workflowFactory.Make<Workflow>(steps: [StepFactory.InApp()]);

        var subscriber = await subscriberFactory.Make<Subscriber>();
        subscriber.SubscriberId.Should().NotBeNull();
        var preferences = await subscriberClient.GetPreferences(subscriber.SubscriberId!);

        // fire forget test, that it returns something
        preferences.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Update_Preference_InApp()
    {
        // a preference requires a workflow (so if the system was clean no preferences would be returned)
        // The workflow must:
        //   - have the channel
        //   - be ACTIVE
        var workflow = await workflowFactory.Make<Workflow>(
            steps: [StepFactory.InApp()],
            active: true,
            preferenceChannels: new PreferenceChannels
            {
                InApp = true,
            });

        var subscriber = await subscriberFactory.Make<Subscriber>();
        subscriber.SubscriberId.Should().NotBeNull();
        var preferences = await subscriberClient.GetPreferences(subscriber.SubscriberId!);

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
        await subscriberClient.UpdatePreference(
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

        (await subscriberClient.GetPreferences(subscriber.SubscriberId!))
            .Data
            .SingleOrDefault(x => x.Preference.Channels.InApp is true && x.Template.Name == workflow.Name)
            .Should()
            .NotBeNull();
    }

    [Fact]
    public async Task Should_Get_InApp_Unseen()
    {
        var subscriber = await subscriberFactory.Make<Subscriber>();
        subscriber.SubscriberId.Should().NotBeNull();
        var messagesCount = await subscriberClient.GetInAppUnseen(subscriber.SubscriberId!);

        // fire forget test, that it returns something
        messagesCount.Data.Count.Should().BeGreaterOrEqualTo(0);
    }

    [Fact]
    public async Task Should_Get_InApp()
    {
        var subscriber = await subscriberFactory.Make<Subscriber>();
        subscriber.SubscriberId.Should().NotBeNull();
        var messages = await subscriberClient.GetInApp(subscriber.SubscriberId!);

        // fire forget test, that it returns something
        messages.Data.Should().HaveCountGreaterOrEqualTo(0);
    }
}