using System;
using System.Threading.Tasks;
using Novu.DTO.Subscribers;
using Novu.Interfaces;
using ParkSquare.Testing.Generators;

namespace Novu.Tests.Factories;

public class SubscriberFactory(Tracker tracker, ISubscriberClient client)
{
    public async Task<Subscriber> Make(SubscriberCreateData data = null) 
    {
        var createData = data ?? new SubscriberCreateData
        {
            SubscriberId = Guid.NewGuid().ToString(),
            FirstName = NameGenerator.AnyForename(),
            LastName = NameGenerator.AnySurname(),
            Avatar = "https://avatars.githubusercontent.com/u/77433905?s=200&v=4",
            Email = EmailAddressGenerator.AnyEmailAddress(),
            Locale = "en-US",
            Phone = TelephoneNumberGenerator.AnyTelephoneNumber(),
            Data =
            [
                new()
                {
                    Key = "FRAMEWORK",
                    Value = ".NET",
                },

                new()
                {
                    Key = "SMS_PREFERENCE",
                    Value = "EMERGENT-ONLY",
                },
            ],
        };

        var subscriber = await client.Create(createData);

        tracker.Subscribers.Add(subscriber.Data);

        return subscriber.Data;
    }
}