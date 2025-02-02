using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services;

public class BlipService 
{
    public BlipDynamicContent Carousel(){
        var items = new List<BlipDynamicContentItem>(){
            BlipDynamicContentItem.CreateItem("Title", "This is a first item", "http://www.isharearena.com/wp-content/uploads/2012/12/wallpaper-281049.jpg"),
            BlipDynamicContentItem.CreateItem("Title 2", "This is a second item", "http://www.isharearena.com/wp-content/uploads/2012/12/wallpaper-281049.jpg")
        };
        
        return BlipDynamicContent.CreateWith(items);
    }

    public BlipDynamicContent CarouselByGithubRepos(List<GithubRepository> repos, string avatarUri){    
        if (repos == null || repos.Count < 0){
            throw new Exception("Unable read repos");
        }

        var items = repos
            .Select(r => BlipDynamicContentItem.CreateItem(r.FullName, r.Description, avatarUri))
            .ToList();
            
        return BlipDynamicContent.CreateWith(items);
    }
}
