using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for CulturePage
/// </summary>
public class CulturePage : PageItem
{
    public CulturePage(IPublishedContent content) : base(content)
    {
    }

    public string HeroImage
    {
        get { return ImageUrlProperty("heroImage"); }
    }

    public override string MastHeadImage
    {
        get { return HeroImage; }
    }

    public string BlockQuote
    {
        get { return Helper.ReplaceLineBreaksForHtml(Property("blockQuote")); }
    }

    public string Heading
    {
        get { return Property("heading"); }
    }

    public IHtmlString IntroCopy
    {
        get { return Property<IHtmlString>("intro"); }
    }

    public IHtmlString LocationsCopy
    {
        get { return Property<IHtmlString>("locationsCopy"); }
    }

    public IEnumerable<Location> Locations
    {
        get { 
            return Helper.TypedContentAtXPath("//Location")
            .Select(x => new Location(x)); 
        }
    }

    public IEnumerable<CommunityStory> Stories
    {
        get
        {
            return Children<CommunityStory>("CultureStory")
                .Where(x => x.IsPublished)
                .OrderByDescending(s => s.DisplayDate);
        }
    }

    public override bool ShowChildrenInNavigation
    {
        get { return false; }
    }
}