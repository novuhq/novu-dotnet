using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.Layouts;
using Novu.Domain.Models.Workflows.Step.Message;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.Factories;

public class LayoutFactory(ILayoutClient client, Tracker tracker)
{
    public async Task<Layout> Make<T>(
        LayoutCreateData data = null,
        string content = null,
        TemplateVariable[] variables = null)
       
    {
        var createData = data ?? new LayoutCreateData
        {
            Name = StringGenerator.LoremIpsum(4),
            Description = StringGenerator.LoremIpsum(10),
            Content = content ?? "Test " + LayoutCreateData.BodyExpression + " expression",
            Variables = variables ?? [],
        };

        var layout = await client.Create(createData);
        tracker.Layouts.Add(layout.Data);
        return layout.Data;
    }
}