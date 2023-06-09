﻿using Newtonsoft.Json;

namespace Novu.DTO;

public class AdditionalDataDto
{
    [JsonProperty("key")]
    public string Key { get; set; }
    
    [JsonProperty("value")]
    public string Value { get; set; }
}