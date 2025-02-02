using System;
using System.Text.Json.Serialization;

namespace Api.Models;

public class BlipDynamicContentItem
{
    [JsonPropertyName("header")]
    public BlipItemHeader Header { get; set; }

    public static BlipDynamicContentItem CreateItem(string title, string text, string uri){
        return new BlipDynamicContentItem(){
            Header = new BlipItemHeader(){
                Type = "application/vnd.lime.media-link+json",
                Value = new BlipItemHeaderValue(){
                    Text = text,
                    Title = title,
                    Type = "image/jpeg",
                    Uri = uri
                }
            }
        };
    }
}
