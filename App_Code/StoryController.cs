using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.WebApi;

/// <summary>
/// Summary description for StoryController
/// </summary>
public class StoryController : UmbracoApiController
{
    public object Get(int market, int location, int leader)
    {
        var stories = Story.Find(market, location, leader).ToList();

        var featuredStories = stories.Where(x => x.IsFeatured)
            .OrderByDescending(x => x.DisplayDate).Select(x => new
        {
            Month = x.DisplayDate.ToString("MMMM"),
            Day = x.DisplayDate.ToString("dd"), 
            Year = x.DisplayDate.ToString("yyyy"),
            x.Title,
            ImageUrl = x.CtaImage,
            Copy = x.CtaCopy, 
            x.Url
        });
        var storiesByDate = stories.Where(x => x.IsFeatured == false)
            .OrderByDescending(x => x.DisplayDate).Select(x => new
            {
                Month = x.DisplayDate.ToString("MMMM"),
                Day = x.DisplayDate.ToString("dd"),
                Year = x.DisplayDate.ToString("yyyy"),
                x.Title,
                ImageUrl = x.CtaImage,
                Copy = x.CtaCopy,
                x.Url
            }); 
        return new
        {
            featuredStories,
            storiesByDate
        };
    }
}