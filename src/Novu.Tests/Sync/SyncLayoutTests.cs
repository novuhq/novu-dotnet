using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Novu.DTO;
using Novu.DTO.Layouts;
using Novu.Interfaces;
using Novu.Sync;
using Novu.Sync.Models;
using Novu.Tests.IntegrationTests;
using ParkSquare.Testing.Generators;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.Sync;

public class SyncLayoutTests : BaseIntegrationTest
{
    private readonly Mock<ILayoutClient> _layoutClient;

    public SyncLayoutTests(ITestOutputHelper output) : base(output)
    {
        _layoutClient = new Mock<ILayoutClient>();

        // looks to be a need to registered the swapped out implementations before any are
        // instantiated. Expectations are set in the tests.
        Register(
            services => { services.SwapTransient(_ => _layoutClient.Object); });
    }

    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[]
        {
            "both sides empty",
            Array.Empty<TemplateLayout>(),
            Array.Empty<Layout>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "new template - create at dest",
            new List<TemplateLayout>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                    Content = LayoutCreateData.BodyExpression,
                },
            },
            Array.Empty<Layout>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "same on both sides - no changes",
            new List<TemplateLayout>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                    Content = LayoutCreateData.BodyExpression,
                },
            },
            new List<Layout>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                    Content = LayoutCreateData.BodyExpression,
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "template changed - update dest",
            new List<TemplateLayout>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                    Content = LayoutCreateData.BodyExpression + "change",
                },
            },
            new List<Layout>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                    Content = LayoutCreateData.BodyExpression,
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
        },
        new object[]
        {
            "template removed - delete at dest",
            Array.Empty<TemplateLayout>(),
            new List<Layout>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                    Content = LayoutCreateData.BodyExpression,
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Once,
        },
    };


    [Theory]
    [MemberData(nameof(Data))]
    public async Task Tests(
        string test,
        IList<TemplateLayout> templateLayouts,
        IList<Layout> currentSetAtDestination,
        Func<Times> getCalls,
        Func<Times> createCalls,
        Func<Times> updateCalls,
        Func<Times> deleteCalls
    )
    {
        Output.WriteLine(test);

        _layoutClient
            .Setup(x => x.Get(It.IsAny<PaginationQueryParams>()))
            .ReturnsAsync(new NovuPaginatedResponse<Layout>
            {
                HasMore = false,
                Data = currentSetAtDestination.ToArray(),
            });

        var syncClient = Get<LayoutSync>();

        await syncClient.Layouts(templateLayouts);

        _layoutClient.Verify(x => x.Get(It.IsAny<PaginationQueryParams>()), getCalls);
        _layoutClient.Verify(x => x.Create(It.IsAny<LayoutCreateData>()), createCalls);
        _layoutClient.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<LayoutEditData>()), updateCalls);
        _layoutClient.Verify(x => x.Delete(It.IsAny<string>()), deleteCalls);
    }
}