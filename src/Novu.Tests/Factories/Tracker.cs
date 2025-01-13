using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novu.Clients;
using Novu.Domain.Models.Feeds;
using Novu.Domain.Models.Layouts;
using Novu.Domain.Models.Subscribers;
using Novu.Domain.Models.Tenants;
using Novu.Domain.Models.Topics;
using Novu.Domain.Models.WorkflowGroups;
using Novu.Domain.Models.WorkflowOverrides;
using Novu.Domain.Models.Workflows;

namespace Novu.Tests.Factories;

public class Tracker(
    ISubscriberClient subscriberClient,
    ITopicClient topicClient,
    IWorkflowGroupClient workflowGroupClient,
    IWorkflowClient workflowClient,
    ILayoutClient layoutClient,
    IFeedClient feedClient,
    ITenantClient tenantClient,
    IWorkflowOverrideClient overrideClient)
{
    public List<Subscriber> Subscribers { get; } = [];
    public List<Topic> Topics { get; } = [];
    public List<WorkflowGroup> WorkflowGroups { get; } = [];
    public List<Workflow> Workflows { get; } = [];
    public List<Layout> Layouts { get; } = [];
    public List<Feed> Feeds { get; } = [];
    public List<Tenant> Tenants { get; } = [];
    public List<WorkflowOverride> WorkflowOverrides { get; } = [];

    public async Task RemoveAll()
    {
        // note: dispose buries errors like 404 Not Found
        await TeardownWorkflowOverrides();
        await TeardownWorkflows();
        await TeardownWorkflowGroups();
        await TeardownTopics();
        await TeardownSubscribers();
        await TeardownLayouts();
        await TeardownTopics();
        await TeardownFeeds();
        await TeardownTenants();
    }

    private async Task TeardownSubscribers()
    {
        foreach (var subscriber in Subscribers.Where(subscriber => subscriber.SubscriberId is not null))
        {
            await subscriberClient.DeleteSubscriber(subscriber.SubscriberId!);
        }
    }

    private async Task TeardownTopics()
    {
        foreach (var topic in Topics)
        {
            await topicClient.Delete(topic.Key);
        }
    }

    private async Task TeardownWorkflowGroups()
    {
        foreach (var workflowGroup in WorkflowGroups)
        {
            await workflowGroupClient.Delete(workflowGroup.Id);
        }
    }

    private async Task TeardownWorkflowOverrides()
    {
        foreach (var workflowOverride in WorkflowOverrides)
        {
            await overrideClient.Delete(workflowOverride.Id);
        }
    }

    private async Task TeardownWorkflows()
    {
        foreach (var workflow in Workflows)
        {
            await workflowClient.Delete(workflow.Id);
        }
    }

    private async Task TeardownLayouts()
    {
        foreach (var layout in Layouts)
        {
            await layoutClient.Delete(layout.Id);
        }
    }

    private async Task TeardownFeeds()
    {
        foreach (var feed in Feeds)
        {
            await feedClient.Delete(feed.Id);
        }
    }

    private async Task TeardownTenants()
    {
        foreach (var tenant in Tenants)
        {
            await tenantClient.Delete(tenant.Id);
        }
    }
}