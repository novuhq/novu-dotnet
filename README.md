# Novu.NET

**Getting Started**

```csharp
 var novuConfiguration = new NovuClientConfiguration
{
    Url = "https://api.novu.co/v1",
    ApiKey = "12345",
    ApplicationId = "abcde"
};

var novu = new NovuClient(novuConfiguration);

var subscribers = await novu.Subscribers.GetSubscribers();

```

## Currently Implemented

### Subscribers

- ✅ Get Subscribers
- ✅ Get Subscriber
- ✅ Create Subscriber
- ✅ Update Subscriber
- ✅ Delete Subscriber
- ✅ Update Online Status

### Events

- ✅ Trigger
- ✅ Bulk Trigger
- ✅ Broadcast Trigger
- ✅ Cancel Trigger

## Repository Overview

All code is located under the `src` directory and this will service as the project root.

`Novu.NET` is the main SDK with `Novu.NET.Tests` housing all unit tests.

### Novu.NET

- `Clients` directory holds all clients that house the actual implementation of the various API calls.
- `DTO` directory holds all Data Transfer Objects
- `Exceptions` directory holds the custom exception creations
- `Interfaces` directory holds all interfaces that are inteded to outline how a class should be structured.
- `Models` directory holds various models
- `Utilities` directory holds various utility functions used around the project.
