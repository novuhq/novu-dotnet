using Novu.NET.DTO;
using Novu.NET.Interfaces;
using Novu.NET.Utilities;
using RestSharp;

namespace Novu.NET.Clients;

public class EventClient : ApiClient, IEventClient
{
    public EventClient(INovuClientConfiguration config) : base(config)
    {
        
    }
    
    /// <summary>
    /// Trigger an event
    /// </summary>
    /// <remarks>
    /// As of v0.1.0, this will only accept Subscriber ID in order to Trigger.
    /// The reason why it's this way is so we can get a MVP of the SDK out for use
    /// and then iterate over the changes over time.
    /// </remarks>
    /// <param name="name"><see cref="string"/> that is the Trigger Id</param>
    /// <param name="dto"><see cref="EventTriggerDataDto"/> Trigger Payload data</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<dynamic> Trigger(string name, EventTriggerDataDto dto)
    {
        var request = new RestRequest("/events/trigger");

        var json = Serializer<EventTriggerDataDto>.ToJson(dto);

        throw new NotImplementedException();
    }
}