using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Novu.DTO;
using Novu.DTO.WorkflowGroups;
using Novu.Interfaces;
using Novu.Sync;
using Novu.Sync.Models;
using Novu.Sync.Services;
using ParkSquare.Testing.Generators;
using Xunit;
using Xunit.DependencyInjection;

namespace Novu.Tests.MicroTests.Sync;

public class SyncWorkflowGroupTests(INovuSync<TemplateWorkflowGroup> syncClient, ILogger<SyncWorkflowGroupTests> log)
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[]
        {
            "both sides empty",
            Array.Empty<TemplateWorkflowGroup>(),
            Array.Empty<WorkflowGroup>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            null,
        },
        new object[]
        {
            "new template - create at dest",
            new List<TemplateWorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            Array.Empty<WorkflowGroup>(),
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            null,
        },
        new object[]
        {
            "same on both sides - no changes",
            new List<TemplateWorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            new List<WorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Never,
            null,
        },
        new object[]
        {
            "template changed - update dest (recreate)",
            new List<TemplateWorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(5),
                },
            },
            new List<WorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            (Func<Times>)Times.Once,
            // an update is a delete and create
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Once,
            null,
        },
        new object[]
        {
            "template removed - delete at dest",
            Array.Empty<TemplateWorkflowGroup>(),
            new List<WorkflowGroup>
            {
                new()
                {
                    Name = StringGenerator.LoremIpsum(4),
                },
            },
            (Func<Times>)Times.Once,
            (Func<Times>)Times.Never,
            (Func<Times>)Times.Once,
            null,
        },
    };


    [Theory]
    [MemberData(nameof(Data))]
    public async Task Tests(
        string test,
        IList<TemplateWorkflowGroup> templateWorkflowGroups,
        IList<WorkflowGroup> currentSetAtDestination,
        Func<Times> getCalls,
        Func<Times> createCalls,
        Func<Times> deleteCalls,
        [FromServices] Mock<IWorkflowGroupClient> client
    )
    {
        log.LogInformation(test);

        client.Reset();
        client
            .Setup(x => x.Get())
            .ReturnsAsync(new NovuResponse<IEnumerable<WorkflowGroup>>(currentSetAtDestination.ToList()));


        await syncClient.Sync(templateWorkflowGroups);

        client.Verify(x => x.Get(), getCalls);
        client.Verify(x => x.Create(It.IsAny<WorkflowGroupCreateData>()), createCalls);
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
            var client = new Mock<IWorkflowGroupClient>();

            services
                .ConfigureTestServices(context)
                .RegisterNovuSync()
                // inject the  mock into each test
                .AddScoped(typeof(Mock<IWorkflowGroupClient>), _ => client)
                // override the registered service with a mock
                .AddScoped(_ => client.Object);
        }
    }
}