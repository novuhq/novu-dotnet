using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.Tenants;
using Novu.Domain.Models.WorkflowOverrides;
using Novu.Domain.Models.Workflows;

namespace Novu.Tests.Factories;

public class WorkflowOverrideFactory(
    Tracker tracker,
    IWorkflowOverrideClient client,
    TenantFactory tenantFactory,
    WorkflowFactory workflowFactory)
{
    public async Task<WorkflowOverride> Make(
        Tenant tenant = null,
        Workflow workflow = null,
        WorkflowOverrideCreateData data = null)
    {
        tenant ??= await tenantFactory.Make();
        workflow ??= await workflowFactory.Make();

        var createData = data ?? new WorkflowOverrideCreateData
        {
            Active = false,
            PreferenceSettings = new PreferenceChannels()
            {
                InApp = true,
            },
            TenantId = tenant.Id,
            WorkflowId = workflow.Id,
        };

        var workflowOverrides = await client.Create(createData);
        tracker.WorkflowOverrides.Add(workflowOverrides.Data);
        return workflowOverrides.Data;
    }
}