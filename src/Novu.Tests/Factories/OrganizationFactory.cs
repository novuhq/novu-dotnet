using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.Organizations;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.Factories;

public class OrganizationFactory(IOrganizationClient client)
{
    public async Task<Organization> Make(OrganizationCreateData data = null)
    {
        var createData = data ?? new OrganizationCreateData
        {
            Name = StringGenerator.SequenceOfAlphaNumerics(50),
            JobTitleEnum = JobTitleEnum.Other,
            Domain = "example.com",
        };

        var organisation = await client.Create(createData);
        // note: organizations cannot be deleted, so no tracking
        return organisation.Data;
    }
}