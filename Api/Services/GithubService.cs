using System.Text.Json.Nodes;
using System.Text.Json;
using Api.Models;
using Microsoft.AspNetCore.SignalR;


namespace Api.Services;

public class GithubService
{
    private readonly HttpClient _client = new();
    
    public string UserName { get; set; }

    public GithubService(){
        _client.BaseAddress = new Uri("https://api.github.com/");
        _client.DefaultRequestHeaders.Add("User-Agent", "blip-challenge");
    }

    public async Task<string> GetAvatar() {
        var endpoint = $"/users/{UserName}";

        var response = await _client.GetStringAsync(endpoint);
        var userObj = JsonSerializer.Deserialize<JsonObject>(response)
            ?? throw new Exception($"unable to identify user '{UserName}'."); 
        
        return userObj["avatar_url"]?.ToString();
    }

    public async Task<List<GithubRepository>> ListObject() {
        
        var allRepos = new List<GithubRepository>();
        
        var page = 1;
        var morePages = true;

        while (morePages){
            var endpoint = $"/users/{UserName}/repos?per_page=100&page={page}";
            var response = await _client.GetStringAsync(endpoint);
            
            var repos = JsonSerializer.Deserialize<List<GithubRepository>>(response);
            
            if (repos == null || repos.Count == 0){
                morePages = false;
                break;
            }
            
            var reposCSharp = repos
                .Where(r => !string.IsNullOrEmpty(r.Language) && r.Language.Equals("C#"));
            allRepos.AddRange(reposCSharp);
        }

        var sortedRepos = allRepos
            .OrderByDescending(r => r.CreatedAt)
            .Take(5)
            .ToList();

        return sortedRepos;
    }

    public async Task<List<GithubRepository>> ListObject_1() {
        var endpoint = $"/users/{UserName}/repos";
        
        var response = await _client.GetStringAsync(endpoint);
        var repos = JsonSerializer.Deserialize<List<GithubRepository>>(response);
        
        if (repos == null){
            throw new Exception($"Unable to identify repositories for user '{UserName}'."); 
        }

        var sortedRepos = repos
            .Where(r => !string.IsNullOrEmpty(r.Language) && r.Language.Equals("C#"))
            .OrderByDescending(r => r.CreatedAt)
            .Take(5)
            .ToList();

        return sortedRepos;
    }

}