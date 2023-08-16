using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Novu.DTO.Workflows;
using Novu.Extensions;
using Novu.Models.Workflows;
using Novu.Models.Workflows.Step;
using ParkSquare.Testing.Generators;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public class WorkflowTests : BaseIntegrationTest
 {
    public WorkflowTests(ITestOutputHelper output) : base(output)
    {
    }

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
                1
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
            Steps = steps ?? Array.Empty<Step>(),
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
        var workflow = await Make<Workflow>(steps: steps);
        workflow.Should().NotBeNull();
        workflow.Steps.Should().HaveCount(stepsCount);
        workflow.Triggers.Should().HaveCount(1);
    }

    [Fact]
    public async Task Should_Get_Workflows()
    {
        var workflows = await Workflow.Get();
        workflows.Should().NotBeNull();
        workflows.Page.Should().Be(0);
        workflows.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Should_Get_Workflow()
    {
        var workflow = await Make<Workflow>();
        var result = await Workflow.Get(workflow.Id);
        result.Data.Should().NotBeNull();
        result.Data.Id.Should().Be(workflow.Id);
    }

    [Fact]
    public async Task Should_Delete_Workflow()
    {
        var workflow = await Make<Workflow>();
        await Workflow.Delete(workflow.Id);
        var result = await Workflow.Get(workflow.Id);
        result.Data.Should().BeNull();
    }

    [Fact]
    public async Task Should_SetStatus()
    {
        var workflows = await Workflow.Get();
        var workflow = workflows.Data.First();
        var result = await Workflow.UpdateStatus(
            workflow.Id,
            new WorkflowEditStatusData
            {
                Active = !workflow.Active,
            });
        result.Data.Should().NotBeNull();
        result.Data.Active.Should().NotBe(workflow.Active);
    }
}