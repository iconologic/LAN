using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for CommunityPage
/// </summary>
public class CommunityPage : PageItem
{
    public CommunityPage(IPublishedContent content) : base(content)
    {
    }

    public string Heading
    {
        get { return Property("heading"); }
    }

    public IHtmlString IntroCopy
    {
        get { return Property<IHtmlString>("introCopy"); }
    }

    public string HeroImage
    {
        get { return ImageUrlProperty("heroImage"); }
    }

    public IEnumerable<CommunityStory> Stories
    {
        get { return Children<CommunityStory>("CommunityStory")
            .Where(x => x.IsPublished)
            .OrderByDescending(s => s.DisplayDate); }
    }

    public override bool ShowChildrenInNavigation
    {
        get { return false; }
    }
}