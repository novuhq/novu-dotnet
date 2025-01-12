using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Novu.Domain.Models.Changes;
using Xunit;
using Xunit.Sdk;

namespace Novu.Tests.IntegrationTests;

public class ChangeTests(IChangeClient changeClient)
{
    [Fact]
    public async Task Should_Return_Change_List()
    {
        var listOfChanges = await changeClient.Get(1, 1);

        listOfChanges.Page.Should().Be(1);
        listOfChanges.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_Change_Count()
    {
        (await changeClient.GetCount()).Data
            .Should()
            .BeGreaterThan(-1);
    }


    [Fact]
    public async Task Should_Add_Changes_NotFound()
    {
        // TODO: no idea about how this actually works
        await Assert.ThrowsAsync<FailException>(async () =>
        {
            var novuResponse = await changeClient.Create(new ChangesCreateData
            {
                ChangeIds = ["1", "2"],
            });
        });
    }

    [Fact]
    public async Task Should_Add_Change_NotFound()
    {
        // TODO: no idea about how this actually works
        await Assert.ThrowsAsync<FailException>(async () =>
        {
            var novuResponse = await changeClient.Create("1");
            novuResponse.Data.Should().BeNull();
        });
    }
}