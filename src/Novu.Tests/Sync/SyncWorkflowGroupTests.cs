using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Novu.DTO;
using Novu.DTO.WorkflowGroups;
using Novu.Interfaces;
using Novu.Sync.Models;
using Novu.Sync.Services;
using Novu.Tests.IntegrationTests;
using ParkSquare.Testing.Generators;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.Sync;

public class SyncWorkflowGroupTests : BaseIntegrationTest
{
    private readonly Mock<IWorkflowGroupClient> _workflowGroupClient;

    public SyncWorkflowGroupTests(ITestOutputHelper output) : base(output)
    {
        _workflowGroupClient = new Mock<IWorkflowGroupClient>();

        // looks to be a need to registered the swapped out implementations before any are
        // instantiated. Expectations are set in the tests.
        Register(
            services => { services.SwapTransient(_ => _workflowGroupClient.Object); });
    }

    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[]
        {
            "both sides empty",
            Array.Empty<TemplateWorkflowGroup>(),
            Array.Empty<WorkflowGroup>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "new template - create at dest",
            new List<TemplateWorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            Array.Empty<WorkflowGroup>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "same on both sides - no changes",
            new List<TemplateWorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            new List<WorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "template changed - update dest (recreate)",
            new List<TemplateWorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(5),
                },
            },
            new List<WorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            (Func<Times>)Times.Once,
            // an update is a delete and create
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Once,
        },
        new object[]
        {
            "template removed - delete at dest",
            Array.Empty<TemplateWorkflowGroup>(),
            new List<WorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Once,
        },
    };


    [Theory]
    [MemberData(nameof(Data))]
    public async Task Tests(
        string test,
        IList<TemplateWorkflowGroup> templateWorkflowGroups,
        IList<WorkflowGroup> currentSetAtDestination,
        Func<Times> getCalls,
        Func<Times> createCalls,
        Func<Times> deleteCalls
    )
    {
        Output.WriteLine(test);

        _workflowGroupClient
            .Setup(x => x.Get())
            .ReturnsAsync(new NovuResponse<IEnumerable<WorkflowGroup>>(currentSetAtDestination.ToList()));

        var syncClient = Get<INovuSync<TemplateWorkflowGroup>>();

        await syncClient.Sync(templateWorkflowGroups);

        _workflowGroupClient.Verify(x => x.Get(), getCalls);
        _workflowGroupClient.Verify(x => x.Create(It.IsAny<WorkflowGroupCreateData>()), createCalls);
        _workflowGroupClient.Verify(x => x.Delete(It.IsAny<string>()), deleteCalls);
    }
}