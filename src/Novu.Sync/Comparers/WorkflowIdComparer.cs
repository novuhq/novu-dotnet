using System;
using System.Collections.Generic;
using Novu.Domain.Models.Workflows;

namespace Novu.Sync.Comparers;

public class WorkflowIdComparer : IEqualityComparer<Workflow>
{
    public bool Equals(Workflow x, Workflow y)
    {
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
        {
            return false;
        }

        return true;
    }

    public int GetHashCode(Workflow obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.Name);
        return hashCode.ToHashCode();
    }
}
