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
    /// <param name="dto"><see cref="EventTriggerDataDto"/> Trigger Payload data</param>
    /// <returns></returns>
    public async Task<TriggerResponseDto> Trigger(EventTriggerDataDto dto)
    {
        var request = new RestRequest("/events/trigger");

        var json = Serializer<EventTriggerDataDto>.ToJson(dto);

        request.AddBody(json, ContentType.Json);

        var restResponse = await Client.PostAsync(request);

        var response = Serializer<TriggerResponseDto>.FromJson(restResponse.Content);

        return response;
    }

    public async Task<TriggerBulkResponseDto> TriggerBulkAsync(List<EventTriggerDataDto> payload)
    {
        if (payload.Count > 100)
        {
            throw new Exception("You can only trigger 100 events at a time.");
        }
        
        var request = new RestRequest("/events/trigger/bulk");

        var dto = new TriggerBulkDto
        {
            Events = payload
        };

        var json = Serializer<TriggerBulkDto>.ToJson(dto);

        request.AddBody(json, ContentType.Json);

        var restResponse = await Client.PostAsync(request);

        var response = Serializer<TriggerBulkResponseDto>.FromJson(restResponse.Content);

        return response;
    }

    public async Task<TriggerResponseDto> TriggerBroadcastAsync(EventTriggerDataDto dto)
    {
        var request = new RestRequest("/events/trigger/broadcast");

        var json = Serializer<EventTriggerDataDto>.ToJson(dto);

        request.AddBody(json, ContentType.Json);

        var restResponse = await Client.PostAsync(request);

        var response = Serializer<TriggerResponseDto>.FromJson(restResponse.Content);

        return response;
    }

    public async Task TriggerCancelAsync(Guid transactionId)
    {
        var request = new RestRequest($"/events/trigger/{transactionId}");

        var restResponse = await Client.DeleteAsync(request);
    }
}