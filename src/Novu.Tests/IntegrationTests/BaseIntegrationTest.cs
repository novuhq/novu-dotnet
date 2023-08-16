using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Novu.DTO;
using Novu.DTO.Layouts;
using Novu.DTO.Topics;
using Novu.DTO.WorkflowGroup;
using Novu.DTO.Workflows;
using Novu.Extensions;
using Novu.Interfaces;
using Novu.Models.Workflows;
using Novu.Models.Workflows.Step.Message;
using Step = Novu.Models.Workflows.Step;
using Novu.NotificationTemplates;
using ParkSquare.Testing.Generators;
using Refit;
using Xunit;
using Xunit.Abstractions;

namespace Novu.Tests.IntegrationTests;

public abstract class BaseIntegrationTest : IDisposable
{
    private readonly IConfigurationRoot _configurationRoot;
    private readonly ServiceCollection _services;
    private IServiceProvider _serviceProvider;

    protected BaseIntegrationTest(ITestOutputHelper output)
    {
        Output = output;

        _services = new ServiceCollection();

        // set environment variable to pickup correct configuration
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Integration");
        _configurationRoot = Settings.FileName.CreateConfigurationRoot();

        RegisterExceptionHandler();
    }

    public ITestOutputHelper Output { get; set; }

    private List<SubscriberDto> Subscribers { get; } = new();
    private List<TopicData> Topics { get; } = new();
    private List<WorkflowGroupSingleResponseDto> WorkflowGroups { get; } = new();
    private List<Workflow> Workflows { get; } = new();
    private List<Layout> Layouts { get; } = new();

    protected INovuClient Client => Get<INovuClient>();
    protected ISubscriberClient Subscriber => Get<ISubscriberClient>();
    protected IEventClient Event => Get<IEventClient>();
    protected ITopicClient Topic => Get<ITopicClient>();
    protected IWorkflowGroupClient WorkflowGroup => Get<IWorkflowGroupClient>();
    protected INotificationTemplatesClient NotificationTemplates => Get<INotificationTemplatesClient>();
    protected IWorkflowClient Workflow => Get<IWorkflowClient>();
    protected ILayoutClient Layout => Get<ILayoutClient>();

    public async void Dispose()
    {
        // note: dispose buries errors like 404 Not Found
        await TeardownWorkflows();
        await TeardownWorkflowGroups();
        await TeardownTopics();
        await TeardownSubscribers();
        await TeardownLayouts();
    }

    protected void DeRegisterExceptionHandler()
    {
        Register(services => services.RegisterClients(_configurationRoot));
    }

    protected void RegisterExceptionHandler()
    {
        var refitSettings = new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(NovuClient.DefaultSerializerSettings),
            ExceptionFactory = TestExceptionFactory,
        };

        Register(services => services.RegisterClients(_configurationRoot, refitSettings));

