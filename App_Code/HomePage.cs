using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for HomePage
/// </summary>
public class HomePage : PageItem
{
    public HomePage(IPublishedContent content)
        : base(content)
    {
    }

    public IEnumerable<Project> FeaturedProjects
    {
        get
        {
            return WrapList<Project>(Property("featuredProjects"))
                .Where(x => x.SliderImages.Any());
        }
    }

    public static HomePage Instance
    {
        get
        {
            return new HomePage(Helper.TypedContent(1053));
        }
    }

    public IEnumerable<CallToAction> ContentBlocks
    {
        get { return WrapList<CallToAction>(Property("contentBlocks")); }
    } 
}