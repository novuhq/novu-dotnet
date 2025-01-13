#### What's New
---

##### `POST` /v1/subscribers/bulk

> Bulk create subscribers


#### What's Changed
---

##### `GET` /v1/layouts/{layoutId}


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        New required properties:
        - `identifier`

        * Added property `identifier` (string)

##### `PATCH` /v1/layouts/{layoutId}


###### Request:

Changed content type : `application/json`

New required properties:
- `identifier`

* Added property `identifier` (string)
    > User defined custom key that will be a unique identifier for the Layout updated.


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        New required properties:
        - `identifier`

        * Added property `identifier` (string)

##### `POST` /v1/layouts


###### Request:

Changed content type : `application/json`

New required properties:
- `identifier`

* Added property `identifier` (string)
    > User defined custom key that will be a unique identifier for the Layout created.


##### `GET` /v1/layouts


###### Return Type:

Changed response : **200 OK**
> The list of layouts that match the criteria of the query params are successfully returned.


* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        New required properties:
        - `identifier`

        * Added property `identifier` (string)

##### `GET` /v1/integrations


###### Return Type:

Changed response : **200 OK**
> The list of integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

    New required properties:
    - `primary`

    * Added property `primary` (boolean)

##### `POST` /v1/integrations


###### Return Type:

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (object)

        New required properties:
        - `primary`

        * Added property `primary` (boolean)

##### `GET` /v1/integrations/active


###### Return Type:

Changed response : **200 OK**
> The list of active integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

    New required properties:
    - `primary`

    * Added property `primary` (boolean)

##### `PUT` /v1/integrations/{integrationId}


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        New required properties:
        - `primary`

        * Added property `primary` (boolean)

##### `DELETE` /v1/integrations/{integrationId}


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        New required properties:
        - `primary`

        * Added property `primary` (boolean)

##### `POST` /v1/integrations/{integrationId}/set-primary


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        New required properties:
        - `primary`

        * Added property `primary` (boolean)

Changed response : **201 Created**

* Changed content type : `application/json`

    New required properties:
    - `primary`

    * Added property `primary` (boolean)

##### `POST` /v1/events/trigger


###### Request:

Changed content type : `application/json`

* Added property `tenant` (object)
    > It is used to specify a tenant context during trigger event.
    >     If a new tenant object is provided, we will create a new tenant.


    One of:

        * Property `identifier` (string)

        * Property `name` (string)

        * Property `data` (object)

* Changed property `to` (array)
    > The recipients list of people who will receive the notification.


    Changed items (array):

##### `POST` /v1/events/trigger/broadcast


###### Request:

Changed content type : `application/json`

* Added property `tenant` (object)
    > It is used to specify a tenant context during trigger event.
    >     If a new tenant object is provided, we will create a new tenant.


##### `POST` /v1/events/trigger/bulk


###### Request:

Changed content type : `application/json`

* Changed property `events` (array)

    Changed items (object):

    * Added property `tenant` (object)
        > It is used to specify a tenant context during trigger event.
        >     If a new tenant object is provided, we will create a new tenant.


    * Changed property `to` (array)
        > The recipients list of people who will receive the notification.


        Changed items (array):

##### `GET` /v1/notification-templates


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `POST` /v1/notification-templates


###### Request:

Changed content type : `application/json`

* Changed property `description` (string)

###### Return Type:

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `GET` /v1/notification-templates/{templateId}


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `PUT` /v1/notification-templates/{templateId}


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `PUT` /v1/notification-templates/{templateId}/status


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `GET` /v1/workflows


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `POST` /v1/workflows


###### Request:

Changed content type : `application/json`

* Changed property `description` (string)

###### Return Type:

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `GET` /v1/workflows/{workflowId}


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `PUT` /v1/workflows/{workflowId}


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `PUT` /v1/workflows/{workflowId}/status


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `workflowIntegrationStatus` (object)

##### `GET` /v1/subscribers/{subscriberId}/notifications/feed


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `template` (object)

            * Added property `workflowIntegrationStatus` (object)

##### `POST` /v1/subscribers/{subscriberId}/messages/markAs


###### Return Type:

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `template` (object)

            * Added property `workflowIntegrationStatus` (object)

##### `POST` /v1/subscribers/{subscriberId}/messages/{messageId}/actions/{type}


###### Return Type:

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `template` (object)

            * Added property `workflowIntegrationStatus` (object)

