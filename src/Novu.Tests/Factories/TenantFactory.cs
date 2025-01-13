using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.Tenants;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.Factories;

public class TenantFactory(Tracker tracker, ITenantClient client)
{
    public async Task<Tenant> Make(TenantCreateData data = null)
    {
        var createData = data ?? new TenantCreateData
        {
            Name = NameGenerator.AnyName(),
            Identifier = StringGenerator.SequenceOfAlphaNumerics(50),
        };

        var tenant = await client.Create(createData);
        tracker.Tenants.Add(tenant.Data);
        return tenant.Data;
    }
}