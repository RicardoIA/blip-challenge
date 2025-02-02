using System;
using System.Text.Json.Serialization;

namespace Api.Models;

public class BlipItemHeaderValue
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; }
}
