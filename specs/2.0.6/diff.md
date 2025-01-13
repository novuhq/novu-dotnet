#### What's New
---

##### `POST` /v1/subscribers/{subscriberId}/messages/mark-as

> Mark a subscriber messages as seen, read, unseen or unread


##### `POST` /v1/support/user-organizations


##### `POST` /v1/support/create-thread


##### `PATCH` /v1/subscribers/{subscriberId}/preferences/{parameter}

> Update subscriber preference


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


##### `PATCH` /v1/subscribers/{subscriberId}/preferences/{templateId}

> Update subscriber preference


##### `POST` /v1/subscribers/{subscriberId}/messages/markAs

> Mark a subscriber feed message as seen


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


#### What's Changed
---

##### `GET` /v1/integrations/webhook/provider/{providerOrIntegrationId}/status


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `DELETE` /v1/subscribers/{subscriberId}/credentials/{providerId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `GET` /v1/subscribers/{subscriberId}/notifications/feed


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `GET` /v1/subscribers/{subscriberId}/credentials/{providerId}/oauth


###### Parameters:

Changed: `providerId` in `path`

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `DELETE` /v1/messages/transaction/{transactionId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `DELETE` /v1/events/trigger/{transactionId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `POST` /v1/subscribers/bulk


###### Request:

Changed content type : `application/json`

* Changed property `subscribers` (array)
    > An array of subscribers to be created in bulk.


    Changed items (object -> string):

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `GET` /v1/subscribers/{subscriberId}/preferences/{level}


###### Parameters:

Added: `includeInactiveChannels` in `query`
> A flag which specifies if the inactive workflow channels should be included in the retrieved preferences. Default is true


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `GET` /v1/subscribers/{subscriberId}/notifications/unseen


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **404 Not Found**
> Not Found


* New content type : `application/json`

##### `GET` /v1/topics/{topicKey}


###### Parameters:

Changed: `topicKey` in `path`
> The topic key


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

* Added property `bridgeUrl` (string)
    > A URL to bridge for additional processing.


* Added property `controls` (object)
    > Additional control configurations.


    * Property `steps` (object)
        > A mapping of step IDs to their corresponding data.


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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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
            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `POST` /v1/subscribers


###### Request:

Changed content type : `application/json`

* Added property `channels` (array)
    > An optional array of subscriber channels.


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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **201 Created**
> Created


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `topics` (array)
            > An array of topics that the subscriber is subscribed to.


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
            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `DELETE` /v1/subscribers/{subscriberId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `GET` /v1/subscribers/{subscriberId}


###### Parameters:

Added: `includeTopics` in `query`
> Includes the topics associated with the subscriber


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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
            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `PUT` /v1/subscribers/{subscriberId}


###### Request:

Changed content type : `application/json`

* Added property `channels` (array)

    Items (string):

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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
            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `PUT` /v1/subscribers/{subscriberId}/credentials


###### Request:

Changed content type : `application/json`

* Changed property `providerId` (string)
    > The provider identifier for the credentials


    Added enum value:

    * `whatsapp-business`
###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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
            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `PATCH` /v1/subscribers/{subscriberId}/credentials


###### Request:

Changed content type : `application/json`

* Changed property `providerId` (string)
    > The provider identifier for the credentials


    Added enum value:

    * `whatsapp-business`
###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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
            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `PATCH` /v1/subscribers/{subscriberId}/online-status


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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
            * Changed property `_integrationId` (string)
                > The unique identifier of the integration associated with this channel.


##### `GET` /v1/subscribers/{subscriberId}/preferences


###### Parameters:

Added: `includeInactiveChannels` in `query`
> A flag which specifies if the inactive workflow channels should be included in the retrieved preferences. Default is true


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `PATCH` /v1/subscribers/{subscriberId}/preferences


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK

##### `POST` /v1/topics


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

##### `GET` /v1/notifications/{notificationId}


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**
> OK


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)

            Changed items (string):

            Added enum value:

            * `custom`
            Added enum value:

            * `custom`
        * Changed property `jobs` (array)

            Changed items (object -> string):

        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object -> string):

##### `GET` /v1/integrations


###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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

    * Added property `bridgeUrl` (string)
        > A URL to bridge for additional processing.


    * Added property `controls` (object)
        > Additional control configurations.


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

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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


            Removed enum value:

            * `subscriber_id_missing`
        * Changed property `error` (array)
            > In case of an error, this field will contain the error message(s)


        * Changed property `transactionId` (string)
            > The returned transaction ID of the trigger


##### `GET` /v1/notifications


###### Parameters:

Added: `after` in `query`

Added: `before` in `query`

Changed: `channels` in `query`

Changed: `templates` in `query`

Changed: `emails` in `query`

Changed: `search` in `query`

Changed: `subscriberIds` in `query`

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)
        > Array of Activity notifications


        Changed items (object):

        * Changed property `channels` (array)

            Changed items (string):

            Added enum value:

            * `custom`
            Added enum value:

            * `custom`
        * Changed property `jobs` (array)

            Changed items (object -> string):

        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object -> string):

##### `GET` /v1/messages


###### Parameters:

Changed: `channel` in `query`

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

Changed response : **409 Conflict**
> Conflict

Deleted header : `Retry-After`


Deleted header : `Link`



* Changed content type : `application/json`

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)
        > Array of Activity notifications


        Changed items (object):

        * Changed property `channels` (array)

            Changed items (string):

            Added enum value:

            * `custom`
            Added enum value:

            * `custom`
        * Changed property `jobs` (array)

            Changed items (object -> string):

        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object -> string):

##### `POST` /v1/subscribers/{subscriberId}/messages/{messageId}/actions/{type}


###### Parameters:

Changed: `type` in `path`

###### Return Type:

New response : **400 Bad Request**
> Bad Request

New response : **404 Not Found**
> Not Found

New response : **422 Unprocessable Entity**
> Unprocessable Entity

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
        - `lastSeenDate`

        * Added property `lastReadDate` (string)

        * Added property `read` (boolean)

        * Changed property `_feedId` (string -> object)

        * Changed property `subscriber` (object)

            * Added property `topics` (array)
                > An array of topics that the subscriber is subscribed to.


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
                * Changed property `_integrationId` (string)
                    > The unique identifier of the integration associated with this channel.


        * Changed property `content` (object)

            Updated `EmailBlock` :
            * Changed property `styles` (object)

                New required properties:
                - `textAlign`

        * Changed property `cta` (object)

            * Changed property `action` (object)

                * Changed property `buttons` (array)

                    Changed items (object):

                    * Changed property `type` (string)

                        Removed enum value:

                        * `clicked`
                * Changed property `result` (object)

                    * Changed property `type` (string)

                        Removed enum value:

                        * `clicked`
