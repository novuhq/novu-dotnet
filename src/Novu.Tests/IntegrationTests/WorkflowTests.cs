using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO.Workflows;
using Novu.Extensions;
using Novu.Interfaces;
using Novu.Models.Workflows;
using Novu.Models.Workflows.Step;
using Novu.Tests.Factories;
using ParkSquare.Testing.Generators;
using Polly;
using Xunit;
using Xunit.Sdk;

namespace Novu.Tests.IntegrationTests;

public class WorkflowTests(WorkflowFactory workflowFactory, IWorkflowClient workflowClient, ILayoutClient layoutClient)
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "In-App", new[] { StepFactory.InApp() }, 1 },
            new object[] { "Email", new[] { StepFactory.Email() }, 1 },
            new object[] { "Sms", new[] { StepFactory.Sms() }, 1 },
            new object[] { "Digest Event", new[] { StepFactory.DigestRegular() }, 1 },
            new object[] { "Digest Schedule 18:05", new[] { StepFactory.DigestScheduleAtTime() }, 1 },
            new object[]
            {
                "Digest Schedule every week day 18:05",
                new[] { StepFactory.DigestScheduleEveryWeekdayAtTime() },
                1,
            },
            new object[] { "Digest Schedule each month 18:05", new[] { StepFactory.DigestScheduleEachMonth() }, 1 },
            new object[]
            {
                "Digest Schedule on second weekday 18:05",
                new[] { StepFactory.DigestScheduleSecondWeekday() },
                1,
            },
            new object[] { "Chat", new[] { StepFactory.Chat() }, 1 },
            new object[] { "Delay", new[] { StepFactory.Delay() }, 1 },
            new object[] { "Delay from variable", new[] { StepFactory.DelayFromVariable() }, 1 },
            new object[] { "Push", new[] { StepFactory.Push() }, 1 },
            new object[] { "(Multiple) Email + In-App", new[] { StepFactory.Email(), StepFactory.InApp() }, 2 },
            new object[]
            {
                "(Multiple) In-App + Digest + Email",
                new[] { StepFactory.InApp(), StepFactory.DigestRegular(), StepFactory.Email() },
                3,
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void Should_Validate_Model(string test, Step[] steps, int stepsCount)
    {
        var createData = new WorkflowCreateData
        {
            Name = StringGenerator.SequenceOfAlphaNumerics(10),
            Description = StringGenerator.LoremIpsum(5),
            PreferenceSettings = new PreferenceChannels(),
            Steps = steps ?? [],
            WorkflowGroupId = StringGenerator.SequenceOfAlphaNumerics(20),
        };
        if (!createData.IsValid(out var results))
        {
            Assert.Fail($"Validations error ({results.Count}) {string.Join(" ", results)}");
        }
    }

    [Theory]
    [MemberData(nameof(Data))]
    public async Task Should_Create_Steps(string test, Step[] steps, int stepsCount)
    {
        var workflow = await workflowFactory.Make<Workflow>(steps: steps);
        workflow.Should().NotBeNull();
        workflow.Steps.Should().HaveCount(stepsCount);
        workflow.Triggers.Should().HaveCount(1);
    }


    [Fact]
    public async Task Should_Create_Step_With_LayoutSet()
    {
        // we know there is always a default layout
        var layout = (await layoutClient.Get())
            .Data
            .Single(x => x.IsDefault);

        var steps = new[] { StepFactory.Email(layoutId: layout.Id) };
        var workflow = await workflowFactory.Make<Workflow>(steps: steps);
        workflow.Should().NotBeNull();
        workflow.Triggers.Should().HaveCount(1);
        workflow.Steps.First().Template.LayoutId.Should().Be(layout.Id);
    }

    [Fact]
    public async Task Should_Get_Workflows()
    {
        var workflows = await workflowClient.Get();
        workflows.Should().NotBeNull();
        workflows.Page.Should().Be(0);
        workflows.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Should_Get_Workflow()
    {
        var workflow = await workflowFactory.Make<Workflow>();
        var result = await workflowClient.Get(workflow.Id);
        result.Data.Should().NotBeNull();
        result.Data.Id.Should().Be(workflow.Id);
    }

    [Fact]
    public async Task Should_Delete_Workflow()
    {
        var workflow = await workflowFactory.Make<Workflow>();
        await workflowClient.Delete(workflow.Id);
        var result = await workflowClient.Get(workflow.Id);
        result.Data.Should().BeNull();
    }

    /// <summary>
    ///     This is a flaky test so add handles around it
    /// </summary>
    [Fact]
    public async Task Should_SetStatus()
    {
        var workflows = await workflowClient.Get();
        var workflow = workflows.Data.First();

        // WAIT for system to catch up given it is async
        const int maxRetryAttempts = 3;
        var retryPolicy = Policy
            .Handle<XunitException>()
            .WaitAndRetryAsync(maxRetryAttempts, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        await retryPolicy.ExecuteAsync(async () =>
        {
            var result = await workflowClient.UpdateStatus(
                workflow.Id,
                new WorkflowStatusEditData
                {
                    Active = !workflow.Active,
                });
            result.Data.Should().NotBeNull();
            result.Data.Active.Should().NotBe(workflow.Active);
        });
    }
}