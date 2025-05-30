using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models;
using Novu.Domain.Models.Integrations;
using Novu.Domain.Utils;
using Novu.Sync.Comparers;
using Novu.Sync.Models;
using Novu.Sync.Utils;

namespace Novu.Sync.Services;

public class IntegrationSync : INovuSync<TemplateIntegration>
{
    private readonly IIntegrationClient _integrationClient;

    public IntegrationSync(IIntegrationClient integrationClient)
    {
        _integrationClient = integrationClient;
    }

    public async Task Sync(TemplateIntegration templateTemplateIntegration)
    {
        await Sync(new[] { templateTemplateIntegration });
    }

    /// <summary>
    ///     Take list of template integrations and look through the Sync found on an organisation and synchronise.
    ///     Note: this current implementation takes control of an environment and deletes anything unknown to the templates
    /// </summary>
    /// <exception cref="AggregateException">
    ///     The <see cref="AggregateException.InnerExceptions" /> will return list of <see cref="Refit.ApiException" />
    /// </exception>
    public async Task Sync(IEnumerable<TemplateIntegration> templateIntegrations)
    {
        var src = templateIntegrations
            .Select(template =>
                new Integration
                {
                    Identifier = template.Identifier,
                    Channel = template.Channel.ToEnumString(),
                    ProviderId = template.ProviderId,
                    Active = template.Active,
                    Credentials = template.Credentials,
                    Name = template.Name,
                });

        var dest = await _integrationClient.Get();

        var changeSet = src.Compare(dest.Data, new IntegrationIdComparer(), new IntegrationDetailsComparer());


        // needs to run all the deletions before any insertions
        // throws AggregateException
        await Task.WhenAll(changeSet.Delete.Select(x =>
            Task.Run(() => _integrationClient.Delete(x.Id))));

        var tasks = new List<Task>();
        tasks.AddRange(changeSet.Create.Select(createData =>
            Task.Run(() => _integrationClient.Create(
                new IntegrationCreateData
                {
                    Identifier = createData.Identifier,
                    Channel = createData.Channel,
                    ProviderId = createData.ProviderId,
                    Active = createData.Active,
                    Credentials = createData.Credentials,
                    Name = createData.Name,
                }))));

        var changeSetUpdate = changeSet.Update;
        if (changeSetUpdate is not null)
        {
            tasks.AddRange(changeSetUpdate.Original.Select(x =>
            {
                var updateTo = changeSetUpdate.ChangeTo
                    .Single(c => c.ProviderId == x.ProviderId &&
                                 c.Channel == x.Channel);

                return Task.Run(() => _integrationClient.Update(x.Id, updateTo.ToEditData()));
            }));
        }

        // throws AggregateException
        await Task.WhenAll(tasks);
    }
}