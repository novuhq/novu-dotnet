using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Novu.DTO;
using Novu.DTO.Layouts;
using Novu.Interfaces;
using Novu.Sync;
using Novu.Sync.Models;
using Novu.Sync.Services;
using ParkSquare.Testing.Generators;
using Xunit;
using Xunit.DependencyInjection;

namespace Novu.Tests.MicroTests.Sync;

public class SyncLayoutTests(INovuSync<TemplateLayout> syncClient, ILogger<SyncLayoutTests> log)
{
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
            null,
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
            null,
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
            null,
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
            null,
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
            null,
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
        Func<Times> deleteCalls,
        [FromServices] Mock<ILayoutClient> client
    )
    {
        log.LogInformation(test);

        client.Reset();
        client
            .Setup(x => x.Get(It.IsAny<PaginationQueryParams>()))
            .ReturnsAsync(new NovuPaginatedResponse<Layout>
            {
                HasMore = false,
                Data = currentSetAtDestination.ToArray(),
            });


        await syncClient.Sync(templateLayouts);

        client.Verify(x => x.Get(It.IsAny<PaginationQueryParams>()), getCalls);
        client.Verify(x => x.Create(It.IsAny<LayoutCreateData>()), createCalls);
        client.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<LayoutEditData>()), updateCalls);
        client.Verify(x => x.Delete(It.IsAny<string>()), deleteCalls);
    }

    /// <summary>
    ///     Automatically bootstrapped through Xunit lifecycle
    ///     see https://github.com/pengweiqhca/Xunit.DependencyInjection
    /// </summary>
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
        {
            var client = new Mock<ILayoutClient>();

            services
                .ConfigureTestServices(context)
                .RegisterNovuSync()
                // inject the  mock into each test
                .AddScoped(typeof(Mock<ILayoutClient>), _ => client)
                // override the registered service with a mock
                .AddScoped(_ => client.Object);
        }
    }
}