#### What's New
---

##### `POST` /v1/subscribers/{subscriberId}/messages/mark-as

> Mark a subscriber messages as seen, read, unseen or unread


##### `GET` /v2/subscribers

> Search for subscribers


##### `POST` /v2/subscribers

> Create subscriber


##### `GET` /v2/subscribers/{subscriberId}

> Get subscriber


##### `DELETE` /v2/subscribers/{subscriberId}

> Delete subscriber


##### `PATCH` /v2/subscribers/{subscriberId}

> Patch subscriber


##### `GET` /v2/subscribers/{subscriberId}/preferences

> Get subscriber preferences


##### `PATCH` /v2/subscribers/{subscriberId}/preferences

> Update subscriber global or workflow specific preferences


##### `GET` /v2/workflows


##### `POST` /v2/workflows


##### `PUT` /v2/workflows/{workflowId}/sync


##### `GET` /v2/workflows/{workflowId}


##### `PUT` /v2/workflows/{workflowId}


##### `DELETE` /v2/workflows/{workflowId}


##### `PATCH` /v2/workflows/{workflowId}


#### What's Deleted
---

##### `GET` /v1/inbound-parse/mx/status

> Validate the mx record setup for the inbound parse functionality


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


##### `GET` /v1/environments/me

> Get current environment


##### `GET` /v1/environments

> Get environments


##### `GET` /v1/environments/api-keys

> Get api keys


##### `POST` /v1/environments/api-keys/regenerate

> Regenerate api keys


##### `GET` /v1/notification-groups

> Get workflow groups


##### `POST` /v1/notification-groups

> Create workflow group


##### `GET` /v1/notification-groups/{id}

> Get workflow group


##### `DELETE` /v1/notification-groups/{id}

> Delete workflow group


##### `PATCH` /v1/notification-groups/{id}

> Update workflow group


##### `GET` /v1/changes

> Get changes


##### `GET` /v1/changes/count

> Get changes count


##### `POST` /v1/changes/bulk/apply

> Apply changes


##### `POST` /v1/changes/{changeId}/apply

> Apply change


##### `GET` /v1/layouts

> Filter layouts


##### `POST` /v1/layouts

> Layout creation


##### `GET` /v1/layouts/{layoutId}

> Get layout


##### `DELETE` /v1/layouts/{layoutId}

> Delete layout


##### `PATCH` /v1/layouts/{layoutId}

> Update a layout


##### `POST` /v1/layouts/{layoutId}/default

> Set default layout


##### `GET` /v1/execution-details

> Get execution details


##### `GET` /v1/notification-templates

> Get Notification templates


##### `POST` /v1/notification-templates

> Create Notification template


##### `PUT` /v1/notification-templates/{templateId}

> Update Notification template


##### `DELETE` /v1/notification-templates/{templateId}

> Delete Notification template


##### `GET` /v1/notification-templates/{workflowIdOrIdentifier}

> Get Notification template


##### `PUT` /v1/notification-templates/{templateId}/status

> Update Notification template status


##### `GET` /v1/workflows

> Get workflows


##### `POST` /v1/workflows

> Create workflow


##### `PUT` /v1/workflows/{workflowId}

> Update workflow


##### `DELETE` /v1/workflows/{workflowId}

> Delete workflow


##### `GET` /v1/workflows/variables

> Get available variables


##### `GET` /v1/workflows/{workflowIdOrIdentifier}

> Get workflow


##### `PUT` /v1/workflows/{workflowId}/status

> Update workflow status


##### `GET` /v1/subscribers/{subscriberId}/preferences

> Get subscriber preferences


##### `PATCH` /v1/subscribers/{subscriberId}/preferences

> Update subscriber global preferences


##### `GET` /v1/subscribers/{subscriberId}/preferences/{level}

> Get subscriber preferences by level


##### `PATCH` /v1/subscribers/{subscriberId}/preferences/{templateId}

> Update subscriber preference


##### `POST` /v1/subscribers/{subscriberId}/messages/markAs

> Mark a subscriber feed message as seen/unseen/read/unread


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


##### `GET` /v1/feeds

> Get feeds


##### `POST` /v1/feeds

> Create feed


##### `DELETE` /v1/feeds/{feedId}

> Delete feed


##### `GET` /v1/blueprints/group-by-category


##### `GET` /v1/blueprints/{templateIdOrIdentifier}


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


##### `POST` /v1/subscribers

> Create subscriber


##### `GET` /v1/subscribers/{subscriberId}

> Get subscriber


##### `DELETE` /v1/subscribers/{subscriberId}

> Delete subscriber


#### What's Changed
---

