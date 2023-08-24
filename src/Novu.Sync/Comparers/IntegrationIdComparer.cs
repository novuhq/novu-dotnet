using System;
using System.Collections.Generic;
using Novu.DTO.Integrations;

namespace Novu.Sync.Comparers;

public class IntegrationIdComparer : IEqualityComparer<Integration>
{
    public bool Equals(Integration x, Integration y)
    {
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
        {
            return false;
        }

        return true;
    }

    public int GetHashCode(Integration obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.ProviderId);
        hashCode.Add(obj.Channel);
        return hashCode.ToHashCode();
    }
}
