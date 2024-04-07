#### What's New
---

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


##### `PATCH` /v1/subscribers/{subscriberId}/preferences

> Update subscriber global preferences


#### What's Changed
---

##### `GET` /v1/integrations


###### Return Type:

Changed response : **200 OK**
> The list of integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

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
##### `POST` /v1/integrations


###### Request:

Changed content type : `application/json`

* Added property `conditions` (array)

###### Return Type:

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `conditions` (array)

##### `GET` /v1/integrations/active


###### Return Type:

Changed response : **200 OK**
> The list of active integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

    * Added property `conditions` (array)

##### `PUT` /v1/integrations/{integrationId}


###### Request:

Changed content type : `application/json`

* Added property `conditions` (array)

###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `conditions` (array)

##### `DELETE` /v1/integrations/{integrationId}


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Added property `conditions` (array)

##### `POST` /v1/integrations/{integrationId}/set-primary


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Added property `conditions` (array)

Changed response : **201 Created**

* Changed content type : `application/json`

    * Added property `conditions` (array)

##### `POST` /v1/events/trigger


###### Return Type:

Changed response : **201 Created**

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

Changed response : **200 OK**

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
##### `POST` /v1/events/trigger/bulk


###### Return Type:

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `status` (string)
            > Status for trigger


            Added enum values:

            * `no_workflow_active_steps_defined`
            * `no_workflow_steps_defined`
            * `no_tenant_found`
