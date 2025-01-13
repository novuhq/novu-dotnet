#### What's New
---

##### `GET` /v1/organizations

> Fetch all organizations


##### `POST` /v1/organizations

> Create an organization


##### `PATCH` /v1/organizations

> Rename organization name


##### `GET` /v1/organizations/me

> Fetch current organization details


##### `DELETE` /v1/organizations/members/{memberId}

> Remove a member from organization using memberId


##### `GET` /v1/organizations/members

> Fetch all members of current organizations


##### `PUT` /v1/organizations/branding

> Update organization branding details


##### `GET` /v1/notification-templates/{workflowIdOrIdentifier}

> Get Notification template


##### `GET` /v1/workflows/variables

> Get available variables


##### `GET` /v1/workflows/{workflowIdOrIdentifier}

> Get workflow


##### `GET` /v1/subscribers/{subscriberId}/preferences/{level}

> Get subscriber preferences by level


##### `GET` /v1/tenants

> Get tenants


##### `POST` /v1/tenants

> Create tenant


##### `GET` /v1/tenants/{identifier}

> Get tenant


##### `DELETE` /v1/tenants/{identifier}

> Delete tenant


##### `PATCH` /v1/tenants/{identifier}

> Update tenant


##### `DELETE` /v1/messages/transaction/{transactionId}

> Delete messages by transactionId


##### `GET` /v1/workflow-overrides

> Get workflow overrides


##### `POST` /v1/workflow-overrides

> Create workflow override


##### `GET` /v1/workflow-overrides/{overrideId}

> Get workflow override by id


##### `PUT` /v1/workflow-overrides/{overrideId}

> Update workflow override by id


##### `DELETE` /v1/workflow-overrides/{overrideId}

> Delete workflow override


##### `GET` /v1/workflow-overrides/workflows/{workflowId}/tenants/{tenantId}

> Get workflow override


##### `PUT` /v1/workflow-overrides/workflows/{workflowId}/tenants/{tenantId}

> Update workflow override


##### `PATCH` /v1/subscribers/{subscriberId}/preferences

> Update subscriber global preferences


##### `PATCH` /v1/subscribers/{subscriberId}/credentials

> Modify subscriber credentials


#### What's Deleted
---

##### `PUT` /v1/environments/{environmentId}

> Update env by id


##### `GET` /v1/integrations/{channelType}/limit


##### `GET` /v1/integrations/in-app/status


##### `POST` /v1/environments

> Create environment


##### `GET` /v1/notification-templates/{templateId}

> Get Notification template


##### `GET` /v1/workflows/{workflowId}

> Get workflow


#### What's Changed
---

##### `POST` /v1/layouts/{layoutId}/default


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **204 No Content**
> The selected layout has been set as the default for the environment.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **404 Not Found**
> The layout with the layoutId provided does not exist in the database so it can not be set as the default for the environment.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/integrations/active


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> The list of active integrations belonging to the organization that are successfully returned.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

