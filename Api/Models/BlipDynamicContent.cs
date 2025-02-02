using System;
using System.Text.Json.Serialization;

namespace Api.Models;

public class BlipDynamicContent
{
    [JsonPropertyName("itemType")]
    public string ItemType { get; set; }

    [JsonPropertyName("items")]
    public List<BlipDynamicContentItem> Items {get;set;}

    public static BlipDynamicContent CreateWith(List<BlipDynamicContentItem> items) {
        return new BlipDynamicContent(){
            ItemType = "application/vnd.lime.document-select+json",
            Items = items
        };
    }
}
