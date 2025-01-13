using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.Layouts;
using Novu.Sync.Comparers;
using Novu.Sync.Models;
using Novu.Sync.Utils;

namespace Novu.Sync.Services;

public class LayoutSync :  INovuSync<TemplateLayout>
{
    private readonly ILayoutClient _layoutClient;

    public LayoutSync(ILayoutClient layoutClient)
    {
        _layoutClient = layoutClient;
    }

    public async Task Sync(TemplateLayout templateTemplateLayout)
    {
        await Sync(new[] { templateTemplateLayout });
    }

    /// <summary>
    ///     Take list of template layouts and look through the Sync found on an organisation and synchronise.
    ///     Note: this current implementation takes control of an environment and deletes anything unknown to the templates
    /// </summary>
    /// <exception cref="AggregateException">
    ///     The <see cref="AggregateException.InnerExceptions" /> will return list of <see cref="Refit.ApiException" />
    /// </exception>
    public async Task Sync(IEnumerable<TemplateLayout> templateLayouts)
    {
        var src = templateLayouts
            .Select(template =>
                new Layout
                {
                    Name = template.Name,
                    Description = template.Description,
                    Content = template.Content,
                    Variables = template.Variables,
                    IsDefault = template.IsDefault,
                });

        var dest = await Pagination.GetAll(queryParams => _layoutClient.Get(queryParams));

        var changeSet = src.Compare(dest, new LayoutIdComparer(), new LayoutDetailsComparer());

        var tasks = new List<Task>();

        tasks.AddRange(changeSet.Create.Select(x =>
            Task.Run(() => _layoutClient.Create(
                new LayoutCreateData
                {
                    Name = x.Name,
                    Description = x.Description,
                    Content = x.Content,
                    Variables = x.Variables,
                    IsDefault = x.IsDefault,
                }))));

        var changeSetUpdate = changeSet.Update;
        if (changeSetUpdate is not null)
        {
            tasks.AddRange(changeSetUpdate.Original.Select(x =>
            {
                var updateTo = changeSetUpdate.ChangeTo
                    .Single(c => c.Name.Equals(x.Name, StringComparison.InvariantCultureIgnoreCase));

                return Task.Run(() => _layoutClient.Update(
                    x.Id,
                    new LayoutEditData
                    {
                        Name = updateTo.Name,
                        Description = updateTo.Description,
                        Content = updateTo.Content,
                        Variables = updateTo.Variables,
                        IsDefault = updateTo.IsDefault,
                    }));
            }));
        }


        tasks.AddRange(changeSet.Delete.Select(x =>
            Task.Run(() => _layoutClient.Delete(x.Id))));

        // throws AggregateException
        await Task.WhenAll(tasks);
    }
}