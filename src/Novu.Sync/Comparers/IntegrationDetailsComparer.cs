using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Novu.Domain;
using Novu.Domain.Models.Integrations;

namespace Novu.Sync.Comparers;

public class IntegrationDetailsComparer : IEqualityComparer<Integration>
{
    public bool Equals(Integration x, Integration y)
    {
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
        {
            return false;
        }

        return x.Name is { } s && s.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase) &&
               x.ProviderId == y.ProviderId &&
               x.Active == y.Active &&
               // inefficient but needing to check if the payloads are different
               // TODO: may want to inject serialisation setting to be consistent
               JsonConvert.SerializeObject(x.Credentials, NovuJsonSettings.DefaultSerializerSettings)
                   .Equals(JsonConvert.SerializeObject(y.Credentials, NovuJsonSettings.DefaultSerializerSettings));
    }

    public int GetHashCode(Integration obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.ProviderId);
        hashCode.Add(obj.Channel);
        return hashCode.ToHashCode();
    }
}