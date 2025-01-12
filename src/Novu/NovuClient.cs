using Novu.Clients;
using Novu.Domain;
using Refit;

namespace Novu;

public class NovuClient : INovuClient
{
    private const string AuthorizationHeaderName = "Authorization";

    public NovuClient(
        INovuClientConfiguration configuration,
        HttpClient? client = null,
        RefitSettings? refitSettings = null)
    {
        var httpClient = client ?? new HttpClient();
        httpClient.BaseAddress = new Uri(configuration.Url);
        httpClient.DefaultRequestHeaders.Add(AuthorizationHeaderName, $"ApiKey {configuration.ApiKey}");

        refitSettings ??= new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(NovuJsonSettings.DefaultSerializerSettings),
        };

        Subscriber = RestService.For<ISubscriberClient>(httpClient, refitSettings);
        Event = RestService.For<IEventClient>(httpClient, refitSettings);
        Topic = RestService.For<ITopicClient>(httpClient, refitSettings);
        Workflow = RestService.For<IWorkflowClient>(httpClient, refitSettings);
        WorkflowGroup = RestService.For<IWorkflowGroupClient>(httpClient, refitSettings);
        WorkflowOverride = RestService.For<IWorkflowOverrideClient>(httpClient, refitSettings);
        Layout = RestService.For<ILayoutClient>(httpClient, refitSettings);
        Integration = RestService.For<IIntegrationClient>(httpClient, refitSettings);
        Notifications = RestService.For<INotificationsClient>(httpClient, refitSettings);
        Message = RestService.For<IMessageClient>(httpClient, refitSettings);
        ExecutionDetails = RestService.For<IExecutionDetailsClient>(httpClient, refitSettings);
        Feeds = RestService.For<IFeedClient>(httpClient, refitSettings);
        Changes = RestService.For<IChangeClient>(httpClient, refitSettings);
        Tenant = RestService.For<ITenantClient>(httpClient, refitSettings);
        MxRecord = RestService.For<IMxRecordClient>(httpClient, refitSettings);
        Organization = RestService.For<IOrganizationClient>(httpClient, refitSettings);
        OrganizationMember = RestService.For<IOrganizationMemberClient>(httpClient, refitSettings);
        OrganizationBrand = RestService.For<IOrganizationBrandClient>(httpClient, refitSettings);
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
}