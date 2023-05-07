using System.Collections.Generic;
using Newtonsoft.Json;

namespace Novu.DTO
{
    public partial class CreateSubscriberDto
    {
        [JsonProperty("subscriberId")]
        public string SubscriberId { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
    
        [JsonProperty("phone")]
        public string Phone { get; set; }
    
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    
        [JsonProperty("locale")]
        public string Locale { get; set; }
    
        [JsonProperty("data")]
        public List<AdditionalDataDto> Data { get; set; }
    }
}