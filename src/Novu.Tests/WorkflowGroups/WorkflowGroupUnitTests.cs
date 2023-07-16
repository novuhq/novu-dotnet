using Novu.DTO.WorkflowGroup;

namespace Novu.Tests.WorkflowGroups
{
    public class WorkflowGroupUnitTests
    {
        public readonly WorkflowGroupFixture _fixture;

        public WorkflowGroupUnitTests(WorkflowGroupFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void Should_Create_WorkflowGroup()
        {
            var client = _fixture.NovuClient;

            var requestBody = new WorkflowGroupDto
            {
                WorkflowGroupName = "workflowGroup123"
            };

            var workflowGroup = await client.WorkflowGroup.CreateWorkflowGroup(requestBody);

            Assert.Equal(requestBody.WorkflowGroupName, workflowGroup.PayloadDto.Name);
        }

        [Fact]
        public async void Should_Return_WorkflowGroup_List()
        {
            var client = _fixture.NovuClient;

            var listOfWorkflowGroups = await client.WorkflowGroup.GetWorkflowGroups();

            Assert.NotNull(listOfWorkflowGroups);
            Assert.NotEmpty(listOfWorkflowGroups.PayloadDtos);
        }
    }
}
