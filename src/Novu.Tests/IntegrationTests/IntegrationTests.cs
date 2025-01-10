using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Novu.Interfaces;
using Novu.Models.Integrations;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class IntegrationTests(IIntegrationClient integrationClient)
{
    [Fact]
    public async Task Should_Get_Integrations()
    {
        var integrations = await integrationClient.Get();
        integrations.Should().NotBeNull();
        // integrations.Data.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_Serialize_Credentials_WithNulls_IsEmpty()
    {
        JsonConvert.SerializeObject(new Credentials(), NovuClient.DefaultSerializerSettings)
            .Should()
            .Be("{}");
    }
}