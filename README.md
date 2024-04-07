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

## Features

- Bindings against most [API endpoints](https://docs.novu.co/api/overview/)
    - Events, subscribers, notifications, integrations, layouts, topics, workflows, workflow groups, messages, execution
      details
    - Not
      Implemented: [environments](https://docs.novu.co/api/get-current-environment/), [inbound parse](https://docs.novu.co/api/validate-the-mx-record-setup-for-the-inbound-parse-functionality/), [changes](https://docs.novu.co/api/get-changes/)
- Bootstrap each services as part of services provider or directly as a singleton class (setting injectable)
- A Sync service that will mirror an environment based a set of templates (layouts, integrations, workflow groups,
  workflows)

**WARNING**: 0.3.0 has breaking changes and the tests should be relied on for understanding the client libraries

## Dependencies

| dotnet novu | novu api [package](https://github.com/novuhq/novu/pkgs/container/novu%2Fapi) | Notes                                                                                                                                                                                                                                   |
|-------------|------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 0.2.2       | <= 0.17                                                                      | Singleton client with Refit's use of RestService                                                                                                                                                                                        |
| 0.3.0       | >= 0.18                                                                      | 0.3.0 is not compatible with 0.2.2 and requires upgrade to code. Also 0.18 introduced a breaking change only found in 0.3.0. All 0.2.2 must be upgraded if used against the production system. HttpClient can now be used and injected. |
| 0.3.1       | >= 0.18                                                                      | Failed release. You will not find this release on Nuget.                                                                                                                                                                                |
| 0.3.2       | >= 0.18                                                                      | [BREAKING} Obsolete Notification Templates has been removed. Service registration separation of single client and each client. Novu.Extension and Novu.Sync released as packages.                                                       |

## Installation

```bash
dotnet add package Novu
```

## Configuration

### Direct instantiation

```csharp
using Novu.DTO;
using Novu.Models;
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

- [DTO](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu/DTO) directory holds all objects needed to use the
  clients
- [Interfaces](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu/Interfaces) directory holds all interfaces that
  are intended to outline how a class should be structured
- [Models](https://github.com/novuhq/novu-dotnet/tree/main/src/Novu/Models) directory holds various models that are
  sub-resources inside the DTOs

## API

**Compatability**: Full, Incomplete, None, Upgrade

* **Full:** all attributes are supported on the model on the method/endpoint call
* **None:** the method/endpoint is not implemented
* **Upgrade:** known changes to the attributes are required that are flagged (practically same as incomplete but
  effectively a NEW placeholder)

### Events

| HTTP Method | Endpoint                           | Description            | Compatability | Notes |
|-------------|------------------------------------|------------------------|---------------|-------|
| POST        | /v1/events/trigger                 | Trigger event          | Upgrade       |       |
| POST        | /v1/events/trigger/bulk            | Bulk trigger event     | Full          |       |
| POST        | /v1/events/trigger/broadcast       | Broadcast event to all | Full          |       |
| DELETE      | /v1/events/trigger/{transactionId} | Cancel triggered event | Full          |       |

### Subscribers

| HTTP Method | Endpoint                                                               | Description                                                                                                                                          | Compatability | Notes |
|-------------|------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|---------------|-------|
| GET         | /v1/subscribers                                                        | Get subscribers                                                                                                                                      | Full          |       |
| POST        | /v1/subscribers                                                        | Create subscriber                                                                                                                                    | Full          |       |
| GET         | /v1/subscribers/{subscriberId}                                         | Get subscriber                                                                                                                                       | Full          |       |
| PUT         | /v1/subscribers/{subscriberId}                                         | Update subscriber                                                                                                                                    | Full          |       |
| DELETE      | /v1/subscribers/{subscriberId}                                         | Delete subscriber                                                                                                                                    | Full          |       |
| POST        | /v1/subscribers/bulk                                                   | Bulk create subscribers                                                                                                                              | Full          |       |
| PUT         | /v1/subscribers/{subscriberId}/credentials                             | Update subscriber credentials                                                                                                                        | Full          |       |
| DELETE      | /v1/subscribers/{subscriberId}/credentials/{providerId}                | Delete subscriber credentials by providerId                                                                                                          | Full          |       |
| PATCH       | /v1/subscribers/{subscriberId}/online-status                           | Update subscriber online status                                                                                                                      | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/preferences                             | Get subscriber preferences                                                                                                                           | Full          |       |
| PATCH       | /v1/subscribers/{subscriberId}/preferences                             | Update subscriber global preferences                                                                                                                 | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/preferences/{level}                     | Get subscriber preferences by level                                                                                                                  | Full          |       |
| PATCH       | /v1/subscribers/{subscriberId}/preferences/{templateId}                | Update subscriber preference                                                                                                                         | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/notifications/feed                      | Get in-app notification feed for a particular subscriber                                                                                             | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/notifications/unseen                    | Get the unseen in-app notifications count for subscribers feed                                                                                       | Full          |       |
| POST        | /v1/subscribers/{subscriberId}/messages/markAs                         | Mark a subscriber feed message as seen                                                                                                               | Full          |       |
| POST        | /v1/subscribers/{subscriberId}/messages/mark-all                       | Marks all the subscriber messages as read, unread, seen or unseen. Optionally you can pass feed id (or array) to mark messages of a particular feed. | Full          |       |
| POST        | /v1/subscribers/{subscriberId}/messages/{messageId}/actions/{type}     | Mark message action as seen                                                                                                                          | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/credentials/{providerId}/oauth/callback | Handle providers oauth redirect                                                                                                                      | Full          |       |
| GET         | /v1/subscribers/{subscriberId}/credentials/{providerId}/oauth          | Handle chat oauth                                                                                                                                    | Full          |       |

### Topics

| HTTP Method | Endpoint                                                 | Description            | Compatability | Notes |
|-------------|----------------------------------------------------------|------------------------|---------------|-------|
| POST        | /v1/topics                                               | Topic creation         | Full          |       |
| GET         | /v1/topics                                               | Filter topics          | Full          |       |
| POST        | /v1/topics/{topicKey}/subscribers                        | Subscribers addition   | Full          |       |
| GET         | /v1/topics/{topicKey}/subscribers/{externalSubscriberId} | Check topic subscriber | Full          |       |
| POST        | /v1/topics/{topicKey}/subscribers/removal                | Subscribers removal    | Full          |       |
| DELETE      | /v1/topics/{topicKey}                                    | Delete topic           | Full          |       |
| GET         | /v1/topics/{topicKey}                                    | Get topic              | Full          |       |
| PATCH       | /v1/topics/{topicKey}                                    | Rename a topic         | Full          |       |

### Notification

| HTTP Method | Endpoint                           | Description                       | Compatability | Notes |
|-------------|------------------------------------|-----------------------------------|---------------|-------|
| GET         | /v1/notifications                  | Get notifications                 | Full          |       |
| GET         | /v1/notifications/stats            | Get notification statistics       | Full          |       |
| GET         | /v1/notifications/graph/stats      | Get notification graph statistics | Full          |       |
| GET         | /v1/notifications/{notificationId} | Get notification                  | Full          |       |

### Integrations

| HTTP Method | Endpoint                                              | Description                             | Compatability | Notes |
|-------------|-------------------------------------------------------|-----------------------------------------|---------------|-------|
| GET         | /v1/integrations                                      | Get integrations                        | Full          |       |
| POST        | /v1/integrations                                      | Create integration                      | Full          |       |
| GET         | /v1/integrations/active                               | Get active integrations                 | Full          |       |
| GET         | /v1/integrations/webhook/provider/{providerId}/status | Get webhook support status for provider | Full          |       |
| PUT         | /v1/integrations/{integrationId}                      | Update integration                      | Full          |       |
| DELETE      | /v1/integrations/{integrationId}                      | Delete integration                      | Full          |       |
| POST        | /v1/integrations/{integrationId}/set-primary          | Set integration as primary              | Full          |       |
| GET         | /v1/integrations/{channelType}/limit                  |                                         | Full          |       |
| GET         | /v1/integrations/in-app/status                        |                                         | Full          |       |

### Layouts

| HTTP Method | Endpoint                       | Description        | Compatability | Notes |
|-------------|--------------------------------|--------------------|---------------|-------|
| POST        | /v1/layouts                    | Layout creation    | Full          |       |
| GET         | /v1/layouts                    | Filter layouts     | Full          |       |
| GET         | /v1/layouts/{layoutId}         | Get layout         | Full          |       |
| DELETE      | /v1/layouts/{layoutId}         | Delete layout      | Full          |       |
| PATCH       | /v1/layouts/{layoutId}         | Update a layout    | Full          |       |
| POST        | /v1/layouts/{layoutId}/default | Set default layout | Full          |       |

### Workflows

| HTTP Method | Endpoint                          | Description            | Compatability | Notes |
|-------------|-----------------------------------|------------------------|---------------|-------|
| GET         | /v1/workflows                     | Get workflows          | Full          |       |
| POST        | /v1/workflows                     | Create workflow        | Full          |       |
| PUT         | /v1/workflows/{workflowId}        | Update workflow        | Full          |       |
| DELETE      | /v1/workflows/{workflowId}        | Delete workflow        | Full          |       |
| GET         | /v1/workflows/{workflowId}        | Get workflow           | Full          |       |
| PUT         | /v1/workflows/{workflowId}/status | Update workflow status | Full          |       |

### Workflow Groups

| HTTP Method | Endpoint                     | Description           | Compatability | Notes |
|-------------|------------------------------|-----------------------|---------------|-------|
| POST        | /v1/notification-groups      | Create workflow group | Full          |       |
| GET         | /v1/notification-groups      | Get workflow groups   | Full          |       |
| GET         | /v1/notification-groups/{id} | Get workflow group    | Full          |       |
| PATCH       | /v1/notification-groups/{id} | Update workflow group | Full          |       |
| DELETE      | /v1/notification-groups/{id} | Delete workflow group | Full          |       |

### Notes

| HTTP Method | Endpoint                     | Description       | Compatability | Notes |
|-------------|------------------------------|-------------------|---------------|-------|
| GET         | /v1/changes                  | Get changes       | None          |       |
| GET         | /v1/changes/count            | Get changes count | None          |       |
| POST        | /v1/changes/bulk/apply       | Apply changes     | None          |       |
| POST        | /v1/changes/{changeId}/apply | Apply change      | None          |       |

### Environments

| HTTP Method | Endpoint                             | Description             | Compatability | Notes |
|-------------|--------------------------------------|-------------------------|---------------|-------|
| GET         | /v1/environments/me                  | Get current environment | None          |       |
| POST        | /v1/environments                     | Create environment      | None          |       |
| GET         | /v1/environments                     | Get environments        | None          |       |
| GET         | /v1/environments/api-keys            | Get api keys            | None          |       |
| POST        | /v1/environments/api-keys/regenerate | Regenerate api keys     | None          |       |

### Inbound Parse

| HTTP Method | Endpoint                    | Description                                                      | Compatability | Notes |
|-------------|-----------------------------|------------------------------------------------------------------|---------------|-------|
| GET         | /v1/inbound-parse/mx/status | Validate the mx record setup for the inbound parse functionality | None          |       |

### Feeds

| HTTP Method | Endpoint           | Description | Compatability | Notes |
|-------------|--------------------|-------------|---------------|-------|
| POST        | /v1/feeds          | Create feed | None          |       |
| GET         | /v1/feeds          | Get feeds   | None          |       |
| DELETE      | /v1/feeds/{feedId} | Delete feed | None          |       |

### Tenants

| HTTP Method | Endpoint                 | Description   | Compatability | Notes |
|-------------|--------------------------|---------------|---------------|-------|
| GET         | /v1/tenants              | Get tenants   | None          |       |
| POST        | /v1/tenants              | Create tenant | None          |       |
| GET         | /v1/tenants/{identifier} | Get tenant    | None          |       |
| PATCH       | /v1/tenants/{identifier} | Update tenant | None          |       |
| DELETE      | /v1/tenants/{identifier} | Delete tenant | None          |       |

### Messages

| HTTP Method | Endpoint                                 | Description                      | Compatability | Notes |
|-------------|------------------------------------------|----------------------------------|---------------|-------|
| GET         | /v1/messages                             | Get messages                     | Full          |       |
| DELETE      | /v1/messages/{messageId}                 | Delete message                   | Full          |       |
| DELETE      | /v1/messages/transaction/{transactionId} | Delete messages by transactionId | Full          |       |

### Organizations

| HTTP Method | Endpoint                                   | Description                                      | Compatability | Notes |
|-------------|--------------------------------------------|--------------------------------------------------|---------------|-------|
| POST        | /v1/organizations                          | Create an organization                           | None          |       |
| GET         | /v1/organizations                          | Fetch all organizations                          | None          |       |
| PATCH       | /v1/organizations                          | Rename organization name                         | None          |       |
| GET         | /v1/organizations/me                       | Fetch current organization details               | None          |       |
| DELETE      | /v1/organizations/members/{memberId}       | Remove a member from organization using memberId | None          |       |
| PUT         | /v1/organizations/members/{memberId}/roles | Update a member role to admin                    | None          |       |
| GET         | /v1/organizations/members                  | Fetch all members of current organizations       | None          |       |
| PUT         | /v1/organizations/branding                 | Update organization branding details             | None          |       |

### Execution Details

| HTTP Method | Endpoint              | Description           | Compatability | Notes |
|-------------|-----------------------|-----------------------|---------------|-------|
| GET         | /v1/execution-details | Get execution details | Full          |       |

### Default

| HTTP Method | Endpoint                         | Description | Compatability | Notes |
|-------------|----------------------------------|-------------|---------------|-------|
| GET         | /v1/blueprints/group-by-category |             | None          |       |
| GET         | /v1/blueprints/{templateId}      |             | None          |       |





### Events

| HTTP Method | Endpoint                           | Description            | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------|------------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/events/trigger                 | Trigger event          | 0.18.0 |         |         |            | Upgrade       |       |
| POST        | /v1/events/trigger/bulk            | Bulk trigger event     | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/events/trigger/broadcast       | Broadcast event to all | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/events/trigger/{transactionId} | Cancel triggered event | 0.18.0 |         |         |            | Full          |       |

### Subscribers

| HTTP Method | Endpoint                                                               | Description                                                                                                                                          | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/subscribers                                                        | Get subscribers                                                                                                                                      | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/subscribers                                                        | Create subscriber                                                                                                                                    | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/subscribers/{subscriberId}                                         | Get subscriber                                                                                                                                       | 0.18.0 |         |         |            | Full          |       |
| PUT         | /v1/subscribers/{subscriberId}                                         | Update subscriber                                                                                                                                    | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/subscribers/{subscriberId}                                         | Delete subscriber                                                                                                                                    | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/subscribers/bulk                                                   | Bulk create subscribers                                                                                                                              | 0.18.0 |         |         |            | Full          |       |
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

| HTTP Method | Endpoint                                                 | Description            | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|----------------------------------------------------------|------------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/topics                                               | Topic creation         | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/topics                                               | Filter topics          | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/topics/{topicKey}/subscribers                        | Subscribers

 addition   | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/topics/{topicKey}/subscribers/{externalSubscriberId} | Check topic subscriber | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/topics/{topicKey}/subscribers/removal                | Subscribers removal    | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/topics/{topicKey}                                    | Delete topic           | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/topics/{topicKey}                                    | Get topic              | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/topics/{topicKey}                                    | Rename a topic         | 0.18.0 |         |         |            | Full          |       |

### Notification

| HTTP Method | Endpoint                           | Description                       | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------|-----------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/notifications                  | Get notifications                 | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notifications/stats            | Get notification statistics       | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notifications/graph/stats      | Get notification graph statistics | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notifications/{notificationId} | Get notification                  | 0.18.0 |         |         |            | Full          |       |

### Integrations

| HTTP Method | Endpoint                                              | Description                             | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-------------------------------------------------------|-----------------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/integrations                                      | Get integrations                        | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/integrations                                      | Create integration                      | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/integrations/active                               | Get active integrations                 | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/integrations/webhook/provider/{providerId}/status | Get webhook support status for provider | 0.18.0 |         |         |            | Full          |       |
| PUT         | /v1/integrations/{integrationId}                      | Update integration                      | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/integrations/{integrationId}                      | Delete integration                      | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/integrations/{integrationId}/set-primary          | Set integration as primary              | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/integrations/{channelType}/limit                  |                                         | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/integrations/in-app/status                        |                                         | 0.18.0 |         |         |            | Full          |       |

### Layouts

| HTTP Method | Endpoint                       | Description        | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------------------|--------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/layouts                    | Layout creation    | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/layouts                    | Filter layouts     | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/layouts/{layoutId}         | Get layout         | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/layouts/{layoutId}         | Delete layout      | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/layouts/{layoutId}         | Update a layout    | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/layouts/{layoutId}/default | Set default layout | 0.18.0 |         |         |            | Full          |       |

### Workflows

| HTTP Method | Endpoint                          | Description            | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-----------------------------------|------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/workflows                     | Get workflows          | 0.18.0 |         |         |            | Full          |       |
| POST        | /v1/workflows                     | Create workflow        | 0.18.0 |         |         |            | Full          |       |
| PUT         | /v1/workflows/{workflowId}        | Update workflow        | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/workflows/{workflowId}        | Delete workflow        | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/workflows/{workflowId}        | Get workflow           | 0.18.0 |         |         |            | Full          |       |
| PUT         | /v1/workflows/{workflowId}/status | Update workflow status | 0.18.0 |         |         |            | Full          |       |

### Workflow Groups

| HTTP Method | Endpoint                     | Description           | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------|-----------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/notification-groups      | Create workflow group | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notification-groups      | Get workflow groups   | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notification-groups/{id} | Get workflow group    | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/notification-groups/{id} | Update workflow group | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/notification-groups/{id} | Delete workflow group | 0.18.0 |         |         |            |

 Full          |       |

### Notes

| HTTP Method | Endpoint                     | Description       | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------|-------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/changes                  | Get changes       | 0.18.0 |         |         |            | None          |       |
| GET         | /v1/changes/count            | Get changes count | 0.18.0 |         |         |            | None          |       |
| POST        | /v1/changes/bulk/apply       | Apply changes     | 0.18.0 |         |         |            | None          |       |
| POST        | /v1/changes/{changeId}/apply | Apply change      | 0.18.0 |         |         |            | None          |       |

### Environments

| HTTP Method | Endpoint                             | Description             | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------------------------|-------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/environments/me                  | Get current environment | 0.18.0 |         |         |            | None          |       |
| POST        | /v1/environments                     | Create environment      | 0.18.0 |         |         |            | None          |       |
| GET         | /v1/environments                     | Get environments        | 0.18.0 |         |         |            | None          |       |
| GET         | /v1/environments/api-keys            | Get api keys            | 0.18.0 |         |         |            | None          |       |
| POST        | /v1/environments/api-keys/regenerate | Regenerate api keys     | 0.18.0 |         |         |            | None          |       |

### Inbound Parse

| HTTP Method | Endpoint                    | Description                                                      | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-----------------------------|------------------------------------------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/inbound-parse/mx/status | Validate the mx record setup for the inbound parse functionality | 0.18.0 |         |         |            | None          |       |

### Feeds

| HTTP Method | Endpoint           | Description | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------|-------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/feeds          | Create feed | 0.18.0 |         |         |            | None          |       |
| GET         | /v1/feeds          | Get feeds   | 0.18.0 |         |         |            | None          |       |
| DELETE      | /v1/feeds/{feedId} | Delete feed | 0.18.0 |         |         |            | None          |       |

### Tenants

| HTTP Method | Endpoint                 | Description   | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------------|---------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/tenants              | Get tenants   | 0.18.0 |         |         |            | None          |       |
| POST        | /v1/tenants              | Create tenant | 0.18.0 |         |         |            | None          |       |
| GET         | /v1/tenants/{identifier} | Get tenant    | 0.18.0 |         |         |            | None          |       |
| PATCH       | /v1/tenants/{identifier} | Update tenant | 0.18.0 |         |         |            | None          |       |
| DELETE      | /v1/tenants/{identifier} | Delete tenant | 0.18.0 |         |         |            | None          |       |

### Messages

| HTTP Method | Endpoint                                 | Description                      | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------------|----------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/messages                             | Get messages                     | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/messages/{messageId}                 | Delete message                   | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/messages/transaction/{transactionId} | Delete messages by transactionId | 0.18.0 |         |         |            | Full          |       |

### Organizations

| HTTP Method | Endpoint                                   | Description                                      | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|--------------------------------------------|--------------------------------------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/organizations                          | Create an organization                           | 0.18.0 |         |         |            | None          |       |
| GET         | /v1/organizations                          | Fetch all organizations                          | 0.18.0 |         |         |            | None          |       |
| PATCH       | /v1/organizations                          | Rename organization name                         | 0.18.0 |         |         |            | None          |       |
| GET         | /v1/organizations/me                       | Fetch current organization details               | 0.18.0 |         |         |            | None          |       |
| DELETE      | /v1/organizations/members/{memberId}       | Remove a member from organization using memberId | 0.18.0 |         |         |            | None          |       |
| PUT         | /v1/organizations/members/{memberId}/roles | Update a member role to admin                    | 0.18.0 |         |         |            | None          |       |
| GET         | /v1/organizations/members                  | Fetch all members of current organizations       | 0.18.0 |         |         |            | None          |       |
| PUT         | /v1/organizations/branding                 | Update organization branding details             | 0.18.0 |         |         |            | None          |       |

### Execution Details

| HTTP Method | Endpoint              | Description           | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-----------------------|-----------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/execution-details | Get execution details | 0.18.0 |         |         |            | Full          |       |

### Default

| HTTP Method | Endpoint                         | Description | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|----------------------------------|-------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/blueprints/group-by-category |             | 0.18

.0 |         |         |            | Full          |       |
| GET         | /v1/blueprints/list              |             | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/blueprints/{id}              |             | 0.18.0 |         |         |            | Full          |       |