        // Reports the client errors up to the tests for diagnosis
        async Task<Exception> TestExceptionFactory(HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
            {
                switch (message.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return default;
                }

                var content = await message.Content.ReadAsStringAsync();
                // don't catch any errors because we need to see errors in tests
                try
                {
                    var error = JsonConvert.DeserializeObject<ErrorResponseDto>(content);
                    if (error is not null)
                    {
                        Assert.Fail($"[{error.Code}: '{error.Status}'] '{string.Join("; ", error.Message)}'");
                    }
                }
                catch (JsonReaderException e)
                {
                    Assert.Fail($"Cannot convert error message '{e.GetType()}' {content}");
                }
            }

            return default;
        }
    }

    private async Task TeardownSubscribers()
    {
        foreach (var subscriber in Subscribers)
        {
            if (subscriber.SubscriberId is not null)
            {
                await Subscriber.DeleteSubscriber(subscriber.SubscriberId);
            }
        }
    }

    private async Task TeardownTopics()
    {
        foreach (var topic in Topics)
        {
            await Topic.DeleteTopicAsync(topic.Key);
        }
    }

    private async Task TeardownWorkflowGroups()
    {
        foreach (var workflowGroup in WorkflowGroups)
        {
            await WorkflowGroup.DeleteWorkflowGroupAsync(workflowGroup.PayloadDto.Id);
        }
    }

    private async Task TeardownWorkflows()
    {
        foreach (var workflow in Workflows)
        {
            await Workflow.Delete(workflow.Id);
        }
    }

    private async Task TeardownLayouts()
    {
        foreach (var layout in Layouts)
        {
            await Layout.Delete(layout.Id);
        }
    }

    /// <summary>
    ///     Resolves the already registered service required for the test
    /// </summary>
    protected T Get<T>() where T : class
    {
        return _serviceProvider.GetService<T>();
    }

    /// <summary>
    ///     Ad hoc registration of services used particularly for overrides
    /// </summary>
    /// <param name="iocRegistration"></param>
    protected void Register(Action<ServiceCollection> iocRegistration)
    {
        iocRegistration(_services);
        _serviceProvider = _services.BuildServiceProvider();
    }

    protected void Register(Action<ServiceCollection, IConfigurationRoot> iocRegistration)
    {
        iocRegistration(_services, _configurationRoot);
        _serviceProvider = _services.BuildServiceProvider();
    }

    protected async Task<T> Make<T>(CreateSubscriberDto data = null) where T : SubscriberDto
    {
        var createData = data ?? new CreateSubscriberDto
        {
            SubscriberId = Guid.NewGuid().ToString(),
            FirstName = NameGenerator.AnyForename(),
            LastName = NameGenerator.AnySurname(),
            Avatar = "https://avatars.githubusercontent.com/u/77433905?s=200&v=4",
            Email = EmailAddressGenerator.AnyEmailAddress(),
            Locale = "en-US",
            Phone = TelephoneNumberGenerator.AnyTelephoneNumber(),
            Data = new List<AdditionalDataDto>
            {
                new()
                {
                    Key = "FRAMEWORK",
                    Value = ".NET",
                },
                new()
                {
                    Key = "SMS_PREFERENCE",
                    Value = "EMERGENT-ONLY",
                },
            },
        };

        var subscriber = await Subscriber.CreateSubscriber(createData);

        Subscribers.Add(subscriber);

        return subscriber as T;
    }

    protected async Task<T> Make<T>(TopicCreateDto data = null, SubscriberDto subscriber = null)
        where T : TopicCreateResponseDto
    {
        var createData = data ?? new TopicCreateDto
        {
            Key = $"test:{NumberGenerator.RandomNumberBetween(6000, 10000)}",
            Name = StringGenerator.LoremIpsum(10),
        };

        var topic = await Topic.CreateTopicAsync(createData) as T;

        if (subscriber is not null)
        {
            await Add<TopicSubscriberAdditionResponseDto>(subscriber, topic);
        }

        if (topic is not null)
        {
            Topics.Add(topic.Data);
        }

        return topic;
    }

    protected async Task<T> Make<T>(WorkflowGroupDto data = null)
        where T : WorkflowGroupSingleResponseDto
    {
        var createData = data ?? new WorkflowGroupDto
        {
            WorkflowGroupName = StringGenerator.LoremIpsum(10),
        };

        var workflowGroup = await WorkflowGroup.CreateWorkflowGroup(createData);
        WorkflowGroups.Add(workflowGroup);
        return workflowGroup as T;
    }

    protected async Task<T> Make<T>(
        LayoutCreateData data = null,
        string content = null,
        TemplateVariable[] variables = null)
        where T : Layout
    {
        var createData = data ?? new LayoutCreateData
        {
            Name = StringGenerator.LoremIpsum(4),
            Description = StringGenerator.LoremIpsum(10),
            Content = content ?? "Test " + LayoutCreateData.BodyExpression + " expression",
            Variables = variables ?? Array.Empty<TemplateVariable>(),
        };

        var layout = await Layout.Create(createData);
        Layouts.Add(layout.Data);
        return layout.Data as T;
    }

    protected async Task<T> Make<T>(WorkflowCreateData data = null, Step.Step[] steps = null, bool active = false)
        where T : Workflow
    {
        // the simplest workflow is empty without steps and this returns a workflow with a trigger
        var createData = data ?? new WorkflowCreateData
        {
            Name = StringGenerator.SequenceOfAlphaNumerics(10),
            Description = StringGenerator.LoremIpsum(5),
            PreferenceSettings = new PreferenceChannels(),
            Steps = steps ?? Array.Empty<Step.Step>(),
            Active = active,
        };

        if (string.IsNullOrWhiteSpace(createData.WorkflowGroupId))
        {
            var group = await Make<WorkflowGroupSingleResponseDto>();
            createData.WorkflowGroupId = group.PayloadDto.Id;
        }

        var workflow = await Workflow.Create(createData);
        Workflows.Add(workflow.Data);
        return workflow.Data as T;
    }

    protected async Task<T> Add<T>(SubscriberDto subscriber, TopicCreateResponseDto topic)
        where T : TopicSubscriberAdditionResponseDto
    {
        var subscriberList = new TopicSubscriberUpdateDto(new List<string> { subscriber.SubscriberId });
        return await Topic.AddSubscriberAsync(topic.Data.Key, subscriberList) as T;
    }
}