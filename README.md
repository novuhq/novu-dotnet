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

TODO: More documentation

### Roadmap

Just a basic roadmap for planning purposes.

#### v0.2.0 - Subscribers

- All Subscribers endpoints completed
- Documentation generated via `docfx`

#### v0.3.0 - Topics

- All Topics endpoints completed

#### v0.4.0 - Activity

- All Activity endpoints completed

#### v0.5.0 - Feeds

- All Feed endpoints completed