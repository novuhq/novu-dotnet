#### What's New
---

##### `GET` /v1/workflow-overrides

> Get workflow overrides


##### `POST` /v1/workflow-overrides

> Create workflow override


##### `GET` /v1/workflow-overrides/{overrideId}

> Get workflow override by id


##### `PUT` /v1/workflow-overrides/{overrideId}

> Update workflow override by id


##### `GET` /v1/workflow-overrides/workflows/{workflowId}/tenants/{tenantId}

> Get workflow override


##### `PUT` /v1/workflow-overrides/workflows/{workflowId}/tenants/{tenantId}

> Update workflow override


##### `DELETE` /v1/workflow-overrides/{workflowOverrideId}

> Delete workflow override


#### What's Deleted
---

##### `GET` /v1/integrations/{channelType}/limit


##### `GET` /v1/integrations/in-app/status


##### `POST` /v1/environments

> Create environment


#### What's Changed
---

##### `GET` /v1/integrations/active


###### Return Type:

Changed response : **200 OK**
> The list of active integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

##### `GET` /v1/subscribers


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `zulip`
                * `grafana-on-call`
                * `getstream`
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

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `zulip`
                * `grafana-on-call`
                * `getstream`
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


##### `GET` /v1/subscribers/{subscriberId}


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `zulip`
                * `grafana-on-call`
                * `getstream`
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

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `zulip`
                * `grafana-on-call`
                * `getstream`
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


##### `PUT` /v1/subscribers/{subscriberId}/credentials


###### Request:

Changed content type : `application/json`

* Changed property `providerId` (string)
    > The provider identifier for the credentials


    Added enum values:

    * `zulip`
    * `grafana-on-call`
    * `getstream`
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

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `zulip`
                * `grafana-on-call`
                * `getstream`
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

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `channels` (array)
            > Channels settings for subscriber


            Changed items (object):

            * Changed property `providerId` (string)
                > The provider identifier for the credentials


                Added enum values:

                * `zulip`
                * `grafana-on-call`
                * `getstream`
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


##### `GET` /v1/integrations


###### Return Type:

Changed response : **200 OK**
> The list of integrations belonging to the organization that are successfully returned.


* Changed content type : `application/json`

##### `POST` /v1/integrations


###### Request:

Changed content type : `application/json`

* Changed property `credentials` (object)

    * Added property `apiKeyRequestHeader` (string)

    * Added property `secretKeyRequestHeader` (string)

    * Added property `idPath` (string)

    * Added property `datePath` (string)

    * Added property `authenticateByToken` (boolean)

    * Added property `authenticationTokenKey` (string)

    * Added property `instanceId` (string)

    * Added property `alertUid` (string)

    * Added property `title` (string)

    * Added property `imageUrl` (string)

    * Added property `state` (string)

    * Added property `externalLink` (string)

###### Return Type:

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `credentials` (object)

            * Added property `apiKeyRequestHeader` (string)

            * Added property `secretKeyRequestHeader` (string)

            * Added property `idPath` (string)

            * Added property `datePath` (string)

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

* Changed property `credentials` (object)

    * Added property `apiKeyRequestHeader` (string)

    * Added property `secretKeyRequestHeader` (string)

    * Added property `idPath` (string)

    * Added property `datePath` (string)

    * Added property `authenticateByToken` (boolean)

    * Added property `authenticationTokenKey` (string)

    * Added property `instanceId` (string)

    * Added property `alertUid` (string)

    * Added property `title` (string)

    * Added property `imageUrl` (string)

    * Added property `state` (string)

    * Added property `externalLink` (string)

###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `credentials` (object)

            * Added property `apiKeyRequestHeader` (string)

            * Added property `secretKeyRequestHeader` (string)

            * Added property `idPath` (string)

            * Added property `datePath` (string)

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

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `credentials` (object)

            * Added property `apiKeyRequestHeader` (string)

            * Added property `secretKeyRequestHeader` (string)

            * Added property `idPath` (string)

            * Added property `datePath` (string)

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

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `credentials` (object)

            * Added property `apiKeyRequestHeader` (string)

            * Added property `secretKeyRequestHeader` (string)

            * Added property `idPath` (string)

            * Added property `datePath` (string)

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

    * Changed property `credentials` (object)

        * Added property `apiKeyRequestHeader` (string)

        * Added property `secretKeyRequestHeader` (string)

        * Added property `idPath` (string)

        * Added property `datePath` (string)

        * Added property `authenticateByToken` (boolean)

        * Added property `authenticationTokenKey` (string)

        * Added property `instanceId` (string)

        * Added property `alertUid` (string)

        * Added property `title` (string)

        * Added property `imageUrl` (string)

        * Added property `state` (string)

        * Added property `externalLink` (string)

##### `GET` /v1/notification-templates


###### Return Type:

Changed response : **200 OK**

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

Changed response : **201 Created**

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

##### `GET` /v1/notification-templates/{templateId}


###### Return Type:

Changed response : **200 OK**

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

##### `PUT` /v1/notification-templates/{templateId}


###### Request:

Changed content type : `application/json`

* Changed property `steps` (array)

    Changed items (object):

    * Added property `variants` (object)

###### Return Type:

Changed response : **200 OK**

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

Changed response : **200 OK**

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

Changed response : **200 OK**

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

##### `POST` /v1/workflows


###### Request:

Changed content type : `application/json`

* Changed property `steps` (array)

    Changed items (object):

    * Added property `variants` (object)

###### Return Type:

Changed response : **201 Created**

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

##### `GET` /v1/workflows/{workflowId}


###### Return Type:

Changed response : **200 OK**

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

##### `PUT` /v1/workflows/{workflowId}


###### Request:

Changed content type : `application/json`

* Changed property `steps` (array)

    Changed items (object):

    * Added property `variants` (object)

###### Return Type:

Changed response : **200 OK**

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

Changed response : **200 OK**

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

Changed response : **200 OK**

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

                    * `zulip`
                    * `grafana-on-call`
                    * `getstream`
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

Changed response : **201 Created**

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

                    * `zulip`
                    * `grafana-on-call`
                    * `getstream`
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

Changed response : **201 Created**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `subscriber` (object)

            * Changed property `channels` (array)
                > Channels settings for subscriber


                Changed items (object):

                * Changed property `providerId` (string)
                    > The provider identifier for the credentials


                    Added enum values:

                    * `zulip`
                    * `grafana-on-call`
                    * `getstream`
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

Changed response : **200 OK**

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

Changed response : **200 OK**

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

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `template` (object)

            * Changed property `triggers` (array)

                Changed items (object):

                * Changed property `type` (string)

                    Added enum value:

                    * `event`
