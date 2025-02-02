using System;
using System.Text.Json.Serialization;

namespace Api.Models;

public class BlipItemHeader
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("value")]
    public BlipItemHeaderValue Value { get; set; }
}
