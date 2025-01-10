using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Novu.DTO;
using Novu.DTO.Integrations;
using Novu.Interfaces;
using Novu.Models.Integrations;
using Novu.Models.Subscribers.Preferences;
using Novu.Sync;
using Novu.Sync.Models;
using Novu.Sync.Services;
using Novu.Utils;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Novu.Tests.MicroTests.Sync;

public class SyncIntegrationTests(INovuSync<TemplateIntegration> syncClient, ITestOutputHelper output, ILogger<SyncIntegrationTests> log)
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
            null,
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
            null,
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
            null,
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
            null,
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
            null,
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
        Func<Times> deleteCalls,
        [FromServices] Mock<IIntegrationClient> client
    )
    {
        log.LogInformation("{0}", test);

        client.Reset();
        client
            .Setup(x => x.Get())
            .ReturnsAsync(new NovuResponse<IEnumerable<Integration>>(currentSetAtDestination));

        await syncClient.Sync(templateIntegrations);

        client.Verify(x => x.Get(), getCalls);
        client.Verify(x => x.Create(It.IsAny<IntegrationCreateData>()), createCalls);
        client.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<IntegrationEditData>()), updateCalls);
        client.Verify(x => x.Delete(It.IsAny<string>()), deleteCalls);
    }


    /// <summary>
    ///     Automatically bootstrapped through Xunit lifecycle
    ///     see https://github.com/pengweiqhca/Xunit.DependencyInjection
    /// </summary>
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
        {
            var client = new Mock<IIntegrationClient>();

            services
                .ConfigureTestServices(context)
                .RegisterNovuSync()
                // inject the  mock into each test
                .AddScoped(typeof(Mock<IIntegrationClient>), _ => client)
                // override the registered service with a mock
                .AddScoped(_ => client.Object);
        }
    }
}