##### `GET` /v1/integrations/webhook/provider/{providerId}/status


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> The status of the webhook for the provider requested

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `DELETE` /v1/subscribers/{subscriberId}/credentials/{providerId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **204 No Content**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/subscribers/{subscriberId}/credentials/{providerId}/oauth/callback


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

##### `GET` /v1/subscribers/{subscriberId}/credentials/{providerId}/oauth


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

##### `GET` /v1/inbound-parse/mx/status


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/environments/me


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        New optional properties:
        - `apiKeys`

        * Changed property `apiKeys` (array)

            Changed items (object):

            New optional properties:
            - `_userId`
            - `key`

            * Deleted property `key` (string)

            * Deleted property `_userId` (string)

##### `GET` /v1/environments


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        New optional properties:
        - `apiKeys`

        * Changed property `apiKeys` (array)

            Changed items (object):

            New optional properties:
            - `_userId`
            - `key`

            * Deleted property `key` (string)

            * Deleted property `_userId` (string)

##### `GET` /v1/environments/api-keys


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `POST` /v1/environments/api-keys/regenerate


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/notification-groups


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `POST` /v1/notification-groups


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/notification-groups/{id}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `DELETE` /v1/notification-groups/{id}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `PATCH` /v1/notification-groups/{id}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/changes/count


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `POST` /v1/changes/bulk/apply


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `type` (string)

            Added enum values:

            * `TranslationGroup`
            * `Translation`
##### `POST` /v1/changes/{changeId}/apply


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `type` (string)

            Added enum values:

            * `TranslationGroup`
            * `Translation`
##### `DELETE` /v1/layouts/{layoutId}


###### Return Type:

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **204 No Content**
> The layout has been deleted correctly

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **404 Not Found**
> The layout with the layoutId provided does not exist in the database so it can not be deleted.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **409 Conflict**
> Either you are trying to delete a layout that is being used or a layout that is the default in the environment.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* New content type : `application/json`

##### `GET` /v1/layouts/{layoutId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **404 Not Found**
> The layout with the layoutId provided does not exist in the database.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `PATCH` /v1/layouts/{layoutId}


###### Return Type:

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **400 Bad Request**
> The payload provided or the URL param are not right.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **404 Not Found**
> The layout with the layoutId provided does not exist in the database so it can not be updated.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **409 Conflict**
> One default layout is needed. If you are trying to turn a default layout as not default, you should turn a different layout as default first and automatically it will be done by the system.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* New content type : `application/json`

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/execution-details


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `DELETE` /v1/events/trigger/{transactionId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/subscribers/{subscriberId}/preferences


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `template` (object)
            > The workflow information and if it is critical or not


            New required properties:
            - `triggers`

            * Added property `triggers` (array)
                > Triggers are the events that will trigger the workflow.


                Items (string):

##### `PATCH` /v1/subscribers/{subscriberId}/preferences/{templateId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `template` (object)
            > The workflow information and if it is critical or not


            New required properties:
            - `triggers`

            * Added property `triggers` (array)
                > Triggers are the events that will trigger the workflow.


##### `GET` /v1/subscribers/{subscriberId}/notifications/unseen


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `POST` /v1/subscribers/{subscriberId}/messages/mark-all


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

##### `POST` /v1/topics/{topicKey}/subscribers


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **204 No Content**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/topics/{topicKey}/subscribers/{externalSubscriberId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

##### `POST` /v1/topics/{topicKey}/subscribers/removal


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **204 No Content**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `DELETE` /v1/topics/{topicKey}


###### Return Type:

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **204 No Content**
> The topic has been deleted correctly

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **404 Not Found**
> The topic with the key provided does not exist in the database so it can not be deleted.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **409 Conflict**
> The topic you are trying to delete has subscribers assigned to it. Delete the subscribers before deleting the topic.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* New content type : `application/json`

##### `GET` /v1/topics/{topicKey}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `PATCH` /v1/topics/{topicKey}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/notifications/stats


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/notifications/graph/stats


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/feeds


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `POST` /v1/feeds


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `DELETE` /v1/feeds/{feedId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `DELETE` /v1/messages/{messageId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/changes


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `type` (string)

            Added enum values:

            * `TranslationGroup`
            * `Translation`
##### `POST` /v1/layouts


###### Request:

Deleted content type : `application/json`

###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/layouts


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **400 Bad Request**
> Page size can not be larger than the page size limit.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **200 OK**
> The list of layouts that match the criteria of the query params are successfully returned.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/integrations


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> The list of integrations belonging to the organization that are successfully returned.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

##### `POST` /v1/integrations


###### Request:

Changed content type : `application/json`

* Added property `conditions` (array)

    Items (object):

    * Property `isNegated` (boolean)

    * Property `type` (string)

        Enum values:

        * `BOOLEAN`
        * `TEXT`
        * `DATE`
        * `NUMBER`
        * `STATEMENT`
        * `LIST`
        * `MULTI_LIST`
        * `GROUP`
    * Property `value` (string)

        Enum values:

        * `AND`
        * `OR`
    * Property `children` (array)

        Items (object):

        * Property `field` (string)

        * Property `value` (string)

        * Property `operator` (string)

            Enum values:

            * `LARGER`
            * `SMALLER`
            * `LARGER_EQUAL`
            * `SMALLER_EQUAL`
            * `EQUAL`
            * `NOT_EQUAL`
            * `ALL_IN`
            * `ANY_IN`
            * `NOT_IN`
            * `BETWEEN`
            * `NOT_BETWEEN`
            * `LIKE`
            * `NOT_LIKE`
            * `IN`
        * Property `on` (string)

            Enum values:

            * `subscriber`
            * `payload`
* Changed property `credentials` (object)

    * Added property `apiKeyRequestHeader` (string)

    * Added property `secretKeyRequestHeader` (string)

    * Added property `idPath` (string)

    * Added property `datePath` (string)

    * Added property `apiToken` (string)

    * Added property `authenticateByToken` (boolean)

    * Added property `authenticationTokenKey` (string)

    * Added property `instanceId` (string)

    * Added property `alertUid` (string)

    * Added property `title` (string)

    * Added property `imageUrl` (string)

    * Added property `state` (string)

    * Added property `externalLink` (string)

###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `conditions` (array)

        * Changed property `credentials` (object)

            * Added property `apiKeyRequestHeader` (string)

            * Added property `secretKeyRequestHeader` (string)

            * Added property `idPath` (string)

            * Added property `datePath` (string)

            * Added property `apiToken` (string)

            * Added property `authenticateByToken` (boolean)

            * Added property `authenticationTokenKey` (string)

            * Added property `instanceId` (string)

            * Added property `alertUid` (string)

            * Added property `title` (string)

            * Added property `imageUrl` (string)

            * Added property `state` (string)

            * Added property `externalLink` (string)

##### `PUT` /v1/integrations/{integrationId}


###### Request:

Changed content type : `application/json`

* Added property `conditions` (array)

* Changed property `credentials` (object)

    * Added property `apiKeyRequestHeader` (string)

    * Added property `secretKeyRequestHeader` (string)

    * Added property `idPath` (string)

    * Added property `datePath` (string)

    * Added property `apiToken` (string)

    * Added property `authenticateByToken` (boolean)

    * Added property `authenticationTokenKey` (string)

    * Added property `instanceId` (string)

    * Added property `alertUid` (string)

    * Added property `title` (string)

    * Added property `imageUrl` (string)

    * Added property `state` (string)

    * Added property `externalLink` (string)

###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **404 Not Found**
> The integration with the integrationId provided does not exist in the database.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `conditions` (array)

        * Changed property `credentials` (object)

            * Added property `apiKeyRequestHeader` (string)

            * Added property `secretKeyRequestHeader` (string)

            * Added property `idPath` (string)

            * Added property `datePath` (string)

            * Added property `apiToken` (string)

            * Added property `authenticateByToken` (boolean)

            * Added property `authenticationTokenKey` (string)

            * Added property `instanceId` (string)

            * Added property `alertUid` (string)

            * Added property `title` (string)

            * Added property `imageUrl` (string)

            * Added property `state` (string)

            * Added property `externalLink` (string)

##### `DELETE` /v1/integrations/{integrationId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Added property `conditions` (array)

        * Changed property `credentials` (object)

            * Added property `apiKeyRequestHeader` (string)

            * Added property `secretKeyRequestHeader` (string)

            * Added property `idPath` (string)

            * Added property `datePath` (string)

            * Added property `apiToken` (string)

            * Added property `authenticateByToken` (boolean)

            * Added property `authenticationTokenKey` (string)

            * Added property `instanceId` (string)

            * Added property `alertUid` (string)

            * Added property `title` (string)

            * Added property `imageUrl` (string)

            * Added property `state` (string)

            * Added property `externalLink` (string)

##### `POST` /v1/integrations/{integrationId}/set-primary


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **404 Not Found**
> The integration with the integrationId provided does not exist in the database.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `conditions` (array)

        * Changed property `credentials` (object)

            * Added property `apiKeyRequestHeader` (string)

            * Added property `secretKeyRequestHeader` (string)

            * Added property `idPath` (string)

            * Added property `datePath` (string)

            * Added property `apiToken` (string)

            * Added property `authenticateByToken` (boolean)

            * Added property `authenticationTokenKey` (string)

            * Added property `instanceId` (string)

            * Added property `alertUid` (string)

            * Added property `title` (string)

            * Added property `imageUrl` (string)

            * Added property `state` (string)

            * Added property `externalLink` (string)

Changed response : **201 Created**

* Changed content type : `application/json`

    * Added property `conditions` (array)

    * Changed property `credentials` (object)

        * Added property `apiKeyRequestHeader` (string)

        * Added property `secretKeyRequestHeader` (string)

        * Added property `idPath` (string)

        * Added property `datePath` (string)

        * Added property `apiToken` (string)

        * Added property `authenticateByToken` (boolean)

        * Added property `authenticationTokenKey` (string)

        * Added property `instanceId` (string)

        * Added property `alertUid` (string)

        * Added property `title` (string)

        * Added property `imageUrl` (string)

        * Added property `state` (string)

        * Added property `externalLink` (string)

##### `POST` /v1/events/trigger


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `status` (string)
            > Status for trigger


            Added enum values:

            * `no_workflow_active_steps_defined`
            * `no_workflow_steps_defined`
            * `no_tenant_found`
##### `POST` /v1/events/trigger/broadcast


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `status` (string)
            > Status for trigger


            Added enum values:

            * `no_workflow_active_steps_defined`
            * `no_workflow_steps_defined`
            * `no_tenant_found`
Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `status` (string)
        > Status for trigger


        Added enum values:

        * `no_workflow_active_steps_defined`
        * `no_workflow_steps_defined`
        * `no_tenant_found`
##### `GET` /v1/subscribers


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `ryver`
                * `zulip`
                * `grafana-on-call`
                * `getstream`
                * `rocket-chat`
                * `pushpad`
                * `pusher-beams`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                * Added property `alertUid` (string)
                    > alert_uid for grafana on-call webhook payload


                * Added property `title` (string)
                    > title to be used with grafana on call webhook


                * Added property `imageUrl` (string)
                    > image_url property fo grafana on call webhook


                * Added property `state` (string)
                    > state property fo grafana on call webhook


                * Added property `externalUrl` (string)
                    > link_to_upstream_details property fo grafana on call webhook


##### `POST` /v1/subscribers


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `ryver`
                * `zulip`
                * `grafana-on-call`
                * `getstream`
                * `rocket-chat`
                * `pushpad`
                * `pusher-beams`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                * Added property `alertUid` (string)
                    > alert_uid for grafana on-call webhook payload


                * Added property `title` (string)
                    > title to be used with grafana on call webhook


                * Added property `imageUrl` (string)
                    > image_url property fo grafana on call webhook


                * Added property `state` (string)
                    > state property fo grafana on call webhook


                * Added property `externalUrl` (string)
                    > link_to_upstream_details property fo grafana on call webhook


##### `DELETE` /v1/subscribers/{subscriberId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/subscribers/{subscriberId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `ryver`
                * `zulip`
                * `grafana-on-call`
                * `getstream`
                * `rocket-chat`
                * `pushpad`
                * `pusher-beams`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                * Added property `alertUid` (string)
                    > alert_uid for grafana on-call webhook payload


                * Added property `title` (string)
                    > title to be used with grafana on call webhook


                * Added property `imageUrl` (string)
                    > image_url property fo grafana on call webhook


                * Added property `state` (string)
                    > state property fo grafana on call webhook


                * Added property `externalUrl` (string)
                    > link_to_upstream_details property fo grafana on call webhook


##### `PUT` /v1/subscribers/{subscriberId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `ryver`
                * `zulip`
                * `grafana-on-call`
                * `getstream`
                * `rocket-chat`
                * `pushpad`
                * `pusher-beams`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                * Added property `alertUid` (string)
                    > alert_uid for grafana on-call webhook payload


                * Added property `title` (string)
                    > title to be used with grafana on call webhook


                * Added property `imageUrl` (string)
                    > image_url property fo grafana on call webhook


                * Added property `state` (string)
                    > state property fo grafana on call webhook


                * Added property `externalUrl` (string)
                    > link_to_upstream_details property fo grafana on call webhook


##### `POST` /v1/subscribers/bulk


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

##### `PUT` /v1/subscribers/{subscriberId}/credentials


###### Request:

Changed content type : `application/json`

* Changed property `providerId` (string)
    > The provider identifier for the credentials


    Added enum values:

    * `ryver`
    * `zulip`
    * `grafana-on-call`
    * `getstream`
    * `rocket-chat`
    * `pushpad`
    * `pusher-beams`
* Changed property `credentials` (object)
    > Credentials payload for the specified provider


    * Added property `alertUid` (string)
        > alert_uid for grafana on-call webhook payload


    * Added property `title` (string)
        > title to be used with grafana on call webhook


    * Added property `imageUrl` (string)
        > image_url property fo grafana on call webhook


    * Added property `state` (string)
        > state property fo grafana on call webhook


    * Added property `externalUrl` (string)
        > link_to_upstream_details property fo grafana on call webhook


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `ryver`
                * `zulip`
                * `grafana-on-call`
                * `getstream`
                * `rocket-chat`
                * `pushpad`
                * `pusher-beams`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                * Added property `alertUid` (string)
                    > alert_uid for grafana on-call webhook payload


                * Added property `title` (string)
                    > title to be used with grafana on call webhook


                * Added property `imageUrl` (string)
                    > image_url property fo grafana on call webhook


                * Added property `state` (string)
                    > state property fo grafana on call webhook


                * Added property `externalUrl` (string)
                    > link_to_upstream_details property fo grafana on call webhook


##### `PATCH` /v1/subscribers/{subscriberId}/online-status


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `ryver`
                * `zulip`
                * `grafana-on-call`
                * `getstream`
                * `rocket-chat`
                * `pushpad`
                * `pusher-beams`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                * Added property `alertUid` (string)
                    > alert_uid for grafana on-call webhook payload


                * Added property `title` (string)
                    > title to be used with grafana on call webhook


                * Added property `imageUrl` (string)
                    > image_url property fo grafana on call webhook


                * Added property `state` (string)
                    > state property fo grafana on call webhook


                * Added property `externalUrl` (string)
                    > link_to_upstream_details property fo grafana on call webhook


##### `POST` /v1/topics


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/topics


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/blueprints/group-by-category


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

##### `GET` /v1/blueprints/{templateId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

##### `POST` /v1/events/trigger/bulk


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `status` (string)
            > Status for trigger


            Added enum values:

            * `no_workflow_active_steps_defined`
            * `no_workflow_steps_defined`
            * `no_tenant_found`
##### `GET` /v1/notification-templates


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `triggers` (array)

            Changed items (object):

            * Changed property `type` (string)

                Added enum value:

                * `event`
        * Changed property `steps` (array)

            Changed items (object):

            * Added property `variants` (object)

                * Property `_id` (string)

                * Property `uuid` (string)

                * Property `name` (string)

                * Property `_templateId` (string)

                * Property `active` (boolean)

                * Property `shouldStopOnFail` (boolean)

                * Property `template` (object)

                * Property `filters` (array)

                * Property `_parentId` (object)

                * Property `metadata` (object)

                    One of:

                        * Property `amount` (number)

                        * Property `unit` (string)

                            Enum values:

                            * `seconds`
                            * `minutes`
                            * `hours`
                            * `days`
                            * `weeks`
                            * `months`
                        * Property `digestKey` (string)

                        * Property `type` (string)

                            Enum values:

                            * `regular`
                            * `backoff`
                        * Property `backoff` (boolean)

                        * Property `backoffAmount` (number)

                        * Property `backoffUnit` (string)

                        * Property `updateMode` (boolean)

                        * Property `amount` (number)

                        * Property `unit` (string)

                        * Property `digestKey` (string)

                        * Property `type` (string)

                            Enum value:

                            * `timed`
                        * Property `timed` (object)

                            * Property `atTime` (string)

                            * Property `weekDays` (array)

                                Items (string):

                                Enum values:

                                * `monday`
                                * `tuesday`
                                * `wednesday`
                                * `thursday`
                                * `friday`
                                * `saturday`
                                * `sunday`
                            * Property `monthDays` (array)

                                Items (string):

                            * Property `ordinal` (string)

                                Enum values:

                                * `1`
                                * `2`
                                * `3`
                                * `4`
                                * `5`
                                * `last`
                            * Property `ordinalValue` (string)

                                Enum values:

                                * `day`
                                * `weekday`
                                * `weekend`
                                * `sunday`
                                * `monday`
                                * `tuesday`
                                * `wednesday`
                                * `thursday`
                                * `friday`
                                * `saturday`
                            * Property `monthlyType` (string)

                                Enum values:

                                * `each`
                                * `on`
                        * Property `amount` (number)

                        * Property `unit` (string)

                        * Property `type` (string)

                            Enum value:

                            * `regular`
                        * Property `type` (string)

                            Enum value:

                            * `scheduled`
                        * Property `delayPath` (string)

                * Property `replyCallback` (object)

##### `POST` /v1/notification-templates


###### Request:

Changed content type : `application/json`

* Changed property `steps` (array)

    Changed items (object):

    * Added property `variants` (object)

###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `triggers` (array)

            Changed items (object):

            * Changed property `type` (string)

                Added enum value:

                * `event`
        * Changed property `steps` (array)

            Changed items (object):

            * Added property `variants` (object)

##### `DELETE` /v1/notification-templates/{templateId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `PUT` /v1/notification-templates/{templateId}


###### Request:

Changed content type : `application/json`

* Changed property `steps` (array)

    Changed items (object):

    * Added property `variants` (object)

###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `triggers` (array)

            Changed items (object):

            * Changed property `type` (string)

                Added enum value:

                * `event`
        * Changed property `steps` (array)

            Changed items (object):

            * Added property `variants` (object)

##### `PUT` /v1/notification-templates/{templateId}/status


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `triggers` (array)

            Changed items (object):

            * Changed property `type` (string)

                Added enum value:

                * `event`
        * Changed property `steps` (array)

            Changed items (object):

            * Added property `variants` (object)

##### `GET` /v1/workflows


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        New required properties:
        - `data`
        - `page`
        - `pageSize`
        - `totalCount`

        New optional properties:
        - `_creatorId`
        - `_environmentId`
        - `_notificationGroupId`
        - `_organizationId`
        - `active`
        - `critical`
        - `deleted`
        - `deletedAt`
        - `deletedBy`
        - `description`
        - `draft`
        - `name`
        - `preferenceSettings`
        - `steps`
        - `tags`
        - `triggers`

        * Added property `totalCount` (number)

        * Added property `pageSize` (number)

        * Added property `page` (number)

        * Deleted property `_id` (string)

        * Deleted property `name` (string)

        * Deleted property `description` (string)

        * Deleted property `active` (boolean)

        * Deleted property `draft` (boolean)

        * Deleted property `preferenceSettings` (object)

        * Deleted property `critical` (boolean)

        * Deleted property `tags` (array)

        * Deleted property `steps` (array)

        * Deleted property `_organizationId` (string)

        * Deleted property `_creatorId` (string)

        * Deleted property `_environmentId` (string)

        * Deleted property `triggers` (array)

        * Deleted property `_notificationGroupId` (string)

        * Deleted property `_parentId` (string)

        * Deleted property `deleted` (boolean)

        * Deleted property `deletedAt` (string)

        * Deleted property `deletedBy` (string)

        * Deleted property `notificationGroup` (object)

        * Deleted property `workflowIntegrationStatus` (object)

        * Changed property `data` (object -> array)

##### `POST` /v1/workflows


###### Request:

Changed content type : `application/json`

* Changed property `steps` (array)

    Changed items (object):

    * Added property `variants` (object)

###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `triggers` (array)

            Changed items (object):

            * Changed property `type` (string)

                Added enum value:

                * `event`
        * Changed property `steps` (array)

            Changed items (object):

            * Added property `variants` (object)

##### `DELETE` /v1/workflows/{workflowId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `PUT` /v1/workflows/{workflowId}


###### Request:

Changed content type : `application/json`

* Changed property `steps` (array)

    Changed items (object):

    * Added property `variants` (object)

###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `triggers` (array)

            Changed items (object):

            * Changed property `type` (string)

                Added enum value:

                * `event`
        * Changed property `steps` (array)

            Changed items (object):

            * Added property `variants` (object)

##### `PUT` /v1/workflows/{workflowId}/status


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `triggers` (array)

            Changed items (object):

            * Changed property `type` (string)

                Added enum value:

                * `event`
        * Changed property `steps` (array)

            Changed items (object):

            * Added property `variants` (object)

##### `GET` /v1/subscribers/{subscriberId}/notifications/feed


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `subscriber` (object)

            * Changed property `channels` (array)
                > Channels settings for subscriber


                Changed items (object):

                * Changed property `providerId` (string)
                    > The provider identifier for the credentials


                    Added enum values:

                    * `ryver`
                    * `zulip`
                    * `grafana-on-call`
                    * `getstream`
                    * `rocket-chat`
                    * `pushpad`
                    * `pusher-beams`
                * Changed property `credentials` (object)
                    > Credentials payload for the specified provider


                    * Added property `alertUid` (string)
                        > alert_uid for grafana on-call webhook payload


                    * Added property `title` (string)
                        > title to be used with grafana on call webhook


                    * Added property `imageUrl` (string)
                        > image_url property fo grafana on call webhook


                    * Added property `state` (string)
                        > state property fo grafana on call webhook


                    * Added property `externalUrl` (string)
                        > link_to_upstream_details property fo grafana on call webhook


        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object):

                * Changed property `type` (string)

                    Added enum value:

                    * `event`
            * Changed property `steps` (array)

                Changed items (object):

                * Added property `variants` (object)

##### `POST` /v1/subscribers/{subscriberId}/messages/markAs


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `subscriber` (object)

            * Changed property `channels` (array)
                > Channels settings for subscriber


                Changed items (object):

                * Changed property `providerId` (string)
                    > The provider identifier for the credentials


                    Added enum values:

                    * `ryver`
                    * `zulip`
                    * `grafana-on-call`
                    * `getstream`
                    * `rocket-chat`
                    * `pushpad`
                    * `pusher-beams`
                * Changed property `credentials` (object)
                    > Credentials payload for the specified provider


                    * Added property `alertUid` (string)
                        > alert_uid for grafana on-call webhook payload


                    * Added property `title` (string)
                        > title to be used with grafana on call webhook


                    * Added property `imageUrl` (string)
                        > image_url property fo grafana on call webhook


                    * Added property `state` (string)
                        > state property fo grafana on call webhook


                    * Added property `externalUrl` (string)
                        > link_to_upstream_details property fo grafana on call webhook


        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object):

                * Changed property `type` (string)

                    Added enum value:

                    * `event`
            * Changed property `steps` (array)

                Changed items (object):

                * Added property `variants` (object)

##### `POST` /v1/subscribers/{subscriberId}/messages/{messageId}/actions/{type}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `subscriber` (object)

            * Changed property `channels` (array)
                > Channels settings for subscriber


                Changed items (object):

                * Changed property `providerId` (string)
                    > The provider identifier for the credentials


                    Added enum values:

                    * `ryver`
                    * `zulip`
                    * `grafana-on-call`
                    * `getstream`
                    * `rocket-chat`
                    * `pushpad`
                    * `pusher-beams`
                * Changed property `credentials` (object)
                    > Credentials payload for the specified provider


                    * Added property `alertUid` (string)
                        > alert_uid for grafana on-call webhook payload


                    * Added property `title` (string)
                        > title to be used with grafana on call webhook


                    * Added property `imageUrl` (string)
                        > image_url property fo grafana on call webhook


                    * Added property `state` (string)
                        > state property fo grafana on call webhook


                    * Added property `externalUrl` (string)
                        > link_to_upstream_details property fo grafana on call webhook


        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object):

                * Changed property `type` (string)

                    Added enum value:

                    * `event`
            * Changed property `steps` (array)

                Changed items (object):

                * Added property `variants` (object)

##### `GET` /v1/notifications/{notificationId}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
> Ok

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object):

                * Changed property `type` (string)

                    Added enum value:

                    * `event`
##### `GET` /v1/notifications


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object):

                * Changed property `type` (string)

                    Added enum value:

                    * `event`
##### `GET` /v1/messages


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object):

                * Changed property `type` (string)

                    Added enum value:

                    * `event`
