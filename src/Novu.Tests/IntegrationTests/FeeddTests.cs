using System.Threading.Tasks;
using Novu.Clients;
using Xunit;
using Xunit.Sdk;

namespace Novu.Tests.IntegrationTests;

public class BlueprintTests(IBlueprintClient blueprintClient)
{
    [Fact]
    public async Task Should_Return_Blueprint()
    {
        var listOfBlueprints = await blueprintClient.Get();

        Assert.NotNull(listOfBlueprints);
    }

    [Fact]
    public async Task Should_Return_Blueprint_By_Id_Is_Broken()
    {
        await Assert.ThrowsAsync<FailException>(async () =>
        {
            await blueprintClient.Get("not found");
        });
    }
}