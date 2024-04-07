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


##### `PUT` /v1/organizations/members/{memberId}/roles

> Update a member role to admin


##### `GET` /v1/organizations/members

> Fetch all members of current organizations


##### `PUT` /v1/organizations/branding

> Update organization branding details


#### What's Deleted
---

##### `PUT` /v1/environments/{environmentId}

> Update env by id


#### What's Changed
---

##### `GET` /v1/subscribers/{subscriberId}/preferences/{level}


###### Return Type:

Changed response : **200 OK**

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

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `template` (object)
            > The workflow information and if it is critical or not


            New required properties:
            - `triggers`

            * Added property `triggers` (array)
                > Triggers are the events that will trigger the workflow.


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

                * `ryver`
                * `pushpad`
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

                * `ryver`
                * `pushpad`
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

                * `ryver`
                * `pushpad`
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

                * `ryver`
                * `pushpad`
##### `PUT` /v1/subscribers/{subscriberId}/credentials


###### Request:

Changed content type : `application/json`

* Changed property `providerId` (string)
    > The provider identifier for the credentials


    Added enum values:

    * `ryver`
    * `pushpad`
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

                * `ryver`
                * `pushpad`
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

                * `ryver`
                * `pushpad`
##### `GET` /v1/subscribers/{subscriberId}/preferences


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (array)

        Changed items (object):

        * Changed property `template` (object)
            > The workflow information and if it is critical or not


            New required properties:
            - `triggers`

            * Added property `triggers` (array)
                > Triggers are the events that will trigger the workflow.


##### `PATCH` /v1/subscribers/{subscriberId}/preferences


###### Return Type:

Changed response : **200 OK**

* Changed content type : `application/json`

    * Changed property `data` (object)

        * Changed property `template` (object)
            > The workflow information and if it is critical or not


            New required properties:
            - `triggers`

            * Added property `triggers` (array)
                > Triggers are the events that will trigger the workflow.


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

                    * `ryver`
                    * `pushpad`
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

                    * `ryver`
                    * `pushpad`
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

                    * `ryver`
                    * `pushpad`
