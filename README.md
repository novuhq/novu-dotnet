<div align="center">
  <a href="https://novu.co" target="_blank">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/2233092/213641039-220ac15f-f367-4d13-9eaf-56e79433b8c1.png">
    <img src="https://user-images.githubusercontent.com/2233092/213641043-3bbb3f21-3c53-4e67-afe5-755aeb222159.png" width="280" alt="Logo"/>
  </picture>
  </a>
</div>

# novu-dotnet

## Installation

```bash
dotnet add package Novu
```

```csharp
using Novu.DTO;
using Novu.Models;
using Novu;
...

 var novuConfiguration = new NovuClientConfiguration
{
    // Defaults to https://api.novu.co/v1
    Url = "https://novu-api.my-domain.com/v1",
    ApiKey = "12345",
};

var novu = new NovuClient(novuConfiguration);

var subscribers = await novu.Subscribers.GetSubscribers();

```

## Examples

### Novu Client

```csharp

using Novu.DTO;
using Novu.Models;
using Novu;
...

var config = new NovuClientConfiguration
{
  ApiKey = "my-key",
};

var client = new NovuClient(config);

```

## Subscribers

### Get Subscribers

```csharp

using Novu.DTO;
using Novu.Models;
using Novu;
...

var subscribers = await client.Subscriber.GetSubscribers()


```

### Get Subscriber

```csharp

using Novu.DTO;
using Novu.Models;
using Novu;
...

var subscriber = await client.Subscriber.GetSubscriber("subscriberId");


```

### Create Subscriber

```csharp
using Novu.DTO;
using Novu.Models;
using Novu;
...

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

using Novu.DTO;
using Novu.Models;
using Novu;
...

var subscriber = client.Subscriber.GetSubscriber("subscriberId");

subscriber.FirstName = "Updated";
subscriber.LastName = "Subscriber";

var updatedSubscriber = await client.Subscriber.UpdateSubscriber(subscriber);


```

### Delete Subscriber

```csharp

using Novu.DTO;
using Novu.Models;
using Novu;
...

var deleted = await client.Subscriber.DeleteSubscriber("subscriberId");


```

### Update Online Status

```csharp

using Novu.DTO;
using Novu.Models;
using Novu;
...

var onlineDto = new SubscriberOnlineDto
{
  IsOnline = true
};

var online = await client.Subscriber.UpdateOnlineStatus("subscriberId", onlineDto);

```

## Events

### Trigger

using Novu.DTO;
using Novu.Models;
using Novu;
...

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

using Novu.DTO;
using Novu.Models;
using Novu;
...

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

using Novu.DTO;
using Novu.Models;
using Novu;
...

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

using Novu.DTO;
using Novu.Models;
using Novu;
...

var cancelled = await client.Event.TriggerCancelAsync("triggerTransactionId");

```

## Topics

```csharp

// Get Topic

var result = await client.Topic.GetTopicAsync("my-topic");

// Get Topics

var results = await client.Topic.GetTopicsAsync();

// Create Topic
var topicRequest = new TopicCreateDto
{
    Key = $"test:topic:{Guid.NewGuid().ToString()}",
    Name = "Test Topic",
    
};

var topic = await client.Topic.CreateTopicAsync(topicRequest);


// Add Subscriber to Topic
var subscriberList = new TopicSubscriberUpdateDto
{
    Keys = new List<string>
    {
        "test:subscriber:1",
    }
};

var result = await client.Topic.AddSubscriberAsync(topic.Data.Key, subscriberList);

// Remove Subscriber from Topic

var subscriberList = new TopicSubscriberUpdateDto
{
    Keys = new List<string>
    {
        "test:subscriber:1",
    }
};

var result = await client.Topic.RemoveSubscriberAsync(topic.Data.Key, subscriberList);

// Delete Topic

await client.Topic.DeleteTopicAsync("my-topic");

// Rename Topic

var topicRequest = new TopicRenameDto
{
    Name = "New Name"
};

var result = await client.Topic.RenameTopicAsync("my-topic", topicRequest);

```


## Repository Overview

All code is located under the `src` directory and this will service as the project root.

`Novu` is the main SDK with `Novu.Tests` housing all unit tests.

### novu-dotnet

- `Clients` directory holds all clients that house the actual implementation of the various API calls.
- `DTO` directory holds all Data Transfer Objects
- `Exceptions` directory holds the custom exception creations
- `Interfaces` directory holds all interfaces that are inteded to outline how a class should be structured.
- `Models` directory holds various models
- `Utilities` directory holds various utility functions used around the project.
