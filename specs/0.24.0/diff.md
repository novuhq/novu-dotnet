#### What's New
---

##### `GET` /v1/notification-templates/{workflowIdOrIdentifier}

> Get Notification template


##### `GET` /v1/workflows/{workflowIdOrIdentifier}

> Get workflow


##### `PATCH` /v1/subscribers/{subscriberId}/credentials

> Modify subscriber credentials


#### What's Deleted
---

##### `GET` /v1/notification-templates/{templateId}

> Get Notification template


##### `GET` /v1/workflows/{workflowId}

> Get workflow


#### What's Changed
---

##### `GET` /v1/integrations


###### Return Type:

Changed response : **200 OK**
> The list of integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

    Changed items (object):

    * Changed property `credentials` (object)

        * Added property `apiToken` (string)

##### `POST` /v1/integrations


###### Request:

Changed content type : `application/json`

* Changed property `credentials` (object)

    * Added property `apiToken` (string)

###### Return Type:

Changed response : **201 Created**
> Created


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `credentials` (object)

            * Added property `apiToken` (string)

##### `GET` /v1/integrations/active


###### Return Type:

Changed response : **200 OK**
> The list of active integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

    Changed items (object):

    * Changed property `credentials` (object)

        * Added property `apiToken` (string)

##### `PUT` /v1/integrations/{integrationId}


###### Request:

Changed content type : `application/json`

* Changed property `credentials` (object)

    * Added property `apiToken` (string)

###### Return Type:

Changed response : **200 OK**
> Ok


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `credentials` (object)

            * Added property `apiToken` (string)

##### `DELETE` /v1/integrations/{integrationId}


###### Return Type:

Changed response : **200 OK**
> Ok


* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `credentials` (object)

            * Added property `apiToken` (string)

##### `POST` /v1/integrations/{integrationId}/set-primary


###### Return Type:

Changed response : **200 OK**
> Ok


* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `credentials` (object)

            * Added property `apiToken` (string)

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `credentials` (object)

        * Added property `apiToken` (string)

##### `GET` /v1/workflows


###### Return Type:

Changed response : **200 OK**
> Ok


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

