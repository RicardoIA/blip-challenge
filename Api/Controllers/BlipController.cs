using System;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlipController : ControllerBase
{   
    private readonly GithubService _githubService = new GithubService();
    private readonly BlipService _blipService = new BlipService();


public BlipController(){}

    [HttpGet("getCarouselRepos")]
    public async Task<ActionResult<BlipDynamicContent>> GetCarouselRepos(string user){
        try {
            _githubService.UserName = user;
            var repos = await _githubService.ListRepositories();
            var avatarUri = await _githubService.GetAvatar();

            var dynamicContent = _blipService.CarouselByGithubRepos(repos, avatarUri);
            return Ok(dynamicContent);
        }
        catch {
            return NotFound($"Unable to list repositories as carousel for github user '{_githubService.UserName}'.");
        }
    }
}
