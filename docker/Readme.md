Docker is used to self-host Novu for testing.

### Before you begin

You need the following installed in your system:

- [Docker](https://docs.docker.com/engine/install/) and [docker-compose](https://docs.docker.com/compose/install/)

### Start Novu

```sh
# Start Novu
docker-compose -f ./docker/docker-compose.yml up
```

### Change settings

The current docker compose file has default settings to work immediately in testing. However, any
can be changed by creating your own `.env` file:

```sh
# Go to the docker folder
cd docker

# Copy the example env file (and make changes, but should work on defaults)
# the version of the Novu docker images are set in the .env file
cp .env.example .env

# Start Novu
docker-compose -f ./docker-compose.yml up
```

### Testing

* The `appsettings.Integration.json` file is pointing at http:localhost:3000
* [http://127.0.0.1:4200](http://127.0.0.1:4200) for the API key on the organisation

```json
{
  "Novu": {
    "Url": "http://localhost:3000/v1",
    "ApiKey": "082f1cdac19663855359343735aae5b1"
  }
}
```

### OpenApi

* [http://127.0.0.1:3000/openapi](http://127.0.0.1:3000/openapi)[.json|yaml]
