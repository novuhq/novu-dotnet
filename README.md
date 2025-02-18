<div align="center"> 
    <a href="https://novu.co" target="_blank"> 
        <picture>
            <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/2233092/213641039-220ac15f-f367-4d13-9eaf-56e79433b8c1.png"> <img src="https://user-images.githubusercontent.com/2233092/213641043-3bbb3f21-3c53-4e67-afe5-755aeb222159.png" width="280" alt="Logo"/> 
        </picture> 
    </a> 
</div>

# novu-dotnet

[![NuGet](https://img.shields.io/nuget/v/Novu.svg)](https://www.nuget.org/packages/Novu/)
[![NuGet](https://img.shields.io/nuget/dt/Novu.svg)](https://www.nuget.org/packages/Novu/)
[![Deploy to Nuget](https://github.com/novuhq/novu-dotnet/actions/workflows/dotnet-deploy.yaml/badge.svg)](https://github.com/novuhq/novu-dotnet/actions/workflows/dotnet-deploy.yaml)

.NET SDK for Novu - The open-source notification infrastructure for engineers. 🚀

novu-dotnet targets .NET Standard 2.0 and is compatible with .NET Core 2.0+ and .NET Framework 4.6.1+.

**Current:** Novu api 0.24.0

## Features

- Bindings against all [API endpoints](https://docs.novu.co/api/overview/)
    - Events, subscribers, notifications, integrations, layouts, topics, workflows, workflow groups, messages, execution
      details
- Bootstrap each services as part of services provider or directly as a singleton class (setting injectable)
- A Sync service that will mirror an environment based a set of templates (layouts, integrations, workflow groups,
  workflows)

**WARNING**: 0.3.0 has breaking changes and the tests should be relied on for understanding the client libraries

## Dependencies

| dotnet novu | novu api [package](https://github.com/novuhq/novu/pkgs/container/novu%2Fapi) | Notes                                                                                                                                                                                                                                   |
|-------------|------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 0.2.2       | <= 0.17                                                                      | Singleton client with Refit's use of RestService                                                                                                                                                                                        |
| 0.3.0       | \>= 0.18                                                                     | 0.3.0 is not compatible with 0.2.2 and requires upgrade to code. Also 0.18 introduced a breaking change only found in 0.3.0. All 0.2.2 must be upgraded if used against the production system. HttpClient can now be used and injected. |
| 0.3.1       | \>= 0.18                                                                     | Failed release. You will not find this release on Nuget.                                                                                                                                                                                |
| 0.3.2       | \>= 0.18                                                                     | [BREAKING} Obsolete Notification Templates has been removed. Service registration separation of single client and each client. Novu.Extension and Novu.Sync released as packages.                                                       |
| 0.3.2       | \>= 0.18                                                                     |                                                                                                                                                                                                                                         |
| 0.4.0       | \>= 0.24                                                                     |                                                                                                                                                                                                                                         |
| 0.5.0       | \>= 0.24                                                                     | Refit 7.2.2 / Microsoft.Extension>=7.x                                                                                                                                                                                                  |
| 0.6.0       | \>= 0.24                                                                     | Refit 8.0 / Microsoft.Extension>=8.x                                                                                                                                                                                                    |

## Installation

```bash
dotnet add package Novu
```

## Configuration

### Direct instantiation

```csharp
using Novu.Domain.Models;
using Novu;

 var novuConfiguration = new NovuClientConfiguration
{
    // Defaults to https://api.novu.co/v1
    Url = "https://novu-api.my-domain.com/v1",
    ApiKey = "12345",
};

var novu = new NovuClient(novuConfiguration);

// Note: this client exposes all endpoints as methods but uses RestService
var subscribers = await novu.Subscriber.Get();
```

### Dependency Injection

Configure via settings

```appsettings.json
{
  "Novu": {
    "Url": "http://localhost:3000/v1",
    "ApiKey": "e36b820fcc9a68a83db6c79c30f1a461"
  }
}

```

Setup Injection via extension methods

```csharp

public static IServiceCollection RegisterNotificationSetupServices(
    this IServiceCollection services,
    IConfiguration configuration)
{
    // registers all clients with novu config from appsetting.json
    // the services inject HttpClient
    return services
        .RegisterNovuClients(configuration)
        // here as an example that the registered services are injected into local service
        .AddTransient<NovuNotificationService>();
}
```

Write your consuming code with the injected clients

```csharp
// then instantiate via injection
public class NovuNotificationService
{
    private readonly IEventClient _event;

    public NovuSyncService(IEventClient @event)
    {
        _event = @event;
    }

    public async Task Trigger(string subscriberId){
       var trigger = await Event.Trigger(
            new EventCreateData
            {
                EventName = 'event-name',
                To = { SubscriberId =subscriberId },
                Payload = new Payload("Bogus payload"),
            });
    }

    public record Payload(string Message)
    {
        [JsonProperty("message")] public string Message { get; set; }
    }
}
```

## Examples

Usage of the library is best understood by looking at the tests.

- [Integration Tests](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu.Tests/IntegrationTests): these show the
  minimal dependencies required to do one primary request (create, update, delete)
- [Acceptance Tests](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu.Tests/AcceptanceTests): these show a
  sequence of actions to complete a business process in an environment

## Repository Overview

[Novu](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu) is the main SDK
with [Novu.Tests](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu.Tests) housing all unit
tests. [Novu.Extensions](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu.Extensions) is required for DI
and [Novu.Sync](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu.Sync)
if your are looking for mirroring environments.

### novu-dotnet

The key folders to look into:

- [Models](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu.Domain/Models) directory holds all objects needed to
  use the
  clients (a port of the contracts from openapi spec and consolidated—actually
  autogen [contracts](https://github.com/novuhq/novu-dotnet/tree/main/src/refitter))
- [Clients](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu/Clients) directory holds all interfaces that
  are intended to outline how a class should be structured

## API

Note: all old release information is in `specs/[version]/README` (which includes diffs)

**Tracking Versions**: `New`, `Changed`, `Deleted`, `Deprecated`

* **New**: tracked since version
* **Changed**: has had changes on the endpoint attributes
* **Deleted**: was removed (obsolete)
* **Deprecated**: marked as being removed

**Compatability**: `Full`, `Incomplete`, `None`, `Upgrade`

* **Full**: all attributes are supported on the model on the method/endpoint call
* **None**: the method/endpoint is not implemented
* **Upgrade**: known changes to the attributes are required that are flagged (practically same as incomplete but
  effectively a NEW placeholder)

### Events

Events represent a change in state of a subscriber. They are used to trigger workflows, and enable you to send
notifications to subscribers based on their actions.

| HTTP Method | Endpoint                           | Description            | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------|------------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/events/trigger                 | Trigger event          | 0.18.0 | 0.19.0  |         |            | Upgrade       |       |
| POST        | /v1/events/trigger/bulk            | Bulk trigger event     | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/events/trigger/broadcast       | Broadcast event to all | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/events/trigger/{transactionId} | Cancel triggered event | 0.18.0 |         |         |            | Full          |       |

### Subscribers

A subscriber in Novu represents someone who should receive a message. A subscriber’s profile information contains
important attributes about the subscriber that will be used in messages (name, email). The subscriber object can contain
other key-value pairs that can be used to further personalize your messages.

| HTTP Method | Endpoint                                                               | Description                                                                                                                                          | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/subscribers                                                        | Get subscribers                                                                                                                                      | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/subscribers                                                        | Create subscriber                                                                                                                                    | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/subscribers/{subscriberId}                                         | Get subscriber                                                                                                                                       | 0.18.0 |         |         |            | Full          |       |
| PUT         | /v1/subscribers/{subscriberId}                                         | Update subscriber                                                                                                                                    | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/subscribers/{subscriberId}                                         | Delete subscriber                                                                                                                                    | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/subscribers/bulk                                                   | Bulk create subscribers                                                                                                                              | 0.19.0 |         |         |            | Full          |       |
| PUT         | /v1/subscribers/{subscriberId}/credentials                             | Update subscriber credentials                                                                                                                        | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/subscribers/{subscriberId}/credentials/{providerId}                | Delete subscriber credentials by providerId                                                                                                          | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/subscribers/{subscriberId}/online-status                           | Update subscriber online status                                                                                                                      | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/preferences                             | Get subscriber preferences                                                                                                                           | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/subscribers/{subscriberId}/preferences                             | Update subscriber global preferences                                                                                                                 | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/preferences/{level}                     | Get subscriber preferences by level                                                                                                                  | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/subscribers/{subscriberId}/preferences/{templateId}                | Update subscriber preference                                                                                                                         | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/notifications/feed                      | Get in-app notification feed for a particular subscriber                                                                                             | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/notifications/unseen                    | Get the unseen in-app notifications count for subscribers feed                                                                                       | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/subscribers/{subscriberId}/messages/markAs                         | Mark a subscriber feed message as seen                                                                                                               | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/subscribers/{subscriberId}/messages/mark-all                       | Marks all the subscriber messages as read, unread, seen or unseen. Optionally you can pass feed id (or array) to mark messages of a particular feed. | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/subscribers/{subscriberId}/messages/{messageId}/actions/{type}     | Mark message action as seen                                                                                                                          | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/credentials/{providerId}/oauth/callback | Handle providers oauth redirect                                                                                                                      | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/credentials/{providerId}/oauth          | Handle chat oauth                                                                                                                                    | 0.18.0 |         |         |            | Full          |       |

### Topics

Topics are a way to group subscribers together so that they can be notified of events at once. A topic is identified by
a custom key. This can be helpful for things like sending out marketing emails or notifying users of new features.
Topics can also be used to send notifications to the subscribers who have been grouped together based on their
interests, location, activities and much more.

| HTTP Method | Endpoint                                                 | Description            | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|----------------------------------------------------------|------------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/topics                                               | Topic creation         | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/topics                                               | Filter topics          | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/topics/{topicKey}/subscribers                        | Subscribers addition   | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/topics/{topicKey}/subscribers/{externalSubscriberId} | Check topic subscriber | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/topics/{topicKey}/subscribers/removal                | Subscribers removal    | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/topics/{topicKey}                                    | Delete topic           | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/topics/{topicKey}                                    | Get topic              | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/topics/{topicKey}                                    | Rename a topic         | 0.18.0 |         |         |            | Full          |       |

### Notification

A notification conveys information from source to recipient, triggered by a workflow acting as a message blueprint.
Notifications can be individual or bundled as digest for user-friendliness.

| HTTP Method | Endpoint                           | Description                       | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------|-----------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/notifications                  | Get notifications                 | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notifications/stats            | Get notification statistics       | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notifications/graph/stats      | Get notification graph statistics | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notifications/{notificationId} | Get notification                  | 0.18.0 |         |         |            | Full          |       |

### Integrations

With the help of the Integration Store, you can easily integrate your favorite delivery provider. During the runtime of
the API, the Integrations Store is responsible for storing the configurations of all the providers.

| HTTP Method | Endpoint                                              | Description                             | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-------------------------------------------------------|-----------------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/integrations                                      | Get integrations                        | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/integrations                                      | Create integration                      | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/integrations/active                               | Get active integrations                 | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/integrations/webhook/provider/{providerId}/status | Get webhook support status for provider | 0.18.0 |         |         |            | Full          |       |
| PUT         | /v1/integrations/{integrationId}                      | Update integration                      | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/integrations/{integrationId}                      | Delete integration                      | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/integrations/{integrationId}/set-primary          | Set integration as primary              | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/integrations/{channelType}/limit                  |                                         | 0.18.0 |         | 0.24.0  |            | Removed       |       |
| GET         | /v1/integrations/in-app/status                        |                                         | 0.18.0 |         | 0.24.0  |            | Removed       |       |

### Layouts

Novu allows the creation of layouts - a specific HTML design or structure to wrap content of email notifications.
Layouts can be manipulated and assigned to new or existing workflows within the Novu platform, allowing users to create,
manage, and assign these layouts to workflows, so they can be reused to structure the appearance of notifications sent
through the platform.

| HTTP Method | Endpoint                       | Description        | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------------------|--------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/layouts                    | Layout creation    | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/layouts                    | Filter layouts     | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/layouts/{layoutId}         | Get layout         | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/layouts/{layoutId}         | Delete layout      | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/layouts/{layoutId}         | Update a layout    | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/layouts/{layoutId}/default | Set default layout | 0.18.0 |         |         |            | Full          |       |

### Workflows

All notifications are sent via a workflow. Each workflow acts as a container for the logic and blueprint that are
associated with a type of notification in your system.

| HTTP Method | Endpoint                          | Description            | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-----------------------------------|------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/workflows                     | Get workflows          | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/workflows                     | Create workflow        | 0.18.0 |         |         |            | Full          |       |
| PUT         | /v1/workflows/{workflowId}        | Update workflow        | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/workflows/{workflowId}        | Delete workflow        | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/workflows/{workflowId}        | Get workflow           | 0.18.0 |         |         |            | Full          |       |
| PUT         | /v1/workflows/{workflowId}/status | Update workflow status | 0.18.0 |         |         |            | Full          |       |

### Notification Templates

Deprecated. Use Workflows (/workflows) instead, which provide the same functionality under a new name.

| HTTP Method | Endpoint                                       | Description            | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------------------|------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/notification-templates                     | Get workflows          | 0.18.0 |         |         | 0.19.0     | Removed       |       |
| POST        | /v1/notification-templates                     | Create workflow        | 0.18.0 |         |         | 0.19.0     | Removed       |       |
| PUT         | /v1/notification-templates/{templateId}        | Update workflow        | 0.18.0 |         |         | 0.19.0     | Removed       |       |
| DELETE      | /v1/notification-templates/{templateId}        | Delete workflow        | 0.18.0 |         |         | 0.19.0     | Removed       |       |
| GET         | /v1/notification-templates/{templateId}        | Get workflow           | 0.18.0 |         | 0.24.0  | 0.19.0     | Removed       |       |
| PUT         | /v1/notification-templates/{templateId}/status | Update workflow status | 0.18.0 |         | 0.24.0  | 0.19.0     | Removed       |       |

### Workflow Groups

Workflow groups are used to organize workflows into logical groups.

| HTTP Method | Endpoint                     | Description           | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------|-----------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/notification-groups      | Create workflow group | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notification-groups      | Get workflow groups   | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notification-groups/{id} | Get workflow group    | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/notification-groups/{id} | Update workflow group | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/notification-groups/{id} | Delete workflow group | 0.18.0 |         |         |            | Full          |       |

### Changes

Changes represent a change in state of an environment. They are analagous to a pending pull request in git, enabling you
to test changes before they are applied to your environment and atomically apply them when you are ready.

| HTTP Method | Endpoint                     | Description       | New    | Changed | Deleted | Deprecated | Compatability | Notes                 |
|-------------|------------------------------|-------------------|--------|---------|---------|------------|---------------|-----------------------|
| GET         | /v1/changes                  | Get changes       | 0.18.0 |         |         |            | Full          |                       |
| GET         | /v1/changes/count            | Get changes count | 0.18.0 |         |         |            | Full          |                       |
| POST        | /v1/changes/bulk/apply       | Apply changes     | 0.18.0 |         |         |            | Full          | Unsure how this works |
| POST        | /v1/changes/{changeId}/apply | Apply change      | 0.18.0 |         |         |            | Full          | Unsure how this works |

### Environments

Novu uses the concept of environments to ensure logical separation of your data and configuration. This means that
subscribers, and preferences created in one environment are never accessible to another.

| HTTP Method | Endpoint                             | Description             | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------------------------|-------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/environments/me                  | Get current environment | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/environments                     | Create environment      | 0.18.0 |         | 0.24.0  | ??         | None          |       |
| GET         | /v1/environments                     | Get environments        | 0.18.0 |         |         |            | Full          |       |
| PUT         | /v1/environments{environmentId}      | Update env by id        | 0.18.0 |         | 0.24.0  | ??         | None          |       |
| GET         | /v1/environments/api-keys            | Get api keys            | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/environments/api-keys/regenerate | Regenerate api keys     | 0.18.0 |         |         |            | Full          |       |

### Inbound Parse

Inbound Webhook is a feature that allows processing of incoming emails for a domain or subdomain. The feature parses the
contents of the email and POSTs the information to a specified URL in a multipart/form-data format.

| HTTP Method | Endpoint                    | Description                                                      | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-----------------------------|------------------------------------------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/inbound-parse/mx/status | Validate the mx record setup for the inbound parse functionality | 0.18.0 |         |         |            | Full          |       |

### Feeds

Novu provides a notification activity feed that monitors every outgoing message associated with its relevant metadata.
This can be used to monitor activity and discover potential issues with a specific provider or a channel type.

| HTTP Method | Endpoint           | Description | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------|-------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/feeds          | Create feed | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/feeds          | Get feeds   | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/feeds/{feedId} | Delete feed | 0.18.0 |         |         |            | Full          |       |

### Tenants

A tenant represents a group of users. As a developer, when your apps have organizations, they are referred to as
tenants. Tenants in Novu provides the ability to tailor specific notification experiences to users of different groups
or organizations.

| HTTP Method | Endpoint                 | Description   | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------------|---------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/tenants              | Get tenants   | 0.19.0 |         |         |            | Full          |       |
| POST        | /v1/tenants              | Create tenant | 0.19.0 |         |         |            | Full          |       |
| GET         | /v1/tenants/{identifier} | Get tenant    | 0.19.0 |         |         |            | Full          |       |
| PATCH       | /v1/tenants/{identifier} | Update tenant | 0.19.0 |         |         |            | Full          |       |
| DELETE      | /v1/tenants/{identifier} | Delete tenant | 0.19.0 |         |         |            | Full          |       |

### Messages

A message in Novu represents a notification delivered to a recipient on a particular channel. Messages contain
information about the request that triggered its delivery, a view of the data sent to the recipient, and a timeline of
its lifecycle events. Learn more about messages.

| HTTP Method | Endpoint                                 | Description                      | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------------|----------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/messages                             | Get messages                     | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/messages/{messageId}                 | Delete message                   | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/messages/transaction/{transactionId} | Delete messages by transactionId | 0.18.0 |         |         |            | Full          |       |

### Organizations

An organization serves as a separate entity within your Novu account. Each organization you create has its own separate
integration store, workflows, subscribers, and API keys. This separation of resources allows you to manage multi-tenant
environments and separate domains within a single account.

| HTTP Method | Endpoint                                   | Description                                      | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------------------------------|--------------------------------------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/organizations                          | Create an organization                           | 0.19.0 |         |         |            | Full          |       |
| GET         | /v1/organizations                          | Fetch all organizations                          | 0.19.0 |         |         |            | Full          |       |
| PATCH       | /v1/organizations                          | Rename organization name                         | 0.19.0 |         |         |            | Full          |       |
| GET         | /v1/organizations/me                       | Fetch current organization details               | 0.19.0 |         |         |            | Full          |       |
| DELETE      | /v1/organizations/members/{memberId}       | Remove a member from organization using memberId | 0.19.0 |         |         |            | Full          |       |
| PUT         | /v1/organizations/members/{memberId}/roles | Update a member role to admin                    | 0.19.0 |         | ??      |            | Removed       |       |
| GET         | /v1/organizations/members                  | Fetch all members of current organizations       | 0.19.0 |         |         |            | Full          |       |
| PUT         | /v1/organizations/branding                 | Update organization branding details             | 0.19.0 |         |         |            | Full          |       |

### Execution Details

Execution details are used to track the execution of a workflow. They provided detailed information on the execution of
a workflow, including the status of each step, the input and output of each step, and the overall status of the
execution.

| HTTP Method | Endpoint              | Description           | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-----------------------|-----------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/execution-details | Get execution details | 0.18.0 |         |         |            | Full          |       |

### Default

| HTTP Method | Endpoint                                | Description | New    | Changed | Deleted | Deprecated | Compatability | Notes                        |
|-------------|-----------------------------------------|-------------|--------|---------|---------|------------|---------------|------------------------------|
| GET         | /v1/blueprints/group-by-category        |             | 0.19.0 |         |         |            | Full          |                              |
| GET         | /v1/blueprints/list                     |             | 0.19.0 |         | 0.24.0  |            | None          |                              |
| GET         | /v1/blueprints/{templateIdOrIdentifier} |             | 0.19.0 |         |         |            | Full          | Throws 500 error on wrong id |

### Workflow-Overrides

| HTTP Method | Endpoint                                                         | Description                    | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------------------------------------|--------------------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/workflow-overrides                                           | Create a workflow override     | 0.19.0 |         |         |            | Full          |       |
| GET         | /v1/workflow-overrides                                           | Get workflow overrides         | 0.19.0 |         |         |            | Full          |       |
| PUT         | /v1/workflow-overrides/{overrideId}                              | Update workflow by override id | 0.19.0 |         |         |            | Full          |       |
| GET         | /v1/workflow-overrides/{overrideId}                              | Get workflow override by id    | 0.19.0 |         |         |            | Full          |       |
| DELETE      | /v1/workflow-overrides/{overrideId}                              | Delete workflow override       | 0.19.0 |         |         |            | Full          |       |
| PUT         | /v1/workflow-overrides/workflows/{workflowId}/tenants/{tenantId} | Update workflow override       | 0.19.0 |         |         |            | Full          |       | 
| GET         | /v1/workflow-overrides/workflows/{workflowId}/tenants/{tenantId} | Get workflow override          | 0.19.0 |         |         |            | Full          |       |
