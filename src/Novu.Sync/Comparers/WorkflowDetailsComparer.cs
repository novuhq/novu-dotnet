using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Novu.Domain;
using Novu.Domain.Models.Workflows;

namespace Novu.Sync.Comparers;

public class WorkflowDetailsComparer : IEqualityComparer<Workflow>
{
    public bool Equals(Workflow x, Workflow y)
    {
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
        {
            return false;
        }

        return x.Active == y.Active &&
               x.Description == y.Description &&
               // inefficient but needing to check if the payloads are different
               // TODO: may want to inject serialisation setting to be consistent
               JsonConvert.SerializeObject(x.PreferenceSettings, NovuJsonSettings.DefaultSerializerSettings)
                   .Equals(JsonConvert.SerializeObject(y.PreferenceSettings, NovuJsonSettings.DefaultSerializerSettings)) &&
               JsonConvert.SerializeObject(x.Steps, NovuJsonSettings.DefaultSerializerSettings)
                   .Equals(JsonConvert.SerializeObject(y.Steps, NovuJsonSettings.DefaultSerializerSettings));
    }

    public int GetHashCode(Workflow obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.Name);
        return hashCode.ToHashCode();
    }
}