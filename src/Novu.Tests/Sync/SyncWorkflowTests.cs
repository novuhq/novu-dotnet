using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Novu.DTO;
using Novu.DTO.Workflows;
using Novu.Interfaces;
using Novu.Models.Workflows;
using Novu.Sync;
using Novu.Sync.Models;
using Novu.Tests.IntegrationTests;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.Sync;

public class SyncWorkflowTests : BaseIntegrationTest
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

    private readonly Mock<IWorkflowClient> _workflowClient;

    public SyncWorkflowTests(ITestOutputHelper output) : base(output)
    {
        _workflowClient = new Mock<IWorkflowClient>();

        // looks to be a need to registered the swapped out implementations before any are
        // instantiated. Expectations are set in the tests.
        Register(
            services => { services.SwapTransient(_ => _workflowClient.Object); });
    }

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
        Func<Times> deleteCalls
    )
    {
        Output.WriteLine(test);

        _workflowClient
            .Setup(x => x.Get(It.IsAny<PaginationQueryParams>()))
            .ReturnsAsync(new NovuPaginatedResponse<Workflow>
            {
                HasMore = false,
                Data = currentSetAtDestination.ToArray(),
            });

        var syncClient = Get<WorkflowSync>();

        await syncClient.Workflows(templateWorkflows);

        _workflowClient.Verify(x => x.Get(It.IsAny<PaginationQueryParams>()), getCalls);
        _workflowClient.Verify(x => x.Create(It.IsAny<WorkflowCreateData>()), createCalls);
        _workflowClient.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<WorkflowEditData>()), updateCalls);
        _workflowClient.Verify(x => x.Delete(It.IsAny<string>()), deleteCalls);
    }
}