﻿using Newtonsoft.Json;

namespace Novu.Domain.Models.Subscribers;

public class AdditionalData
{
    [JsonProperty("key")] public string Key { get; set; }
    [JsonProperty("value")] public string Value { get; set; }
}