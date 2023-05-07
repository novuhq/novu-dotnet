using System;
using Newtonsoft.Json;

namespace Novu.DTO
{
    public class SubscriberDto
    {
        [JsonProperty("_organizationId")]
        public string OrganizationId { get; set; }

        [JsonProperty("_environmentId")]
        public string EnvironmentId { get; set; }

        [JsonProperty("subscriberId")]
        public string SubscriberId { get; set; }
    
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
    
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("channels")]
        public object[] Channels { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("isOnline")]
        public bool? IsOnline { get; set; }

        [JsonProperty("lastOnlineAt")]
        public DateTimeOffset? LastOnlineAt { get; set; }
    }
}