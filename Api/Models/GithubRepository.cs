using System;
using System.Text.Json.Serialization;

namespace Api.Models;

public class GithubRepository
{
    [JsonPropertyName("id")]
    public int? Id {get;set;}

    [JsonPropertyName("name")]
    public string Name {get;set;}

    [JsonPropertyName("full_name")]
    public string FullName {get;set;}

    [JsonPropertyName("description")]
    public string Description {get;set;}

    [JsonPropertyName("language")]
    public string Language {get;set;}
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt {get;set;}
}
