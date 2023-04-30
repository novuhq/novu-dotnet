# Novu.NET

**Getting Started**

```csharp
 var novuConfiguration = new NovuClientConfiguration
{
    // Defaults to https://api.novu.co/v1
    Url = "https://novu-api.my-domain.com/v1",
    ApiKey = "12345",
};

var novu = new NovuClient(novuConfiguration);

var subscribers = await novu.Subscribers.GetSubscribers();

```

# Examples

## Novu Client

```csharp

var config = new NovuClientConfiguration
{
  ApiKey = "my-key",
};

var client = new NovuClient(config);

```

## Subscribers

### Get Subscribers

```csharp

var subscribers = await client.Subscriber.GetSubscribers()


```

### Get Subscriber

```csharp

var subscriber = await client.Subscriber.GetSubscriber("subscriberId");


```

### Create Subscriber

```csharp

var additionalData = new List<AdditionalDataDto>
{
  new AdditionalDataDto
  {
    Key = "External ID",
    Value = "1122334455"
  },
  {
    Key = "SMS_PREFERENCE",
    Value = "EMERGENT_ONLY"
  }
};

var newSubscriberDto = new CreateSubscriberDto
{
  SubscriberId = Guid.NewGuid().ToString(),
  FirstName = "John",
  LastName = "Doe",
  Avatar = "https://unslpash.com/random",
  Email = "jdoe@novu.co",
  Locale = "en-US",
  Phone = "+11112223333",
  Data = additionalData
};

var subscriber = await client.Subcriber.CreateSubscriber()


```

### Update Subscriber

```csharp

var subscriber = client.Subscriber.GetSubscriber("subscriberId");

subscriber.FirstName = "Updated";
subscriber.LastName = "Subscriber";

var updatedSubscriber = await client.Subscriber.UpdateSubscriber(subscriber);


```

### Delete Subscriber

```csharp

var deleted = await client.Subscriber.DeleteSubscriber("subscriberId");


```

### Update Online Status

```csharp

var onlineDto = new SubscriberOnlineDto
{
  IsOnline = true
};

var online = await client.Subscriber.UpdateOnlineStatus("subscriberId", onlineDto);

```

## Events

### Trigger

```csharp

// OnboardEventPayload.cs
public class OnboardEventPayload
{
  [JsonProperty("username")]
  public string Username { get; set; }

  [JsonProperty("welcomeMessage")]
  public string WelcomeMessage { get; set; }
}

// MyFile.cs
var onboardingMessage = new OnboardEventPayload
{
  Username = "jdoe",
  WelcomeMessage = "Welcome to novu-dotnet"
};

var payload = new EventTriggerDataDto()
{
  EventName = "onboarding",
  To = { SubscriberId = "subscriberId" },
  Payload = onboardingMessage
};

var trigger = await client.Event.Trigger(payload);

if (trigger.TriggerResponsePayloadDto.Acknowledged)
{
  Console.WriteLine("Trigger has been created.");
}

```

### Trigger Bulk

```csharp

var payload = new List<EventTriggerDataDto>()
{
    new()
    {
        EventName = "test",
        To = { SubscriberId = subscriber.SubscriberId},
        Payload = new TestRecord(){ Message = "Hello"}
    },
    new()
    {
        EventName = "test",
        To = { SubscriberId = subscriber.SubscriberId},
        Payload = new TestRecord(){ Message = "World"}
    },
};

var trigger = await client.Event.TriggerBulkAsync(payload);

```

### Broadcast Trigger

```csharp

var testRecord = new TestRecord
{
    Message = "This is a test message"
};

var dto = new EventTriggerDataDto()
{
    EventName = "test",
    To =
    {
        SubscriberId = subscriber.SubscriberId
    },
    Payload = testRecord
};

var trigger = await client.Event.TriggerBroadcastAsync(dto);

```

### Cancel Trigger

```csharp

var cancelled = await client.Event.TriggerCancelAsync("triggerTransactionId");

```

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
