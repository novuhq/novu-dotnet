using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.Integrations;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.Factories;

public class IntegrationFactory(IIntegrationClient client)
{
    public async Task<Integration> Make(IntegrationCreateData data = null, string providerId = null, string channel = null)
    {
        var createData = data ?? new IntegrationCreateData
        {
            Name = StringGenerator.LoremIpsum(4),
            ProviderId = providerId ?? "novu",
            Channel = channel ?? "in_app",
            Active = true,
        };

        var layout = await client.Create(createData);

        // do not manage integrations as other types. 

        return layout.Data;
    }
}