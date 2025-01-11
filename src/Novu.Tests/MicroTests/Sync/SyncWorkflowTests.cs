using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Novu.Clients;
using Novu.Domain.Models;
using Novu.Domain.Models.Workflows;
using Novu.QueryParams;
using Novu.Sync;
using Novu.Sync.Models;
using Novu.Sync.Services;
using Novu.Tests.IntegrationTests;
using Xunit;
using Xunit.DependencyInjection;

namespace Novu.Tests.MicroTests.Sync;

public class SyncWorkflowTests(INovuSync<TemplateWorkflow> syncClient, ILogger<SyncWorkflowTests> log)
{
    private static readonly TemplateWorkflow InviteInAppSms = new()
    {
        Name = "Invite",
        Description = "Users are notified of an invitation",
        PreferenceSettings = new PreferenceChannels
        {
            InApp = true,
            Sms = true,
            Email = true,
        },
        Steps = new[]
        {
            StepFactory.InApp(true),
            StepFactory.Sms(true),
            StepFactory.DigestRegular(true),
            StepFactory.Email(true),
        },
        Active = true,
    };

    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[]
        {
            "both sides empty",
            Array.Empty<TemplateWorkflow>(),
            Array.Empty<Workflow>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            null,
        },
        new object[]
        {
            "new template - create at dest",
            new List<TemplateWorkflow>
            {
                InviteInAppSms,
            },
            Array.Empty<Workflow>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            null,
        },
        new object[]
        {
            "same on both sides - no changes",
            new List<TemplateWorkflow>
            {
                InviteInAppSms,
            },
            new List<Workflow>
            {
                new()
                {
                    Name = InviteInAppSms.Name,
                    Description = InviteInAppSms.Description,
                    PreferenceSettings = InviteInAppSms.PreferenceSettings,
                    Steps = InviteInAppSms.Steps,
                    Active = InviteInAppSms.Active,
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
            new List<TemplateWorkflow>
            {
                InviteInAppSms,
            },
            new List<Workflow>
            {
                new()
                {
                    Name = InviteInAppSms.Name,
                    Description = InviteInAppSms.Name + "original",
                    PreferenceSettings = InviteInAppSms.PreferenceSettings,
                    Steps = InviteInAppSms.Steps,
                    Active = InviteInAppSms.Active,
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
            Array.Empty<TemplateWorkflow>(),
            new List<Workflow>
            {
                new()
                {
                    Name = InviteInAppSms.Name,
                    Description = InviteInAppSms.Name,
                    PreferenceSettings = InviteInAppSms.PreferenceSettings,
                    Steps = InviteInAppSms.Steps,
                    Active = InviteInAppSms.Active,
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
        IList<TemplateWorkflow> templateWorkflows,
        IList<Workflow> currentSetAtDestination,
        Func<Times> getCalls,
        Func<Times> createCalls,
        Func<Times> updateCalls,
        Func<Times> deleteCalls,
        [FromServices] Mock<IWorkflowClient> client
    )
    {
        log.LogInformation(test);

        client.Reset();
        client
            .Setup(x => x.Get(It.IsAny<PaginationQueryParams>()))
            .ReturnsAsync(new NovuPaginatedResponse<Workflow>
            {
                HasMore = false,
                Data = currentSetAtDestination.ToArray(),
            });

        await syncClient.Sync(templateWorkflows);

        client.Verify(x => x.Get(It.IsAny<PaginationQueryParams>()), getCalls);
        client.Verify(x => x.Create(It.IsAny<WorkflowCreateData>()), createCalls);
        client.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<WorkflowEditData>()), updateCalls);
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
            var client = new Mock<IWorkflowClient>();

            services
                .ConfigureTestServices(context)
                .RegisterNovuSync()
                // inject the  mock into each test
                .AddScoped(typeof(Mock<IWorkflowClient>), _ => client)
                // override the registered service with a mock
                .AddScoped(_ => client.Object);
        }
    }
}