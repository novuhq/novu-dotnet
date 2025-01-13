using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.WorkflowGroups;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.Factories;

public class WorkflowGroupFactory(Tracker tracker, IWorkflowGroupClient client)
{
    public async Task<WorkflowGroup> Make(WorkflowGroupCreateData data = null)
    {
        var createData = data ?? new WorkflowGroupCreateData
        {
            Name = StringGenerator.LoremIpsum(10),
        };

        var workflowGroup = await client.Create(createData);
        tracker.WorkflowGroups.Add(workflowGroup.Data);
        return workflowGroup.Data;
    }
}