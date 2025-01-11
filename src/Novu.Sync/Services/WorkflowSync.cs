using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.Workflows;
using Novu.Sync.Comparers;
using Novu.Sync.Models;
using Novu.Sync.Utils;

namespace Novu.Sync.Services;

public class WorkflowSync :  INovuSync<TemplateWorkflow>
{
    private readonly IWorkflowClient _workflowClient;

    public WorkflowSync(IWorkflowClient workflowClient)
    {
        _workflowClient = workflowClient;
    }

    public async Task Sync(TemplateWorkflow templateTemplateWorkflow)
    {
        await Sync(new[] { templateTemplateWorkflow });
    }

    /// <summary>
    ///     Take list of template workflows and look through the Sync found on an organisation and synchronise.
    ///     Note: this current implementation takes control of an environment and deletes anything unknown to the templates
    /// </summary>
    /// <exception cref="AggregateException">
    ///     The <see cref="AggregateException.InnerExceptions" /> will return list of <see cref="Refit.ApiException" />
    /// </exception>
    public async Task Sync(IEnumerable<TemplateWorkflow> templateWorkflows)
    {
        var src = templateWorkflows
            .Select(template =>
                new Workflow
                {
                    Name = template.Name,
                    Description = template.Description,
                    PreferenceSettings = template.PreferenceSettings,
                    Steps = template.Steps,
                    Active = template.Active,
                    WorkflowGroupId = template.WorkflowGroupId,
                });

        var dest = await Pagination.GetAll(queryParams => _workflowClient.Get(queryParams));

        var changeSet = src.Compare(dest, new WorkflowIdComparer(), new WorkflowDetailsComparer());

        var tasks = new List<Task>();


        tasks.AddRange(changeSet.Delete.Select(x =>
            Task.Run(() => _workflowClient.Delete(x.Id))));

        tasks.AddRange(changeSet.Create.Select(x =>
            Task.Run(() => _workflowClient.Create(
                new WorkflowCreateData
                {
                    Name = x.Name,
                    WorkflowGroupId = x.WorkflowGroupId,
                    Description = x.Description,
                    PreferenceSettings = x.PreferenceSettings,
                    Steps = x.Steps,
                    Active = x.Active,
                    
                }))));

        var changeSetUpdate = changeSet.Update;
        if (changeSetUpdate is not null)
        {
            tasks.AddRange(changeSetUpdate.Original.Select(x =>
            {
                var updateTo = changeSetUpdate.ChangeTo
                    .Single(c => c.Name.Equals(x.Name, StringComparison.InvariantCultureIgnoreCase));

                return Task.Run(() => _workflowClient.Update(
                    x.Id,
                    new WorkflowEditData
                    {
                        Name = updateTo.Name,
                        Description = updateTo.Description,
                        WorkflowGroupId = updateTo.WorkflowGroupId,
                        PreferenceSettings = updateTo.PreferenceSettings,
                        Steps = updateTo.Steps,
                        Active = x.Active,
                        Triggers = x.Triggers,
                    }));
            }));
        }

        // throws AggregateException
        await Task.WhenAll(tasks);
    }
}