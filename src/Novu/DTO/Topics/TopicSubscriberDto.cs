using Newtonsoft.Json;

namespace Novu.DTO.Topics;

public class TopicSubscriberDto
{
    [JsonProperty("data")]
    public TopicSubscriberData Data { get; set; }
}

public class TopicSubscriberData
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("_environmentId")]
    public string EnvironmentId { get; set; }

    [JsonProperty("_organizationId")]
    public string OrganizationId { get; set; }

    [JsonProperty("_subscriberId")]
    public string SubscriberId { get; set; }

    [JsonProperty("_topicId")]
    public string TopicId { get; set; }

    [JsonProperty("externalSubscriberId")]
    public string ExternalSubscriberId { get; set; }

    [JsonProperty("topicKey")]
    public string TopicKey { get; set; }

    [JsonProperty("__v")]
    public long V { get; set; }

    [JsonProperty("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonProperty("id")]
    public string DataId { get; set; }
}