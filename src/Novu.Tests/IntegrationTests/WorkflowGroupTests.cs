using FluentAssertions;
using Novu.DTO.WorkflowGroups;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class WorkflowGroupTests : BaseIntegrationTest
{
    public WorkflowGroupTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async void Should_Create_WorkflowGroup()
    {
        var workflowGroup = await Make<WorkflowGroup>();
        workflowGroup.Should().NotBeNull();
    }

    [Fact]
    public async void Should_Return_WorkflowGroup_List()
    {
        await Make<WorkflowGroup>();
        var listOfWorkflowGroups = await WorkflowGroup.Get();

        Assert.NotNull(listOfWorkflowGroups);
        Assert.NotEmpty(listOfWorkflowGroups.Data);
    }

    [Fact]
    public async void Should_Delete_WorkflowGroup()
    {
        var workflowGroup = await Make<WorkflowGroup>();
        await WorkflowGroup.Delete(workflowGroup.Id);
    }
}