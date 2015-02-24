using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;

/// <summary>
/// Summary description for SliderImages
/// </summary>
public class Slider : ContentItem
{
    public Slider(IPublishedContent content) : base(content)
    {
    }

    public IEnumerable<PublishedMedia> Images
    {
        get
        {
            if (Content.ContentType.Alias == "Folder")
            {
                foreach (var child in Content.Children)
                {
                    yield return new PublishedMedia(child);
                }
            }

            yield return new PublishedMedia(Content);
        }
    } 
}