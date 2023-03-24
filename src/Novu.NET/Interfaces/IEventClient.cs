using Novu.NET.DTO;

namespace Novu.NET.Interfaces;

public interface IEventClient
{
    public Task<dynamic> Trigger(string name, EventTriggerDataDto dto);
}