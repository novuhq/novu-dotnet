using System.Threading.Tasks;
using FluentAssertions;
using Novu.Clients;
using Xunit;

namespace Novu.Tests.IntegrationTests;

public class MxRecordTests(IMxRecordClient mxRecordClient)
{
    [Fact]
    public async Task Should_Return_False_Because_MX_Is_Not_Set()
    {
        var status = await mxRecordClient.Get();
        status.Data.MxRecordConfigured.Should().BeFalse();
    }
}