using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Novu.Domain.Models.WorkflowOverrides;
using Novu.Tests.Factories;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class WorkflowOverridesTests(
    Tracker tracker,
    WorkflowOverrideFactory workflowOverrideFactory,
    IWorkflowOverrideClient workflowOverrideClient) : IAsyncLifetime
{
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await tracker.RemoveAll();
    }

    [Fact]
    public async Task Should_Create_WorkflowOverrides()
    {
        var workflowOverrides = await workflowOverrideFactory.Make();
        workflowOverrides.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_WorkflowOverrides_List()
    {
        var workflowOverride = await workflowOverrideFactory.Make();
        var returnOverride = await workflowOverrideClient.Get();
        returnOverride.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Should_Return_WorkflowOverride()
    {
        var workflowOverride = await workflowOverrideFactory.Make();
        var returnOverride = await workflowOverrideClient.Get(workflowOverride.WorkflowId, workflowOverride.TenantId);
        returnOverride.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Update_WorkflowOverride_On_Id()
    {
        var workflowOverride = await workflowOverrideFactory.Make();
        var returnOverride = await workflowOverrideClient.Update(workflowOverride.Id, new WorkflowOverrideEditData()
        {
            Active = true,
        });
        returnOverride.Data.Should().NotBeNull();
        returnOverride.Data.Active.Should().BeTrue();
    }

    [Fact]
    public async Task Should_Update_WorkflowOverride_On_Workflow_Tenant()
    {
        var workflowOverride = await workflowOverrideFactory.Make();
        var returnOverride = await workflowOverrideClient.Update(workflowOverride.WorkflowId, workflowOverride.TenantId, new WorkflowOverrideEditData()
        {
            Active = true,
        });
        returnOverride.Data.Should().NotBeNull();
        returnOverride.Data.Active.Should().BeTrue();
    }

    [Fact]
    public async Task Should_Delete_WorkflowOverrides()
    {
        var workflowOverrides = await workflowOverrideFactory.Make();
        await workflowOverrideClient.Delete(workflowOverrides.Id);
    }
}