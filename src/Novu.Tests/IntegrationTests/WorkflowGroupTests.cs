using FluentAssertions;
using Novu.DTO.WorkflowGroup;
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
        var workflowGroup = await Make<WorkflowGroupSingleResponseDto>();
        workflowGroup.PayloadDto.Should().NotBeNull();
    }

    [Fact]
    public async void Should_Return_WorkflowGroup_List()
    {
        await Make<WorkflowGroupSingleResponseDto>();
        var listOfWorkflowGroups = await WorkflowGroup.GetWorkflowGroups();

        Assert.NotNull(listOfWorkflowGroups);
        Assert.NotEmpty(listOfWorkflowGroups.PayloadDtos);
    }

    [Fact]
    public async void Should_Delete_WorkflowGroup()
    {
        var workflowGroup = await Make<WorkflowGroupSingleResponseDto>();
        await WorkflowGroup.DeleteWorkflowGroupAsync(workflowGroup.PayloadDto.Id);
    }
}