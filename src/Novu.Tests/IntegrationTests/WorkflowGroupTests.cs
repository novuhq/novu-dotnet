using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO.WorkflowGroups;
using Novu.Interfaces;
using Novu.Tests.Factories;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class WorkflowGroupTests(WorkflowGroupFactory workflowGroupFactory, IWorkflowGroupClient workflowGroupClient)
{
    [Fact]
    public async Task Should_Create_WorkflowGroup()
    {
        var workflowGroup = await workflowGroupFactory.Make<WorkflowGroup>();
        workflowGroup.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_WorkflowGroup_List()
    {
        await workflowGroupFactory.Make<WorkflowGroup>();
        var listOfWorkflowGroups = await workflowGroupClient.Get();

        Assert.NotNull(listOfWorkflowGroups);
        Assert.NotEmpty(listOfWorkflowGroups.Data);
    }

    [Fact]
    public async Task Should_Delete_WorkflowGroup()
    {
        var workflowGroup = await workflowGroupFactory.Make<WorkflowGroup>();
        await workflowGroupClient.Delete(workflowGroup.Id);
    }
}