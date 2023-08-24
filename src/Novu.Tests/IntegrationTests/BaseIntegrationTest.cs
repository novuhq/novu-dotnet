using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Novu.DTO;
using Novu.DTO.Integrations;
using Novu.DTO.Layouts;
using Novu.DTO.Subscribers;
using Novu.DTO.Topics;
using Novu.DTO.WorkflowGroups;
using Novu.DTO.Workflows;
using Novu.Extensions;
using Novu.Interfaces;
using Novu.Models.Subscribers;
using Novu.Models.Workflows;
using Novu.Models.Workflows.Step.Message;
using Novu.NotificationTemplates;
using Novu.Sync;
using ParkSquare.Testing.Generators;
using Refit;
using Xunit;
using Xunit.Abstractions;
using Step = Novu.Models.Workflows.Step.Step;

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

    private List<Subscriber> Subscribers { get; } = new();
    private List<Topic> Topics { get; } = new();
    private List<WorkflowGroup> WorkflowGroups { get; } = new();
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
    protected IIntegrationClient Integration => Get<IIntegrationClient>();
    protected INotificationsClient Notifications => Get<INotificationsClient>();
    protected IMessageClient Messages => Get<IMessageClient>();

    public async void Dispose()
    {
        // note: dispose buries errors like 404 Not Found
        await TeardownWorkflows();
        await TeardownWorkflowGroups();
        await TeardownTopics();
        await TeardownSubscribers();
        await TeardownLayouts();
        await TeardownTopics();
    }

    protected void DeRegisterExceptionHandler()
    {
        Register(services => services.RegisterNovuClients(_configurationRoot));
    }

    protected void RegisterExceptionHandler()
    {
        var defaultSerializerSettings = NovuClient.DefaultSerializerSettings;

        // setup in-memory logging for
        // see https://www.newtonsoft.com/json/help/html/SerializationTracing.htm
        // TODO: make this more injectable/configurable for ad hoc diagnosis
        TraceWriter = new MemoryTraceWriter();
        defaultSerializerSettings.TraceWriter = TraceWriter;

        var refitSettings = new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(defaultSerializerSettings),
            ExceptionFactory = TestExceptionFactory,
        };

        Register(services =>
            services
                .RegisterNovuClients(_configurationRoot, refitSettings)
                .RegisterNovuSync());

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
                    var error = JsonConvert.DeserializeObject<ErrorData>(content);
                    if (error is not null)
                    {
                        Output.WriteLine("=================================");
                        Output.WriteLine(TraceWriter.ToString());
                        Output.WriteLine("=================================");
                        Assert.Fail($"[{error.Code}: '{error.Status}'] '{string.Join("; ", error.Message)}'");
                    }
                }
                catch (JsonReaderException e)
                {
                    Output.WriteLine("=================================");
                    Output.WriteLine(TraceWriter.ToString());
                    Output.WriteLine("=================================");
                    Assert.Fail($"Cannot convert error message '{e.GetType()}' {content}");
                }
            }

            return default;
        }
    }

    protected ITraceWriter TraceWriter { get; set; }

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
            await Topic.Delete(topic.Key);
        }
    }

    private async Task TeardownWorkflowGroups()
    {
        foreach (var workflowGroup in WorkflowGroups)
        {
            await WorkflowGroup.Delete(workflowGroup.Id);
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

    protected async Task<T> Make<T>(SubscriberCreateData data = null) where T : Subscriber
    {
        var createData = data ?? new SubscriberCreateData
        {
            SubscriberId = Guid.NewGuid().ToString(),
            FirstName = NameGenerator.AnyForename(),
            LastName = NameGenerator.AnySurname(),
            Avatar = "https://avatars.githubusercontent.com/u/77433905?s=200&v=4",
            Email = EmailAddressGenerator.AnyEmailAddress(),
            Locale = "en-US",
            Phone = TelephoneNumberGenerator.AnyTelephoneNumber(),
            Data = new List<AdditionalData>
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

        var subscriber = await Subscriber.Create(createData);

        Subscribers.Add(subscriber.Data);

        return subscriber.Data as T;
    }

    protected async Task<T> Make<T>(
        TopicCreateData data = null,
        Subscriber subscriber = null,
        List<Subscriber> additionalSubscribers = null)
        where T : Topic
    {
        var createData = data ?? new TopicCreateData
        {
            Key = $"test:{NumberGenerator.RandomNumberBetween(600, 100000)}",
            Name = StringGenerator.LoremIpsum(10),
        };

        var result = await Topic.Create(createData);
        var topic = result.Data;

        if (subscriber is not null)
        {
            await Add<SucceedData>(subscriber, topic, additionalSubscribers);
        }

        if (topic is not null)
        {
            Topics.Add(topic);
        }

        return topic as T;
    }

    protected async Task<T> Make<T>(WorkflowGroupCreateData data = null)
        where T : WorkflowGroup
    {
        var createData = data ?? new WorkflowGroupCreateData
        {
            Name = StringGenerator.LoremIpsum(10),
        };

        var workflowGroup = await WorkflowGroup.Create(createData);
        WorkflowGroups.Add(workflowGroup.Data);
        return workflowGroup.Data as T;
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

    protected async Task<T> Make<T>(IntegrationCreateData data = null, string providerId = null, string channel = null)
        where T : Integration
    {
        var createData = data ?? new IntegrationCreateData
        {
            Name = StringGenerator.LoremIpsum(4),
            ProviderId = providerId ?? "novu",
            Channel = channel ?? "in_app",
            Active = true,
        };

        var layout = await Integration.Create(createData);

        // do not manage integrations as other types. 

        return layout.Data as T;
    }

    protected async Task<T> Make<T>(
        WorkflowCreateData data = null,
        Step[] steps = null,
        bool active = false,
        PreferenceChannels preferenceChannels = null)
        where T : Workflow
    {
        // the simplest workflow is empty without steps and this returns a workflow with a trigger
        var createData = data ?? new WorkflowCreateData
        {
            Name = StringGenerator.SequenceOfAlphaNumerics(10),
            Description = StringGenerator.LoremIpsum(5),
            PreferenceSettings = new PreferenceChannels(),
            Steps = steps ?? Array.Empty<Step>(),
            Active = active,
        };

        if (string.IsNullOrWhiteSpace(createData.WorkflowGroupId))
        {
            var group = await Make<WorkflowGroup>();
            createData.WorkflowGroupId = group.Id;
        }

        var workflow = await Workflow.Create(createData);
        Workflows.Add(workflow.Data);
        return workflow.Data as T;
    }

    protected async Task<T> Add<T>(
        Subscriber subscriber,
        Topic topic,
        List<Subscriber> additionalSubscribers = null)
        where T : SucceedData
    {
        var subscribers = additionalSubscribers is not null
            ? additionalSubscribers.Select(x => x.SubscriberId).Prepend(subscriber.SubscriberId).ToList()
            : new List<string> { subscriber.SubscriberId };

        var subscriberList = new TopicSubscriberCreateData(subscribers);
        var topicSubscriberAdditionResponseDto = await Topic.AddSubscriber(topic.Key, subscriberList);
        Topics.Add(topic);
        return topicSubscriberAdditionResponseDto.Data as T;
    }
}