##### `GET` /v1/integrations/webhook/provider/{providerOrIntegrationId}/status


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `DELETE` /v1/events/trigger/{transactionId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **200 OK**

* Changed content type : `application/json`

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `DELETE` /v1/subscribers/{subscriberId}/credentials/{providerId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `GET` /v1/subscribers/{subscriberId}/notifications/feed


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `GET` /v1/subscribers/{subscriberId}/credentials/{providerId}/oauth/callback


###### Parameters:

Changed: `providerId` in `path`

Changed: `code` in `query`
> Optional authorization code returned from the OAuth provider


Changed: `hmacHash` in `query`
> HMAC hash for the request


Changed: `environmentId` in `query`
> The ID of the environment, must be a valid MongoDB ID


Changed: `integrationIdentifier` in `query`
> Optional integration identifier


###### Return Type:

New response : **302 Moved Temporarily**
> Redirects to the specified URL.

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **200 OK**
> Returns plain text response.

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* New content type : `text/html`

* Deleted content type : `application/json`

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `GET` /v1/subscribers/{subscriberId}/credentials/{providerId}/oauth


###### Parameters:

Changed: `providerId` in `path`

Changed: `hmacHash` in `query`
> HMAC hash for the request


Changed: `environmentId` in `query`
> The ID of the environment, must be a valid MongoDB ID


Changed: `integrationIdentifier` in `query`
> Optional integration identifier


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `DELETE` /v1/messages/transaction/{transactionId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `GET` /v1/subscribers/{subscriberId}/notifications/unseen


###### Parameters:

Changed: `seen` in `query`
> Indicates whether to count seen notifications.


Changed: `limit` in `query`
> The maximum number of notifications to return.


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `POST` /v1/subscribers/{subscriberId}/messages/mark-all


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **201 Created**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`


Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `POST` /v1/topics/{topicKey}/subscribers


###### Parameters:

Changed: `topicKey` in `path`
> The topic key


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Deleted response : **204 No Content**
Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* New content type : `application/json`

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `GET` /v1/topics/{topicKey}/subscribers/{externalSubscriberId}


###### Parameters:

Changed: `topicKey` in `path`
> The topic key


Changed: `externalSubscriberId` in `path`
> The external subscriber id


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `_organizationId` (string)
        > Unique identifier for the organization


    * Changed property `_environmentId` (string)
        > Unique identifier for the environment


    * Changed property `_subscriberId` (string)
        > Unique identifier for the subscriber


    * Changed property `_topicId` (string)
        > Unique identifier for the topic


    * Changed property `topicKey` (string)
        > Key associated with the topic


    * Changed property `externalSubscriberId` (string)
        > External identifier for the subscriber


##### `POST` /v1/topics/{topicKey}/subscribers/removal


###### Parameters:

Changed: `topicKey` in `path`
> The topic key


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `DELETE` /v1/topics/{topicKey}


###### Parameters:

Changed: `topicKey` in `path`
> The topic key


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **404 Not Found**
> Not Found


* New content type : `application/json`

Changed response : **409 Conflict**
> Conflict


* Changed content type : `application/json`

##### `GET` /v1/topics/{topicKey}


###### Parameters:

Changed: `topicKey` in `path`
> The topic key


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `PATCH` /v1/topics/{topicKey}


###### Parameters:

Changed: `topicKey` in `path`
> The topic key


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `GET` /v1/notifications/stats


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `GET` /v1/notifications/graph/stats


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `DELETE` /v1/messages/{messageId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `POST` /v1/events/trigger


###### Request:

Changed content type : `application/json`

* Changed property `payload` (object)
    > The payload object is used to pass additional custom information that could be 
    >     used to render the workflow, or perform routing rules based on it. 
    >       This data will also be available when fetching the notifications feed from the API to display certain parts of the UI.


* Changed property `overrides` (object)
    > This could be used to override provider specific configurations


* Changed property `to` (array -> object)
    > The recipients list of people who will receive the notification.


* Changed property `transactionId` (string)
    > A unique identifier for this transaction, we will generate a UUID if not provided.


* Changed property `actor` (object)
    > It is used to display the Avatar of the provided actor's subscriber id or actor object.
    >     If a new actor object is provided, we will create a new subscriber in our system


    Updated `SubscriberPayloadDto` :
    * Added property `channels` (array)
        > An optional array of subscriber channels.


        Items (object):

        * Property `providerId` (string)
            > The ID of the chat or push provider.


            Enum values:

            * `slack`
            * `discord`
            * `msteams`
            * `mattermost`
            * `ryver`
            * `zulip`
            * `grafana-on-call`
            * `getstream`
            * `rocket-chat`
            * `whatsapp-business`
            * `fcm`
            * `apns`
            * `expo`
            * `one-signal`
            * `pushpad`
            * `push-webhook`
            * `pusher-beams`
        * Property `integrationIdentifier` (string)
            > An optional identifier for the integration.


        * Property `credentials` (object)
            > Credentials for the channel.


            * Property `webhookUrl` (string)
                > The URL for the webhook associated with the channel.


            * Property `deviceTokens` (array)
                > An array of device tokens for push notifications.


                Items (string):

    * Added property `timezone` (string)
        > The timezone of the subscriber.


    * Changed property `email` (string)
        > The email address of the subscriber.


    * Changed property `firstName` (string)
        > The first name of the subscriber.


    * Changed property `lastName` (string)
        > The last name of the subscriber.


    * Changed property `phone` (string)
        > The phone number of the subscriber.


    * Changed property `avatar` (string)
        > An HTTP URL to the profile image of your subscriber.


    * Changed property `locale` (string)
        > The locale of the subscriber.


    * Changed property `data` (object)
        > An optional payload object that can contain any properties.


* Changed property `tenant` (object)
    > It is used to specify a tenant context during trigger event.
    >     Existing tenants will be updated with the provided details.


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **201 Created**
> Created


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `acknowledged` (boolean)
            > Indicates whether the trigger was acknowledged or not


        * Changed property `status` (string)
            > Status of the trigger


            Added enum value:

            * `invalid_recipients`
            Removed enum value:

            * `subscriber_id_missing`
        * Changed property `error` (array)
            > In case of an error, this field will contain the error message(s)


        * Changed property `transactionId` (string)
            > The returned transaction ID of the trigger


##### `POST` /v1/events/trigger/broadcast


###### Request:

Changed content type : `application/json`

* Changed property `payload` (object)
    > The payload object is used to pass additional information that 
    >     could be used to render the template, or perform routing rules based on it. 
    >       For In-App channel, payload data are also available in <Inbox />


* Changed property `actor` (object)
    > It is used to display the Avatar of the provided actor's subscriber id or actor object.
    >     If a new actor object is provided, we will create a new subscriber in our system


    Updated `SubscriberPayloadDto` :
    * Added property `channels` (array)
        > An optional array of subscriber channels.


    * Added property `timezone` (string)
        > The timezone of the subscriber.


    * Changed property `email` (string)
        > The email address of the subscriber.


    * Changed property `firstName` (string)
        > The first name of the subscriber.


    * Changed property `lastName` (string)
        > The last name of the subscriber.


    * Changed property `phone` (string)
        > The phone number of the subscriber.


    * Changed property `avatar` (string)
        > An HTTP URL to the profile image of your subscriber.


    * Changed property `locale` (string)
        > The locale of the subscriber.


    * Changed property `data` (object)
        > An optional payload object that can contain any properties.


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `acknowledged` (boolean)
            > Indicates whether the trigger was acknowledged or not


        * Changed property `status` (string)
            > Status of the trigger


            Added enum value:

            * `invalid_recipients`
            Removed enum value:

            * `subscriber_id_missing`
        * Changed property `error` (array)
            > In case of an error, this field will contain the error message(s)


        * Changed property `transactionId` (string)
            > The returned transaction ID of the trigger


Changed response : **201 Created**
> Broadcast request has been registered successfully

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* Changed content type : `application/json`

    * Changed property `acknowledged` (boolean)
        > Indicates whether the trigger was acknowledged or not


    * Changed property `status` (string)
        > Status of the trigger


        Added enum value:

        * `invalid_recipients`
        Removed enum value:

        * `subscriber_id_missing`
    * Changed property `error` (array)
        > In case of an error, this field will contain the error message(s)


    * Changed property `transactionId` (string)
        > The returned transaction ID of the trigger


##### `GET` /v1/subscribers


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Added property `topics` (array)
            > An array of topics that the subscriber is subscribed to.


            Items (string):

        * Added property `data` (object)
            > Additional custom data for the subscriber


        * Added property `timezone` (string)
            > Timezone of the subscriber


        * Changed property `_id` (string)
            > The internal ID generated by Novu for your subscriber. This ID does not match the `subscriberId` used in your queries. Refer to `subscriberId` for that identifier.


        * Changed property `firstName` (string)
            > The first name of the subscriber.


        * Changed property `lastName` (string)
            > The last name of the subscriber.


        * Changed property `email` (string)
            > The email address of the subscriber.


        * Changed property `phone` (string)
            > The phone number of the subscriber.


        * Changed property `avatar` (string)
            > The URL of the subscriber's avatar image.


        * Changed property `locale` (string)
            > The locale setting of the subscriber, indicating their preferred language or region.


        * Changed property `subscriberId` (string)
            > The identifier used to create this subscriber, which typically corresponds to the user ID in your system.


        * Changed property `isOnline` (boolean)
            > Indicates whether the subscriber is currently online.


        * Changed property `lastOnlineAt` (string)
            > The timestamp indicating when the subscriber was last online, in ISO 8601 format.


        * Changed property `_organizationId` (string)
            > The unique identifier of the organization to which the subscriber belongs.


        * Changed property `_environmentId` (string)
            > The unique identifier of the environment associated with this subscriber.


        * Changed property `deleted` (boolean)
            > Indicates whether the subscriber has been deleted.


        * Changed property `createdAt` (string)
            > The timestamp indicating when the subscriber was created, in ISO 8601 format.


        * Changed property `updatedAt` (string)
            > The timestamp indicating when the subscriber was last updated, in ISO 8601 format.


        * Changed property `__v` (number)
            > The version of the subscriber document.


        * Changed property `channels` (array)
            > An array of channel settings associated with the subscriber.


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum value:

                * `whatsapp-business`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                New optional properties:
                - `webhookUrl`

                * Changed property `webhookUrl` (string)
                    > Webhook URL used by chat app integrations. The webhook should be obtained from the chat app provider.


                * Changed property `channel` (string)
                    > Channel specification for Mattermost chat notifications.


                * Changed property `deviceTokens` (array)
                    > Contains an array of the subscriber device tokens for a given provider. Used on Push integrations.


                * Changed property `alertUid` (string)
                    > Alert UID for Grafana on-call webhook payload.


                * Changed property `title` (string)
                    > Title to be used with Grafana on-call webhook.


                * Changed property `imageUrl` (string)
                    > Image URL property for Grafana on-call webhook.


                * Changed property `state` (string)
                    > State property for Grafana on-call webhook.


                * Changed property `externalUrl` (string)
                    > Link to upstream details property for Grafana on-call webhook.


            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `PUT` /v1/subscribers/{subscriberId}

> Upsert subscriber


###### Request:

Changed content type : `application/json`

* Added property `channels` (array)
    > An array of communication channels for the subscriber.


    Items (object):

* Changed property `email` (string)
    > The email address of the subscriber.


* Changed property `firstName` (string)
    > The first name of the subscriber.


* Changed property `lastName` (string)
    > The last name of the subscriber.


* Changed property `phone` (string)
    > The phone number of the subscriber.


* Changed property `avatar` (string)
    > The avatar URL of the subscriber.


* Changed property `locale` (string)
    > The locale of the subscriber, for example "en-US".


* Changed property `data` (object)
    > Custom data associated with the subscriber. Can contain any additional properties.


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `topics` (array)
            > An array of topics that the subscriber is subscribed to.


        * Added property `data` (object)
            > Additional custom data for the subscriber


        * Added property `timezone` (string)
            > Timezone of the subscriber


        * Changed property `_id` (string)
            > The internal ID generated by Novu for your subscriber. This ID does not match the `subscriberId` used in your queries. Refer to `subscriberId` for that identifier.


        * Changed property `firstName` (string)
            > The first name of the subscriber.


        * Changed property `lastName` (string)
            > The last name of the subscriber.


        * Changed property `email` (string)
            > The email address of the subscriber.


        * Changed property `phone` (string)
            > The phone number of the subscriber.


        * Changed property `avatar` (string)
            > The URL of the subscriber's avatar image.


        * Changed property `locale` (string)
            > The locale setting of the subscriber, indicating their preferred language or region.


        * Changed property `subscriberId` (string)
            > The identifier used to create this subscriber, which typically corresponds to the user ID in your system.


        * Changed property `isOnline` (boolean)
            > Indicates whether the subscriber is currently online.


        * Changed property `lastOnlineAt` (string)
            > The timestamp indicating when the subscriber was last online, in ISO 8601 format.


        * Changed property `_organizationId` (string)
            > The unique identifier of the organization to which the subscriber belongs.


        * Changed property `_environmentId` (string)
            > The unique identifier of the environment associated with this subscriber.


        * Changed property `deleted` (boolean)
            > Indicates whether the subscriber has been deleted.


        * Changed property `createdAt` (string)
            > The timestamp indicating when the subscriber was created, in ISO 8601 format.


        * Changed property `updatedAt` (string)
            > The timestamp indicating when the subscriber was last updated, in ISO 8601 format.


        * Changed property `__v` (number)
            > The version of the subscriber document.


        * Changed property `channels` (array)
            > An array of channel settings associated with the subscriber.


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum value:

                * `whatsapp-business`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                New optional properties:
                - `webhookUrl`

                * Changed property `webhookUrl` (string)
                    > Webhook URL used by chat app integrations. The webhook should be obtained from the chat app provider.


                * Changed property `channel` (string)
                    > Channel specification for Mattermost chat notifications.


                * Changed property `deviceTokens` (array)
                    > Contains an array of the subscriber device tokens for a given provider. Used on Push integrations.


                * Changed property `alertUid` (string)
                    > Alert UID for Grafana on-call webhook payload.


                * Changed property `title` (string)
                    > Title to be used with Grafana on-call webhook.


                * Changed property `imageUrl` (string)
                    > Image URL property for Grafana on-call webhook.


                * Changed property `state` (string)
                    > State property for Grafana on-call webhook.


                * Changed property `externalUrl` (string)
                    > Link to upstream details property for Grafana on-call webhook.


            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `POST` /v1/subscribers/bulk


###### Request:

Changed content type : `application/json`

* Changed property `subscribers` (array)
    > An array of subscribers to be created in bulk.


    Changed items (object):

    * Added property `timezone` (string)
        > Timezone of the subscriber


    * Changed property `subscriberId` (string)
        > Unique identifier of the subscriber


    * Changed property `email` (string)
        > Email address of the subscriber


    * Changed property `firstName` (string)
        > First name of the subscriber


    * Changed property `lastName` (string)
        > Last name of the subscriber


    * Changed property `phone` (string)
        > Phone number of the subscriber


    * Changed property `avatar` (string)
        > Avatar URL or identifier


    * Changed property `locale` (string)
        > Locale of the subscriber


    * Changed property `data` (object)
        > Additional custom data for the subscriber


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **201 Created**
> Created

New header : `Content-Type`


New header : `RateLimit-Limit`


New header : `RateLimit-Remaining`


New header : `RateLimit-Reset`


New header : `RateLimit-Policy`


New header : `Idempotency-Key`


New header : `Idempotency-Replay`



* New content type : `application/json`

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `PUT` /v1/subscribers/{subscriberId}/credentials


###### Request:

Changed content type : `application/json`

* Changed property `providerId` (string)
    > The provider identifier for the credentials


    Added enum value:

    * `whatsapp-business`
* Changed property `credentials` (object)
    > Credentials payload for the specified provider


    New optional properties:
    - `webhookUrl`

    * Changed property `webhookUrl` (string)
        > Webhook URL used by chat app integrations. The webhook should be obtained from the chat app provider.


    * Changed property `channel` (string)
        > Channel specification for Mattermost chat notifications.


    * Changed property `deviceTokens` (array)
        > Contains an array of the subscriber device tokens for a given provider. Used on Push integrations.


    * Changed property `alertUid` (string)
        > Alert UID for Grafana on-call webhook payload.


    * Changed property `title` (string)
        > Title to be used with Grafana on-call webhook.


    * Changed property `imageUrl` (string)
        > Image URL property for Grafana on-call webhook.


    * Changed property `state` (string)
        > State property for Grafana on-call webhook.


    * Changed property `externalUrl` (string)
        > Link to upstream details property for Grafana on-call webhook.


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `topics` (array)
            > An array of topics that the subscriber is subscribed to.


        * Added property `data` (object)
            > Additional custom data for the subscriber


        * Added property `timezone` (string)
            > Timezone of the subscriber


        * Changed property `_id` (string)
            > The internal ID generated by Novu for your subscriber. This ID does not match the `subscriberId` used in your queries. Refer to `subscriberId` for that identifier.


        * Changed property `firstName` (string)
            > The first name of the subscriber.


        * Changed property `lastName` (string)
            > The last name of the subscriber.


        * Changed property `email` (string)
            > The email address of the subscriber.


        * Changed property `phone` (string)
            > The phone number of the subscriber.


        * Changed property `avatar` (string)
            > The URL of the subscriber's avatar image.


        * Changed property `locale` (string)
            > The locale setting of the subscriber, indicating their preferred language or region.


        * Changed property `subscriberId` (string)
            > The identifier used to create this subscriber, which typically corresponds to the user ID in your system.


        * Changed property `isOnline` (boolean)
            > Indicates whether the subscriber is currently online.


        * Changed property `lastOnlineAt` (string)
            > The timestamp indicating when the subscriber was last online, in ISO 8601 format.


        * Changed property `_organizationId` (string)
            > The unique identifier of the organization to which the subscriber belongs.


        * Changed property `_environmentId` (string)
            > The unique identifier of the environment associated with this subscriber.


        * Changed property `deleted` (boolean)
            > Indicates whether the subscriber has been deleted.


        * Changed property `createdAt` (string)
            > The timestamp indicating when the subscriber was created, in ISO 8601 format.


        * Changed property `updatedAt` (string)
            > The timestamp indicating when the subscriber was last updated, in ISO 8601 format.


        * Changed property `__v` (number)
            > The version of the subscriber document.


        * Changed property `channels` (array)
            > An array of channel settings associated with the subscriber.


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum value:

                * `whatsapp-business`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                New optional properties:
                - `webhookUrl`

                * Changed property `webhookUrl` (string)
                    > Webhook URL used by chat app integrations. The webhook should be obtained from the chat app provider.


                * Changed property `channel` (string)
                    > Channel specification for Mattermost chat notifications.


                * Changed property `deviceTokens` (array)
                    > Contains an array of the subscriber device tokens for a given provider. Used on Push integrations.


                * Changed property `alertUid` (string)
                    > Alert UID for Grafana on-call webhook payload.


                * Changed property `title` (string)
                    > Title to be used with Grafana on-call webhook.


                * Changed property `imageUrl` (string)
                    > Image URL property for Grafana on-call webhook.


                * Changed property `state` (string)
                    > State property for Grafana on-call webhook.


                * Changed property `externalUrl` (string)
                    > Link to upstream details property for Grafana on-call webhook.


            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `PATCH` /v1/subscribers/{subscriberId}/credentials


###### Request:

Changed content type : `application/json`

* Changed property `providerId` (string)
    > The provider identifier for the credentials


    Added enum value:

    * `whatsapp-business`
* Changed property `credentials` (object)
    > Credentials payload for the specified provider


    New optional properties:
    - `webhookUrl`

    * Changed property `webhookUrl` (string)
        > Webhook URL used by chat app integrations. The webhook should be obtained from the chat app provider.


    * Changed property `channel` (string)
        > Channel specification for Mattermost chat notifications.


    * Changed property `deviceTokens` (array)
        > Contains an array of the subscriber device tokens for a given provider. Used on Push integrations.


    * Changed property `alertUid` (string)
        > Alert UID for Grafana on-call webhook payload.


    * Changed property `title` (string)
        > Title to be used with Grafana on-call webhook.


    * Changed property `imageUrl` (string)
        > Image URL property for Grafana on-call webhook.


    * Changed property `state` (string)
        > State property for Grafana on-call webhook.


    * Changed property `externalUrl` (string)
        > Link to upstream details property for Grafana on-call webhook.


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `topics` (array)
            > An array of topics that the subscriber is subscribed to.


        * Added property `data` (object)
            > Additional custom data for the subscriber


        * Added property `timezone` (string)
            > Timezone of the subscriber


        * Changed property `_id` (string)
            > The internal ID generated by Novu for your subscriber. This ID does not match the `subscriberId` used in your queries. Refer to `subscriberId` for that identifier.


        * Changed property `firstName` (string)
            > The first name of the subscriber.


        * Changed property `lastName` (string)
            > The last name of the subscriber.


        * Changed property `email` (string)
            > The email address of the subscriber.


        * Changed property `phone` (string)
            > The phone number of the subscriber.


        * Changed property `avatar` (string)
            > The URL of the subscriber's avatar image.


        * Changed property `locale` (string)
            > The locale setting of the subscriber, indicating their preferred language or region.


        * Changed property `subscriberId` (string)
            > The identifier used to create this subscriber, which typically corresponds to the user ID in your system.


        * Changed property `isOnline` (boolean)
            > Indicates whether the subscriber is currently online.


        * Changed property `lastOnlineAt` (string)
            > The timestamp indicating when the subscriber was last online, in ISO 8601 format.


        * Changed property `_organizationId` (string)
            > The unique identifier of the organization to which the subscriber belongs.


        * Changed property `_environmentId` (string)
            > The unique identifier of the environment associated with this subscriber.


        * Changed property `deleted` (boolean)
            > Indicates whether the subscriber has been deleted.


        * Changed property `createdAt` (string)
            > The timestamp indicating when the subscriber was created, in ISO 8601 format.


        * Changed property `updatedAt` (string)
            > The timestamp indicating when the subscriber was last updated, in ISO 8601 format.


        * Changed property `__v` (number)
            > The version of the subscriber document.


        * Changed property `channels` (array)
            > An array of channel settings associated with the subscriber.


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum value:

                * `whatsapp-business`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                New optional properties:
                - `webhookUrl`

                * Changed property `webhookUrl` (string)
                    > Webhook URL used by chat app integrations. The webhook should be obtained from the chat app provider.


                * Changed property `channel` (string)
                    > Channel specification for Mattermost chat notifications.


                * Changed property `deviceTokens` (array)
                    > Contains an array of the subscriber device tokens for a given provider. Used on Push integrations.


                * Changed property `alertUid` (string)
                    > Alert UID for Grafana on-call webhook payload.


                * Changed property `title` (string)
                    > Title to be used with Grafana on-call webhook.


                * Changed property `imageUrl` (string)
                    > Image URL property for Grafana on-call webhook.


                * Changed property `state` (string)
                    > State property for Grafana on-call webhook.


                * Changed property `externalUrl` (string)
                    > Link to upstream details property for Grafana on-call webhook.


            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `PATCH` /v1/subscribers/{subscriberId}/online-status


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `topics` (array)
            > An array of topics that the subscriber is subscribed to.


        * Added property `data` (object)
            > Additional custom data for the subscriber


        * Added property `timezone` (string)
            > Timezone of the subscriber


        * Changed property `_id` (string)
            > The internal ID generated by Novu for your subscriber. This ID does not match the `subscriberId` used in your queries. Refer to `subscriberId` for that identifier.


        * Changed property `firstName` (string)
            > The first name of the subscriber.


        * Changed property `lastName` (string)
            > The last name of the subscriber.


        * Changed property `email` (string)
            > The email address of the subscriber.


        * Changed property `phone` (string)
            > The phone number of the subscriber.


        * Changed property `avatar` (string)
            > The URL of the subscriber's avatar image.


        * Changed property `locale` (string)
            > The locale setting of the subscriber, indicating their preferred language or region.


        * Changed property `subscriberId` (string)
            > The identifier used to create this subscriber, which typically corresponds to the user ID in your system.


        * Changed property `isOnline` (boolean)
            > Indicates whether the subscriber is currently online.


        * Changed property `lastOnlineAt` (string)
            > The timestamp indicating when the subscriber was last online, in ISO 8601 format.


        * Changed property `_organizationId` (string)
            > The unique identifier of the organization to which the subscriber belongs.


        * Changed property `_environmentId` (string)
            > The unique identifier of the environment associated with this subscriber.


        * Changed property `deleted` (boolean)
            > Indicates whether the subscriber has been deleted.


        * Changed property `createdAt` (string)
            > The timestamp indicating when the subscriber was created, in ISO 8601 format.


        * Changed property `updatedAt` (string)
            > The timestamp indicating when the subscriber was last updated, in ISO 8601 format.


        * Changed property `__v` (number)
            > The version of the subscriber document.


        * Changed property `channels` (array)
            > An array of channel settings associated with the subscriber.


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum value:

                * `whatsapp-business`
            * Changed property `credentials` (object)
                > Credentials payload for the specified provider


                New optional properties:
                - `webhookUrl`

                * Changed property `webhookUrl` (string)
                    > Webhook URL used by chat app integrations. The webhook should be obtained from the chat app provider.


                * Changed property `channel` (string)
                    > Channel specification for Mattermost chat notifications.


                * Changed property `deviceTokens` (array)
                    > Contains an array of the subscriber device tokens for a given provider. Used on Push integrations.


                * Changed property `alertUid` (string)
                    > Alert UID for Grafana on-call webhook payload.


                * Changed property `title` (string)
                    > Title to be used with Grafana on-call webhook.


                * Changed property `imageUrl` (string)
                    > Image URL property for Grafana on-call webhook.


                * Changed property `state` (string)
                    > State property for Grafana on-call webhook.


                * Changed property `externalUrl` (string)
                    > Link to upstream details property for Grafana on-call webhook.


            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `POST` /v1/subscribers/{subscriberId}/messages/{messageId}/actions/{type}


###### Parameters:

Changed: `type` in `path`

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **201 Created**
> Created


* Changed content type : `application/json`

    * Changed property `data` (object)

        New required properties:
        - `createdAt`
        - `read`

        New optional properties:
        - `errorId`
        - `errorText`
        - `lastSeenDate`
        - `overrides`
        - `payload`

        * Added property `lastReadDate` (string)
            > Last read date of the message, if available


        * Added property `read` (boolean)
            > Indicates if the message has been read


        * Changed property `_id` (string)
            > Unique identifier for the message


        * Changed property `_templateId` (string)
            > Template ID associated with the message


        * Changed property `_environmentId` (string)
            > Environment ID where the message is sent


        * Changed property `_messageTemplateId` (string)
            > Message template ID


        * Changed property `_organizationId` (string)
            > Organization ID associated with the message


        * Changed property `_notificationId` (string)
            > Notification ID associated with the message


        * Changed property `_subscriberId` (string)
            > Subscriber ID associated with the message


        * Changed property `subscriber` (object -> object)
            > Subscriber details, if available


        * Changed property `template` (object -> object)
            > Workflow template associated with the message


        * Changed property `templateIdentifier` (string)
            > Identifier for the message template


        * Changed property `createdAt` (string)
            > Creation date of the message


        * Changed property `transactionId` (string)
            > Transaction ID associated with the message


        * Changed property `subject` (string)
            > Subject of the message, if applicable


        * Changed property `channel` (string)
            > Channel type through which the message is sent


        * Changed property `seen` (boolean)
            > Indicates if the message has been seen


        * Changed property `email` (string)
            > Email address associated with the message, if applicable


        * Changed property `phone` (string)
            > Phone number associated with the message, if applicable


        * Changed property `directWebhookUrl` (string)
            > Direct webhook URL for the message, if applicable


        * Changed property `providerId` (string)
            > Provider ID associated with the message, if applicable


        * Changed property `deviceTokens` (array)
            > Device tokens associated with the message, if applicable


        * Changed property `title` (string)
            > Title of the message, if applicable


        * Changed property `lastSeenDate` (string)
            > Last seen date of the message, if available


        * Changed property `cta` (object -> object)
            > Call to action associated with the message


        * Changed property `_feedId` (string)
            > Feed ID associated with the message, if applicable


        * Changed property `status` (string)
            > Status of the message


        * Changed property `errorId` (string)
            > Error ID if the message has an error


        * Changed property `errorText` (string)
            > Error text if the message has an error


        * Changed property `content` (object)
            > Content of the message, can be an email block or a string


            Updated `EmailBlock` :
            * Changed property `type` (string)
                > Type of the email block


            * Changed property `content` (string)
                > Content of the email block


            * Changed property `url` (string)
                > URL associated with the email block, if any


            * Changed property `styles` (object -> object)
                > Styles applied to the email block


##### `POST` /v1/topics


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **201 Created**
> Created


* Changed content type : `application/json`

    * Changed property `data` (object)

        New required properties:
        - `key`

        * Added property `_id` (string)
            > The unique identifier for the Topic created.


        * Added property `key` (string)
            > User defined custom key and provided by the user that will be an unique identifier for the Topic created.


##### `GET` /v1/topics

> Get topic list filtered


###### Parameters:

Changed: `page` in `query`
> The page number to retrieve (starts from 0)


Changed: `pageSize` in `query`
> The number of items to return per page (default: 10)


Changed: `key` in `query`
> A filter key to apply to the results


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `page` (number)
        > The current page number


    * Changed property `pageSize` (number)
        > The number of items per page


    * Changed property `totalCount` (number)
        > The total number of items


    * Changed property `data` (array)
        > The list of topics


##### `GET` /v1/integrations


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> The list of integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

    Changed items (object):

    New optional properties:
    - `deletedAt`
    - `deletedBy`

    * Changed property `_id` (string)
        > The unique identifier of the integration record in the database. This is automatically generated.


    * Changed property `_environmentId` (string)
        > The unique identifier for the environment associated with this integration. This links to the Environment collection.


    * Changed property `_organizationId` (string)
        > The unique identifier for the organization that owns this integration. This links to the Organization collection.


    * Changed property `name` (string)
        > The name of the integration, which is used to identify it in the user interface.


    * Changed property `identifier` (string)
        > A unique string identifier for the integration, often used for API calls or internal references.


    * Changed property `providerId` (string)
        > The identifier for the provider of the integration (e.g., "mailgun", "twilio").


    * Changed property `channel` (string)
        > The channel type for the integration, which defines how the integration communicates (e.g., email, SMS).


    * Changed property `credentials` (object -> object)
        > The credentials required for the integration to function, including API keys and other sensitive information.


    * Changed property `active` (boolean)
        > Indicates whether the integration is currently active. An active integration will process events and messages.


    * Changed property `deleted` (boolean)
        > Indicates whether the integration has been marked as deleted (soft delete).


    * Changed property `deletedAt` (string)
        > The timestamp indicating when the integration was deleted. This is set when the integration is soft deleted.


    * Changed property `deletedBy` (string)
        > The identifier of the user who performed the deletion of this integration. Useful for audit trails.


    * Changed property `primary` (boolean)
        > Indicates whether this integration is marked as primary. A primary integration is often the default choice for processing.


    * Changed property `conditions` (array)
        > An array of conditions associated with the integration that may influence its behavior or processing logic.


##### `POST` /v1/integrations


###### Request:

Changed content type : `application/json`

* Changed property `name` (string)
    > The name of the integration


* Changed property `identifier` (string)
    > The unique identifier for the integration


* Changed property `_environmentId` (string -> string)
    > The ID of the associated environment


* Changed property `providerId` (string)
    > The provider ID for the integration


* Changed property `channel` (string)
    > The channel type for the integration


* Changed property `credentials` (object -> object)
    > The credentials for the integration


* Changed property `active` (boolean)
    > If the integration is active, the validation on the credentials field will run


* Changed property `check` (boolean)
    > Flag to check the integration status


* Changed property `conditions` (array)
    > Conditions for the integration


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **201 Created**
> Created


* Changed content type : `application/json`

    * Changed property `data` (object)

        New optional properties:
        - `deletedAt`
        - `deletedBy`

        * Changed property `_id` (string)
            > The unique identifier of the integration record in the database. This is automatically generated.


        * Changed property `_environmentId` (string)
            > The unique identifier for the environment associated with this integration. This links to the Environment collection.


        * Changed property `_organizationId` (string)
            > The unique identifier for the organization that owns this integration. This links to the Organization collection.


        * Changed property `name` (string)
            > The name of the integration, which is used to identify it in the user interface.


        * Changed property `identifier` (string)
            > A unique string identifier for the integration, often used for API calls or internal references.


        * Changed property `providerId` (string)
            > The identifier for the provider of the integration (e.g., "mailgun", "twilio").


        * Changed property `channel` (string)
            > The channel type for the integration, which defines how the integration communicates (e.g., email, SMS).


        * Changed property `credentials` (object -> object)
            > The credentials required for the integration to function, including API keys and other sensitive information.


        * Changed property `active` (boolean)
            > Indicates whether the integration is currently active. An active integration will process events and messages.


        * Changed property `deleted` (boolean)
            > Indicates whether the integration has been marked as deleted (soft delete).


        * Changed property `deletedAt` (string)
            > The timestamp indicating when the integration was deleted. This is set when the integration is soft deleted.


        * Changed property `deletedBy` (string)
            > The identifier of the user who performed the deletion of this integration. Useful for audit trails.


        * Changed property `primary` (boolean)
            > Indicates whether this integration is marked as primary. A primary integration is often the default choice for processing.


        * Changed property `conditions` (array)
            > An array of conditions associated with the integration that may influence its behavior or processing logic.


##### `GET` /v1/integrations/active


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> The list of active integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

    Changed items (object):

    New optional properties:
    - `deletedAt`
    - `deletedBy`

    * Changed property `_id` (string)
        > The unique identifier of the integration record in the database. This is automatically generated.


    * Changed property `_environmentId` (string)
        > The unique identifier for the environment associated with this integration. This links to the Environment collection.


    * Changed property `_organizationId` (string)
        > The unique identifier for the organization that owns this integration. This links to the Organization collection.


    * Changed property `name` (string)
        > The name of the integration, which is used to identify it in the user interface.


    * Changed property `identifier` (string)
        > A unique string identifier for the integration, often used for API calls or internal references.


    * Changed property `providerId` (string)
        > The identifier for the provider of the integration (e.g., "mailgun", "twilio").


    * Changed property `channel` (string)
        > The channel type for the integration, which defines how the integration communicates (e.g., email, SMS).


    * Changed property `credentials` (object -> object)
        > The credentials required for the integration to function, including API keys and other sensitive information.


    * Changed property `active` (boolean)
        > Indicates whether the integration is currently active. An active integration will process events and messages.


    * Changed property `deleted` (boolean)
        > Indicates whether the integration has been marked as deleted (soft delete).


    * Changed property `deletedAt` (string)
        > The timestamp indicating when the integration was deleted. This is set when the integration is soft deleted.


    * Changed property `deletedBy` (string)
        > The identifier of the user who performed the deletion of this integration. Useful for audit trails.


    * Changed property `primary` (boolean)
        > Indicates whether this integration is marked as primary. A primary integration is often the default choice for processing.


    * Changed property `conditions` (array)
        > An array of conditions associated with the integration that may influence its behavior or processing logic.


##### `PUT` /v1/integrations/{integrationId}


###### Request:

Changed content type : `application/json`

* Added property `removeNovuBranding` (boolean)
    > If true, the Novu branding will be removed from the Inbox component


* Changed property `credentials` (object)

    * Added property `channelId` (string)

    * Added property `phoneNumberIdentification` (string)

    * Added property `accessKey` (string)

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (object)

        New optional properties:
        - `deletedAt`
        - `deletedBy`

        * Changed property `_id` (string)
            > The unique identifier of the integration record in the database. This is automatically generated.


        * Changed property `_environmentId` (string)
            > The unique identifier for the environment associated with this integration. This links to the Environment collection.


        * Changed property `_organizationId` (string)
            > The unique identifier for the organization that owns this integration. This links to the Organization collection.


        * Changed property `name` (string)
            > The name of the integration, which is used to identify it in the user interface.


        * Changed property `identifier` (string)
            > A unique string identifier for the integration, often used for API calls or internal references.


        * Changed property `providerId` (string)
            > The identifier for the provider of the integration (e.g., "mailgun", "twilio").


        * Changed property `channel` (string)
            > The channel type for the integration, which defines how the integration communicates (e.g., email, SMS).


        * Changed property `credentials` (object -> object)
            > The credentials required for the integration to function, including API keys and other sensitive information.


        * Changed property `active` (boolean)
            > Indicates whether the integration is currently active. An active integration will process events and messages.


        * Changed property `deleted` (boolean)
            > Indicates whether the integration has been marked as deleted (soft delete).


        * Changed property `deletedAt` (string)
            > The timestamp indicating when the integration was deleted. This is set when the integration is soft deleted.


        * Changed property `deletedBy` (string)
            > The identifier of the user who performed the deletion of this integration. Useful for audit trails.


        * Changed property `primary` (boolean)
            > Indicates whether this integration is marked as primary. A primary integration is often the default choice for processing.


        * Changed property `conditions` (array)
            > An array of conditions associated with the integration that may influence its behavior or processing logic.


##### `DELETE` /v1/integrations/{integrationId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        New optional properties:
        - `deletedAt`
        - `deletedBy`

        * Changed property `_id` (string)
            > The unique identifier of the integration record in the database. This is automatically generated.


        * Changed property `_environmentId` (string)
            > The unique identifier for the environment associated with this integration. This links to the Environment collection.


        * Changed property `_organizationId` (string)
            > The unique identifier for the organization that owns this integration. This links to the Organization collection.


        * Changed property `name` (string)
            > The name of the integration, which is used to identify it in the user interface.


        * Changed property `identifier` (string)
            > A unique string identifier for the integration, often used for API calls or internal references.


        * Changed property `providerId` (string)
            > The identifier for the provider of the integration (e.g., "mailgun", "twilio").


        * Changed property `channel` (string)
            > The channel type for the integration, which defines how the integration communicates (e.g., email, SMS).


        * Changed property `credentials` (object -> object)
            > The credentials required for the integration to function, including API keys and other sensitive information.


        * Changed property `active` (boolean)
            > Indicates whether the integration is currently active. An active integration will process events and messages.


        * Changed property `deleted` (boolean)
            > Indicates whether the integration has been marked as deleted (soft delete).


        * Changed property `deletedAt` (string)
            > The timestamp indicating when the integration was deleted. This is set when the integration is soft deleted.


        * Changed property `deletedBy` (string)
            > The identifier of the user who performed the deletion of this integration. Useful for audit trails.


        * Changed property `primary` (boolean)
            > Indicates whether this integration is marked as primary. A primary integration is often the default choice for processing.


        * Changed property `conditions` (array)
            > An array of conditions associated with the integration that may influence its behavior or processing logic.


##### `POST` /v1/integrations/{integrationId}/set-primary


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Deleted response : **201 Created**
Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (object)

        New optional properties:
        - `deletedAt`
        - `deletedBy`

        * Changed property `_id` (string)
            > The unique identifier of the integration record in the database. This is automatically generated.


        * Changed property `_environmentId` (string)
            > The unique identifier for the environment associated with this integration. This links to the Environment collection.


        * Changed property `_organizationId` (string)
            > The unique identifier for the organization that owns this integration. This links to the Organization collection.


        * Changed property `name` (string)
            > The name of the integration, which is used to identify it in the user interface.


        * Changed property `identifier` (string)
            > A unique string identifier for the integration, often used for API calls or internal references.


        * Changed property `providerId` (string)
            > The identifier for the provider of the integration (e.g., "mailgun", "twilio").


        * Changed property `channel` (string)
            > The channel type for the integration, which defines how the integration communicates (e.g., email, SMS).


        * Changed property `credentials` (object -> object)
            > The credentials required for the integration to function, including API keys and other sensitive information.


        * Changed property `active` (boolean)
            > Indicates whether the integration is currently active. An active integration will process events and messages.


        * Changed property `deleted` (boolean)
            > Indicates whether the integration has been marked as deleted (soft delete).


        * Changed property `deletedAt` (string)
            > The timestamp indicating when the integration was deleted. This is set when the integration is soft deleted.


        * Changed property `deletedBy` (string)
            > The identifier of the user who performed the deletion of this integration. Useful for audit trails.


        * Changed property `primary` (boolean)
            > Indicates whether this integration is marked as primary. A primary integration is often the default choice for processing.


        * Changed property `conditions` (array)
            > An array of conditions associated with the integration that may influence its behavior or processing logic.


##### `POST` /v1/events/trigger/bulk


###### Request:

Changed content type : `application/json`

* Changed property `events` (array)

    Changed items (object):

    * Changed property `payload` (object)
        > The payload object is used to pass additional custom information that could be 
        >     used to render the workflow, or perform routing rules based on it. 
        >       This data will also be available when fetching the notifications feed from the API to display certain parts of the UI.


    * Changed property `overrides` (object)
        > This could be used to override provider specific configurations


    * Changed property `to` (array -> object)
        > The recipients list of people who will receive the notification.


    * Changed property `transactionId` (string)
        > A unique identifier for this transaction, we will generate a UUID if not provided.


    * Changed property `actor` (object)
        > It is used to display the Avatar of the provided actor's subscriber id or actor object.
        >     If a new actor object is provided, we will create a new subscriber in our system


        Updated `SubscriberPayloadDto` :
        * Added property `channels` (array)
            > An optional array of subscriber channels.


        * Added property `timezone` (string)
            > The timezone of the subscriber.


        * Changed property `email` (string)
            > The email address of the subscriber.


        * Changed property `firstName` (string)
            > The first name of the subscriber.


        * Changed property `lastName` (string)
            > The last name of the subscriber.


        * Changed property `phone` (string)
            > The phone number of the subscriber.


        * Changed property `avatar` (string)
            > An HTTP URL to the profile image of your subscriber.


        * Changed property `locale` (string)
            > The locale of the subscriber.


        * Changed property `data` (object)
            > An optional payload object that can contain any properties.


    * Changed property `tenant` (object)
        > It is used to specify a tenant context during trigger event.
        >     Existing tenants will be updated with the provided details.


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **201 Created**
> Created


* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `acknowledged` (boolean)
            > Indicates whether the trigger was acknowledged or not


        * Changed property `status` (string)
            > Status of the trigger


            Added enum value:

            * `invalid_recipients`
            Removed enum value:

            * `subscriber_id_missing`
        * Changed property `error` (array)
            > In case of an error, this field will contain the error message(s)


        * Changed property `transactionId` (string)
            > The returned transaction ID of the trigger


##### `GET` /v1/notifications/{notificationId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (object)

        New required properties:
        - `_subscriberId`

        * Added property `_subscriberId` (string)
            > Subscriber ID of the notification


        * Added property `_templateId` (string)
            > Template ID of the notification


        * Added property `_digestedNotificationId` (string)
            > Digested Notification ID


        * Added property `updatedAt` (string)
            > Last updated time of the notification


        * Added property `payload` (object)
            > Payload of the notification


        * Added property `tags` (array)
            > Tags associated with the notification


            Items (string):

        * Added property `controls` (object)
            > Controls associated with the notification


        * Added property `to` (object)
            > To field for subscriber definition


        * Changed property `_id` (string)
            > Unique identifier of the notification


        * Changed property `_environmentId` (string)
            > Environment ID of the notification


        * Changed property `_organizationId` (string)
            > Organization ID of the notification


        * Changed property `transactionId` (string)
            > Transaction ID of the notification


        * Changed property `createdAt` (string)
            > Creation time of the notification


        * Changed property `channels` (array)

            Changed items (string):
                > Channels of the notification


            Added enum value:

            * `custom`
            Removed enum values:

            * `in_app`
            * `email`
            * `sms`
            * `chat`
            * `push`
            * `digest`
            * `trigger`
            * `delay`
        * Changed property `subscriber` (object -> object)
            > Subscriber of the notification


        * Changed property `template` (object -> object)
            > Template of the notification


        * Changed property `jobs` (array)
            > Jobs of the notification


            Changed items (object):

            * Added property `overrides` (object)
                > Optional context object for additional error details.


            * Added property `updatedAt` (string)
                > Updated time of the notification


            * Changed property `_id` (string)
                > Unique identifier of the job


            * Changed property `type` (string)
                > Type of the job


                Added enum values:

                * `in_app`
                * `email`
                * `sms`
                * `chat`
                * `push`
                * `digest`
                * `trigger`
                * `delay`
                * `custom`
            * Changed property `digest` (object -> object)
                > Optional digest for the job, including metadata and events


            * Changed property `step` (object -> object)
                > Step details of the job


            * Changed property `payload` (object)
                > Optional payload for the job


            * Changed property `providerId` (object -> string)
                > Provider ID of the job


            * Changed property `status` (string)
                > Status of the job


            * Changed property `executionDetails` (array)
                > Execution details of the job


                Changed items (object):

                New optional properties:
                - `_jobId`

                * Added property `createdAt` (string)
                    > Creation time of the execution detail


                * Deleted property `_jobId` (string)

                * Changed property `_id` (string)
                    > Unique identifier of the execution detail


                * Changed property `status` (string)
                    > Status of the execution detail


                * Changed property `detail` (string)
                    > Detailed information about the execution


                * Changed property `isRetry` (boolean)
                    > Whether the execution is a retry or not


                * Changed property `isTest` (boolean)
                    > Whether the execution is a test or not


                * Changed property `providerId` (object -> string)
                    > Provider ID of the job


                * Changed property `raw` (string)
                    > Raw data of the execution


                * Changed property `source` (string)
                    > Source of the execution detail


##### `GET` /v1/notifications


###### Parameters:

Added: `limit` in `query`
> Limit for pagination


Added: `after` in `query`
> Date filter for records after this timestamp. Defaults to earliest date allowed by subscription plan


Added: `before` in `query`
> Date filter for records before this timestamp. Defaults to current time of request (now)


Changed: `channels` in `query`
> Array of channel types


Changed: `templates` in `query`
> Array of template IDs or a single template ID


Changed: `emails` in `query`
> Array of email addresses or a single email address


Changed: `search` in `query`
> Search term (deprecated)


Changed: `subscriberIds` in `query`
> Array of subscriber IDs or a single subscriber ID


Changed: `page` in `query`
> Page number for pagination


Changed: `transactionId` in `query`
> Transaction ID for filtering


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `hasMore` (boolean)
        > Indicates if there are more activities in the result set


    * Changed property `pageSize` (number)
        > Page size of the activities


    * Changed property `page` (number)
        > Current page of the activities


    * Changed property `data` (array)
        > Array of activity notifications


        Changed items (object):

        New required properties:
        - `_subscriberId`

        * Added property `_subscriberId` (string)
            > Subscriber ID of the notification


        * Added property `_templateId` (string)
            > Template ID of the notification


        * Added property `_digestedNotificationId` (string)
            > Digested Notification ID


        * Added property `updatedAt` (string)
            > Last updated time of the notification


        * Added property `payload` (object)
            > Payload of the notification


        * Added property `tags` (array)
            > Tags associated with the notification


        * Added property `controls` (object)
            > Controls associated with the notification


        * Added property `to` (object)
            > To field for subscriber definition


        * Changed property `_id` (string)
            > Unique identifier of the notification


        * Changed property `_environmentId` (string)
            > Environment ID of the notification


        * Changed property `_organizationId` (string)
            > Organization ID of the notification


        * Changed property `transactionId` (string)
            > Transaction ID of the notification


        * Changed property `createdAt` (string)
            > Creation time of the notification


        * Changed property `channels` (array)

            Changed items (string):
                > Channels of the notification


            Added enum value:

            * `custom`
            Removed enum values:

            * `in_app`
            * `email`
            * `sms`
            * `chat`
            * `push`
            * `digest`
            * `trigger`
            * `delay`
        * Changed property `subscriber` (object -> object)
            > Subscriber of the notification


        * Changed property `template` (object -> object)
            > Template of the notification


        * Changed property `jobs` (array)
            > Jobs of the notification


            Changed items (object):

            * Added property `overrides` (object)
                > Optional context object for additional error details.


            * Added property `updatedAt` (string)
                > Updated time of the notification


            * Changed property `_id` (string)
                > Unique identifier of the job


            * Changed property `type` (string)
                > Type of the job


                Added enum values:

                * `in_app`
                * `email`
                * `sms`
                * `chat`
                * `push`
                * `digest`
                * `trigger`
                * `delay`
                * `custom`
            * Changed property `digest` (object -> object)
                > Optional digest for the job, including metadata and events


            * Changed property `step` (object -> object)
                > Step details of the job


            * Changed property `payload` (object)
                > Optional payload for the job


            * Changed property `providerId` (object -> string)
                > Provider ID of the job


            * Changed property `status` (string)
                > Status of the job


            * Changed property `executionDetails` (array)
                > Execution details of the job


                Changed items (object):

                New optional properties:
                - `_jobId`

                * Added property `createdAt` (string)
                    > Creation time of the execution detail


                * Deleted property `_jobId` (string)

                * Changed property `_id` (string)
                    > Unique identifier of the execution detail


                * Changed property `status` (string)
                    > Status of the execution detail


                * Changed property `detail` (string)
                    > Detailed information about the execution


                * Changed property `isRetry` (boolean)
                    > Whether the execution is a retry or not


                * Changed property `isTest` (boolean)
                    > Whether the execution is a test or not


                * Changed property `providerId` (object -> string)
                    > Provider ID of the job


                * Changed property `raw` (string)
                    > Raw data of the execution


                * Changed property `source` (string)
                    > Source of the execution detail


##### `GET` /v1/messages


###### Parameters:

Changed: `channel` in `query`

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **401 Unauthorized**
> Unauthorized

New response : **403 Forbidden**
> Forbidden

New response : **404 Not Found**
> Not Found

New response : **405 Method Not Allowed**
> Method Not Allowed

New response : **413 Request Too Long**
> Payload Too Large

New response : **414 Request-URI Too Long**
> URI Too Long

New response : **415 Unsupported Media Type**
> Unsupported Media Type

New response : **422 Unprocessable Entity**
> Unprocessable Entity

New response : **500 Internal Server Error**
> Internal Server Error

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `hasMore` (boolean)
        > Indicates if there are more activities in the result set


    * Changed property `pageSize` (number)
        > Page size of the activities


    * Changed property `page` (number)
        > Current page of the activities


    * Changed property `data` (array)
        > Array of activity notifications


        Changed items (object):

        New required properties:
        - `_subscriberId`

        * Added property `_subscriberId` (string)
            > Subscriber ID of the notification


        * Added property `_templateId` (string)
            > Template ID of the notification


        * Added property `_digestedNotificationId` (string)
            > Digested Notification ID


        * Added property `updatedAt` (string)
            > Last updated time of the notification


        * Added property `payload` (object)
            > Payload of the notification


        * Added property `tags` (array)
            > Tags associated with the notification


        * Added property `controls` (object)
            > Controls associated with the notification


        * Added property `to` (object)
            > To field for subscriber definition


        * Changed property `_id` (string)
            > Unique identifier of the notification


        * Changed property `_environmentId` (string)
            > Environment ID of the notification


        * Changed property `_organizationId` (string)
            > Organization ID of the notification


        * Changed property `transactionId` (string)
            > Transaction ID of the notification


        * Changed property `createdAt` (string)
            > Creation time of the notification


        * Changed property `channels` (array)

            Changed items (string):
                > Channels of the notification


            Added enum value:

            * `custom`
            Removed enum values:

            * `in_app`
            * `email`
            * `sms`
            * `chat`
            * `push`
            * `digest`
            * `trigger`
            * `delay`
        * Changed property `subscriber` (object -> object)
            > Subscriber of the notification


        * Changed property `template` (object -> object)
            > Template of the notification


        * Changed property `jobs` (array)
            > Jobs of the notification


            Changed items (object):

            * Added property `overrides` (object)
                > Optional context object for additional error details.


            * Added property `updatedAt` (string)
                > Updated time of the notification


            * Changed property `_id` (string)
                > Unique identifier of the job


            * Changed property `type` (string)
                > Type of the job


                Added enum values:

                * `in_app`
                * `email`
                * `sms`
                * `chat`
                * `push`
                * `digest`
                * `trigger`
                * `delay`
                * `custom`
            * Changed property `digest` (object -> object)
                > Optional digest for the job, including metadata and events


            * Changed property `step` (object -> object)
                > Step details of the job


            * Changed property `payload` (object)
                > Optional payload for the job


            * Changed property `providerId` (object -> string)
                > Provider ID of the job


            * Changed property `status` (string)
                > Status of the job


            * Changed property `executionDetails` (array)
                > Execution details of the job


                Changed items (object):

                New optional properties:
                - `_jobId`

                * Added property `createdAt` (string)
                    > Creation time of the execution detail


                * Deleted property `_jobId` (string)

                * Changed property `_id` (string)
                    > Unique identifier of the execution detail


                * Changed property `status` (string)
                    > Status of the execution detail


                * Changed property `detail` (string)
                    > Detailed information about the execution


                * Changed property `isRetry` (boolean)
                    > Whether the execution is a retry or not


                * Changed property `isTest` (boolean)
                    > Whether the execution is a test or not


                * Changed property `providerId` (object -> string)
                    > Provider ID of the job


                * Changed property `raw` (string)
                    > Raw data of the execution


                * Changed property `source` (string)
                    > Source of the execution detail


