#### What's New
---

##### `GET` /v1/workflows/variables

> Get available variables


##### `DELETE` /v1/workflow-overrides/{overrideId}

> Delete workflow override


#### What's Deleted
---

##### `PUT` /v1/organizations/members/{memberId}/roles

> Update a member role to admin


##### `DELETE` /v1/workflow-overrides/{workflowOverrideId}

> Delete workflow override


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

##### `DELETE` /v1/messages/transaction/{transactionId}


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


##### `PUT` /v1/organizations/branding


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


##### `GET` /v1/subscribers/{subscriberId}/preferences/{level}


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


##### `GET` /v1/tenants


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


##### `POST` /v1/tenants


###### Return Type:

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **409 Conflict**
> A tenant with the same identifier is already exist.

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


##### `DELETE` /v1/tenants/{identifier}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **204 No Content**
> The tenant has been deleted correctly

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **404 Not Found**
> The tenant with the identifier provided does not exist in the database so it can not be deleted.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


##### `GET` /v1/tenants/{identifier}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **404 Not Found**
> The tenant with the identifier provided does not exist in the database.

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


##### `PATCH` /v1/tenants/{identifier}


###### Return Type:

New response : **409 Conflict**
> The request could not be completed due to a conflict with the current state of the target resource.

New response : **429 null**
> The client has sent too many requests in a given amount of time.

New response : **503 Service Unavailable**
> The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.

Changed response : **404 Not Found**
> The tenant with the identifier provided does not exist in the database.

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


##### `PATCH` /v1/organizations


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


##### `GET` /v1/organizations


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


##### `POST` /v1/organizations


###### Request:

Changed content type : `application/json`

* Added property `jobTitle` (string)

    Enum values:

    * `engineer`
    * `architect`
    * `product_manager`
    * `designer`
    * `engineering_manager`
    * `other`
* Added property `domain` (string)

* Added property `productUseCases` (object)

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


##### `GET` /v1/organizations/me


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


##### `DELETE` /v1/organizations/members/{memberId}


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


##### `GET` /v1/organizations/members


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


                Added enum value:

                * `rocket-chat`
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


                Added enum value:

                * `rocket-chat`
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


                Added enum value:

                * `rocket-chat`
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


                Added enum value:

                * `rocket-chat`
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


    Added enum value:

    * `rocket-chat`
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


                Added enum value:

                * `rocket-chat`
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


                Added enum value:

                * `rocket-chat`
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


##### `PATCH` /v1/subscribers/{subscriberId}/preferences


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

##### `GET` /v1/workflow-overrides/{overrideId}


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


##### `PUT` /v1/workflow-overrides/{overrideId}


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


##### `GET` /v1/workflow-overrides/workflows/{workflowId}/tenants/{tenantId}


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


##### `PUT` /v1/workflow-overrides/workflows/{workflowId}/tenants/{tenantId}


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


##### `POST` /v1/integrations


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


##### `PUT` /v1/integrations/{integrationId}


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


##### `POST` /v1/workflow-overrides


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


##### `GET` /v1/workflow-overrides


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


##### `POST` /v1/notification-templates


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


##### `GET` /v1/notification-templates/{templateId}


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


##### `PUT` /v1/notification-templates/{templateId}


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


##### `POST` /v1/workflows


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


##### `GET` /v1/workflows/{workflowId}


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


##### `PUT` /v1/workflows/{workflowId}


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


                    Added enum value:

                    * `rocket-chat`
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


                    Added enum value:

                    * `rocket-chat`
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


                    Added enum value:

                    * `rocket-chat`
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


