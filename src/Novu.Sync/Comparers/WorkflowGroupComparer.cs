using System;
using System.Collections.Generic;
using Novu.Domain.Models.WorkflowGroups;

namespace Novu.Sync.Comparers;

public class WorkflowGroupComparer : IEqualityComparer<WorkflowGroup>
{
    public bool Equals(WorkflowGroup x, WorkflowGroup y)
    {
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
        {
            return false;
        }

        return true;
    }

    public int GetHashCode(WorkflowGroup obj)
    {
        // Workflow groups are unique by Id and NOT names. However, this implementation
        // will work with the Name as the identifier. This means that duplicate Names will
        // not be detected in practice
        var hashCode = new HashCode();
        hashCode.Add(obj.Name);
        return hashCode.ToHashCode();
    }
}