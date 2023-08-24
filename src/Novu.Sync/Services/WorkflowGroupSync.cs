using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novu.DTO.WorkflowGroups;
using Novu.Interfaces;
using Novu.Sync.Comparers;
using Novu.Sync.Models;
using Novu.Sync.Utils;

namespace Novu.Sync.Services;

public class WorkflowGroupSync :  INovuSync<TemplateWorkflowGroup>
{
    private readonly IWorkflowGroupClient _workflowGroupClient;

    public WorkflowGroupSync(IWorkflowGroupClient workflowGroupClient)
    {
        _workflowGroupClient = workflowGroupClient;
    }

    public async Task Sync(TemplateWorkflowGroup templateTemplateWorkflowGroup)
    {
        await Sync(new[] { templateTemplateWorkflowGroup });
    }

    /// <summary>
    ///     Take list of template Sync and look through the Sync found on an organisation and synchronise.
    ///     Note: this current implementation takes control of an environment and deletes anything unknown to the templates
    /// </summary>
    /// <exception cref="AggregateException">
    ///     The <see cref="AggregateException.InnerExceptions" /> will return list of <see cref="Refit.ApiException" />
    /// </exception>
    public async Task Sync(IEnumerable<TemplateWorkflowGroup> templateWorkflowGroups)
    {
        var src = templateWorkflowGroups
            .Select(template =>
                new WorkflowGroup
                {
                    Name = template.Name,
                });

        var dest = (await _workflowGroupClient.Get()).Data;

        var changeSet = src.Compare(dest, new WorkflowGroupComparer(), new WorkflowGroupComparer());

        var tasks = new List<Task>();

        tasks.AddRange(changeSet.Create.Select(x =>
            Task.Run(() => _workflowGroupClient.Create(
                new WorkflowGroupCreateData { Name = x.Name }))));

        var changeSetUpdate = changeSet.Update;
        if (changeSetUpdate is not null)
        {
            tasks.AddRange(changeSetUpdate.Original.Select(x =>
            {
                var updateTo = changeSetUpdate.ChangeTo
                    .Single(c => c.Name.Equals(x.Name, StringComparison.InvariantCultureIgnoreCase));

                // It is unclear how workgroups are meant to be used as there is no update. Will this fail
                // if the workgroup is used in a workflow and the idea is to keep creating new workgroups?
                return Task.Run(async () =>
                {
                    await _workflowGroupClient.Delete(x.Id);
                    return await _workflowGroupClient.Create(
                        new WorkflowGroupCreateData { Name = updateTo.Name });
                });
            }));
        }


        tasks.AddRange(changeSet.Delete.Select(x =>
            Task.Run(() => _workflowGroupClient.Delete(x.Id))));

        // throws AggregateException
        await Task.WhenAll(tasks);
    }
}