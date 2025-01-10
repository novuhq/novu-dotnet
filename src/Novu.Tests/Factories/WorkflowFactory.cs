using System.Threading.Tasks;
using Novu.DTO.WorkflowGroups;
using Novu.DTO.Workflows;
using Novu.Interfaces;
using Novu.Models.Workflows;
using Novu.Models.Workflows.Step;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.Factories;

public class WorkflowFactory(Tracker tracker, IWorkflowClient workflowClient, WorkflowGroupFactory workflowGroupFactory)
{
    public async Task<Workflow> Make(
        WorkflowCreateData data = null,
        Step[] steps = null,
        bool active = false,
        PreferenceChannels preferenceChannels = null)
    {
        // the simplest workflow is empty without steps and this returns a workflow with a trigger
        var createData = data ?? new WorkflowCreateData
        {
            Name = StringGenerator.SequenceOfAlphaNumerics(10),
            Description = StringGenerator.LoremIpsum(5),
            PreferenceSettings = new PreferenceChannels(),
            Steps = steps ?? [],
            Active = active,
        };

        if (string.IsNullOrWhiteSpace(createData.WorkflowGroupId))
        {
            var group = await workflowGroupFactory.Make();
            createData.WorkflowGroupId = group.Id;
        }

        var workflow = await workflowClient.Create(createData);
        tracker.Workflows.Add(workflow.Data);
        return workflow.Data;
    }
}