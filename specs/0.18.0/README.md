## API
* **Since:** 0.18.0
* **Latest:** 0.18.0

**Tracking Versions**: New, Changed, Deleted, Deprecated

* **New**: tracked since version
* **Changed**: has had changes on the endpoint attributes
* **Deleted**: was removed (obsolete)
* **Deprecated**: marked as being removed

**Compatability**: Full, Incomplete, None, Upgrade

* **Full**: all attributes are supported on the model on the method/endpoint call
* **None**: the method/endpoint is not implemented
* **Upgrade**: known changes to the attributes are required that are flagged (practically same as incomplete but
  effectively a NEW placeholder)

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

### Notification Templates

| HTTP Method | Endpoint                          | Description            | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-----------------------------------|------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/workflows                     | Get workflows          | 0.18.0 |         |         | 0.18.0     | None          |       |
| POST        | /v1/workflows                     | Create workflow        | 0.18.0 |         |         | 0.18.0     | None          |       |
| PUT         | /v1/workflows/{workflowId}        | Update workflow        | 0.18.0 |         |         | 0.18.0     | None          |       |
| DELETE      | /v1/workflows/{workflowId}        | Delete workflow        | 0.18.0 |         |         | 0.18.0     | None          |       |
| GET         | /v1/workflows/{workflowId}        | Get workflow           | 0.18.0 |         |         | 0.18.0     | None          |       |
| PUT         | /v1/workflows/{workflowId}/status | Update workflow status | 0.18.0 |         |         | 0.18.0     | None          |       |

### Workflow Groups

| HTTP Method | Endpoint                     | Description           | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------|-----------------------|--------|---------|---------|------------|---------------|-------|
| POST        | /v1/notification-groups      | Create workflow group | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notification-groups      | Get workflow groups   | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/notification-groups/{id} | Get workflow group    | 0.18.0 |         |         |            | Full          |       |
| PATCH       | /v1/notification-groups/{id} | Update workflow group | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/notification-groups/{id} | Delete workflow group | 0.18.0 |         |         |            | Full          |       |

### Changes

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
| PUT         | /v1/environments{environmentId}      | Update env by id        | 0.18.0 |         |         |            | None          |       |
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

### Messages

| HTTP Method | Endpoint                                 | Description                      | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|------------------------------------------|----------------------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/messages                             | Get messages                     | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/messages/{messageId}                 | Delete message                   | 0.18.0 |         |         |            | Full          |       |
| DELETE      | /v1/messages/transaction/{transactionId} | Delete messages by transactionId | 0.18.0 |         |         |            | Full          |       |

### Execution Details

| HTTP Method | Endpoint              | Description           | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|-----------------------|-----------------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/execution-details | Get execution details | 0.18.0 |         |         |            | Full          |       |

### Default

| HTTP Method | Endpoint                         | Description | New    | Changed | Deleted | Deprecated | Compatability | Notes |
|-------------|----------------------------------|-------------|--------|---------|---------|------------|---------------|-------|
| GET         | /v1/blueprints/group-by-category |             | 0.18.0 |         |         |            | Full          |       |
| GET         | /v1/blueprints/{id}              |             | 0.18.0 |         |         |            | Full          |       |
