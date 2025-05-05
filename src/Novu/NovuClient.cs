using System.Reflection;
using Novu.Clients;
using Novu.Domain;
using Refit;

namespace Novu;

public class NovuClient : INovuClient
{
    // exposed for requested #108
    public readonly HttpClient HttpClient;

    // exposed for requested #108
    public readonly RefitSettings RefitSettings;
    private const string AuthorizationHeaderName = "Authorization";

    public NovuClient(
        INovuClientConfiguration configuration,
        HttpClient? client = null,
        RefitSettings? refitSettings = null)
    {
        HttpClient = client ?? new HttpClient();
        HttpClient.BaseAddress = new Uri(configuration.Url);
        HttpClient.DefaultRequestHeaders.Add(AuthorizationHeaderName, $"ApiKey {configuration.ApiKey}");
        HttpClient.DefaultRequestHeaders.Add("User-Agent", NovuConstants.UserAgent());

        refitSettings ??= new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(NovuJsonSettings.DefaultSerializerSettings),
        };
        RefitSettings = refitSettings;

        Subscriber = RestService.For<ISubscriberClient>(HttpClient, refitSettings);
        Event = RestService.For<IEventClient>(HttpClient, refitSettings);
        Topic = RestService.For<ITopicClient>(HttpClient, refitSettings);
        Workflow = RestService.For<IWorkflowClient>(HttpClient, refitSettings);
        WorkflowGroup = RestService.For<IWorkflowGroupClient>(HttpClient, refitSettings);
        WorkflowOverride = RestService.For<IWorkflowOverrideClient>(HttpClient, refitSettings);
        Layout = RestService.For<ILayoutClient>(HttpClient, refitSettings);
        Integration = RestService.For<IIntegrationClient>(HttpClient, refitSettings);
        Notifications = RestService.For<INotificationsClient>(HttpClient, refitSettings);
        Message = RestService.For<IMessageClient>(HttpClient, refitSettings);
        ExecutionDetails = RestService.For<IExecutionDetailsClient>(HttpClient, refitSettings);
        Feeds = RestService.For<IFeedClient>(HttpClient, refitSettings);
        Changes = RestService.For<IChangeClient>(HttpClient, refitSettings);
        Tenant = RestService.For<ITenantClient>(HttpClient, refitSettings);
        MxRecord = RestService.For<IMxRecordClient>(HttpClient, refitSettings);
        Organization = RestService.For<IOrganizationClient>(HttpClient, refitSettings);
        OrganizationMember = RestService.For<IOrganizationMemberClient>(HttpClient, refitSettings);
        OrganizationBrand = RestService.For<IOrganizationBrandClient>(HttpClient, refitSettings);
        Environment = RestService.For<IEnvironmentClient>(HttpClient, refitSettings);
        Blueprint = RestService.For<IBlueprintClient>(HttpClient, refitSettings);
    }

    public IFeedClient Feeds { get; }
    public IChangeClient Changes { get; }


    public IWorkflowClient Workflow { get; }
    public IWorkflowGroupClient WorkflowGroup { get; }
    public IWorkflowOverrideClient WorkflowOverride { get; }
    public ILayoutClient Layout { get; }
    public IIntegrationClient Integration { get; }
    public INotificationsClient Notifications { get; }
    public IMessageClient Message { get; }
    public IExecutionDetailsClient ExecutionDetails { get; }
    public ISubscriberClient Subscriber { get; }
    public IEventClient Event { get; }
    public ITopicClient Topic { get; }
    public ITenantClient Tenant { get; }
    public IMxRecordClient MxRecord { get; }
    public IOrganizationClient Organization { get; }
    public IOrganizationMemberClient OrganizationMember { get; }
    public IOrganizationBrandClient OrganizationBrand { get; }
    public IEnvironmentClient Environment { get; }
    public IBlueprintClient Blueprint { get; }
}