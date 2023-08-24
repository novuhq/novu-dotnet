using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Novu.DTO;
using Novu.DTO.Integrations;
using Novu.Interfaces;
using Novu.Models.Integrations;
using Novu.Models.Subscribers.Preferences;
using Novu.Sync;
using Novu.Sync.Models;
using Novu.Tests.IntegrationTests;
using Novu.Utils;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.Sync;

public class SyncIntegrationTests : BaseIntegrationTest
{
    private static readonly TemplateIntegration NovuInAppTemplateIntegration = new()
    {
        Identifier = "novu-in-app-e2e-tests-XJJHG",
        ProviderId = "novu",
        Channel = ChannelTypeEnum.InApp,
        Name = "Novu In-App",
        Active = true,
        Credentials = new Credentials
        {
            Hmac = true,
        },
    };

    private readonly Mock<IIntegrationClient> _integrationClient;

    public SyncIntegrationTests(ITestOutputHelper output) : base(output)
    {
        _integrationClient = new Mock<IIntegrationClient>();

        // looks to be a need to registered the swapped out implementations before any are
        // instantiated. Expectations are set in the tests.
        Register(
            services => { services.SwapTransient(_ => _integrationClient.Object); });
    }

    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[]
        {
            "both sides empty",
            Array.Empty<TemplateIntegration>(),
            Array.Empty<Integration>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "new template - create at dest",
            new List<TemplateIntegration>
            {
                NovuInAppTemplateIntegration,
            },
            Array.Empty<Integration>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "same on both sides - no changes",
            new List<TemplateIntegration>
            {
                NovuInAppTemplateIntegration,
            },
            new List<Integration>
            {
                new()
                {
                    Identifier = NovuInAppTemplateIntegration.Identifier,
                    Channel = NovuInAppTemplateIntegration.Channel.ToEnumString(),
                    ProviderId = NovuInAppTemplateIntegration.ProviderId,
                    Active = NovuInAppTemplateIntegration.Active,
                    Credentials = NovuInAppTemplateIntegration.Credentials,
                    Name = NovuInAppTemplateIntegration.Name,
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "template changed - update dest",
            new List<TemplateIntegration>
            {
                NovuInAppTemplateIntegration,
            },
            new List<Integration>
            {
                new()
                {
                    Identifier = NovuInAppTemplateIntegration.Identifier,
                    Channel = NovuInAppTemplateIntegration.Channel.ToEnumString(),
                    ProviderId = NovuInAppTemplateIntegration.ProviderId,
                    Active = !NovuInAppTemplateIntegration.Active, // changed
                    Credentials = new Credentials
                    {
                        Hmac = false, // changed
                    },
                    Name = NovuInAppTemplateIntegration.Name,
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "template removed - delete at dest",
            Array.Empty<TemplateIntegration>(),
            new List<Integration>
            {
                new()
                {
                    Identifier = NovuInAppTemplateIntegration.Identifier,
                    Channel = NovuInAppTemplateIntegration.Channel.ToEnumString(),
                    ProviderId = NovuInAppTemplateIntegration.ProviderId,
                    Active = NovuInAppTemplateIntegration.Active,
                    Credentials = NovuInAppTemplateIntegration.Credentials,
                    Name = NovuInAppTemplateIntegration.Name,
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Once,
        },
    };


    [Theory]
    [MemberData(nameof(Data))]
    public async Task Tests(
        string test,
        IList<TemplateIntegration> templateIntegrations,
        IList<Integration> currentSetAtDestination,
        Func<Times> getCalls,
        Func<Times> createCalls,
        Func<Times> updateCalls,
        Func<Times> deleteCalls
    )
    {
        Output.WriteLine(test);

        _integrationClient
            .Setup(x => x.Get())
            .ReturnsAsync(new NovuResponse<IEnumerable<Integration>>(currentSetAtDestination));

        var syncClient = Get<IntegrationSync>();

        await syncClient.Integrations(templateIntegrations);

        _integrationClient.Verify(x => x.Get(), getCalls);
        _integrationClient.Verify(x => x.Create(It.IsAny<IntegrationCreateData>()), createCalls);
        _integrationClient.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<IntegrationEditData>()), updateCalls);
        _integrationClient.Verify(x => x.Delete(It.IsAny<string>()), deleteCalls);
    }
}