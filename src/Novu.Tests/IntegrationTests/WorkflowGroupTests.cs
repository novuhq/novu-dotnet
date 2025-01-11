using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Novu.Tests.Factories;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class WorkflowGroupTests(WorkflowGroupFactory workflowGroupFactory, IWorkflowGroupClient workflowGroupClient)
{
    [Fact]
    public async Task Should_Create_WorkflowGroup()
    {
        var workflowGroup = await workflowGroupFactory.Make();
        workflowGroup.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_WorkflowGroup_List()
    {
        await workflowGroupFactory.Make();
        var listOfWorkflowGroups = await workflowGroupClient.Get();

        Assert.NotNull(listOfWorkflowGroups);
        Assert.NotEmpty(listOfWorkflowGroups.Data);
    }

    [Fact]
    public async Task Should_Delete_WorkflowGroup()
    {
        var workflowGroup = await workflowGroupFactory.Make();
        await workflowGroupClient.Delete(workflowGroup.Id);
    }
}