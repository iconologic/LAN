using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for Story
/// </summary>
public class Story : PageItem
{
    public Story(IPublishedContent content) : base(content)
    {
    }

    public string Title
    {
        get { return Property("title"); }
    }

    public DateTime DisplayDate
    {
        get { return Property<DateTime>("displayDate"); }
    }

    public string Subtitle
    {
        get { return Property("Subtitle"); }
    }

    public bool IsFeatured
    {
        get
        {
            return Property<bool>("featured"); 
            
        }
    }

    public string CtaImage
    {
        get { return ImageUrlProperty("ctaImage"); }
    }

    public string CtaCopy
    {
        get
        {
            var copy = Property("ctaCopy");
            if (string.IsNullOrEmpty(copy))
                return string.Empty;
            return Helper.ReplaceLineBreaksForHtml(copy);
        }
    }

    public IHtmlString Copy
    {
        get { return Property<IHtmlString>("copy"); }
    }

    public string Image
    {
        get { return ImageUrlProperty("image"); }
    }

    public IEnumerable<string> Tags
    {
        get
        {
            var tags = Property("tags");
            if (tags == null)
                return new List<string>();
            return tags.Split(',');
        }
    }

    public IEnumerable<Location> RelatedLocations
    {
        get
        {
            return WrapList<Location>(Property("relatedLocations"))
                .Where(x => x.IsPublished);
        }
    }

    public IEnumerable<Leader> RelatedLeaders
    {
        get
        {
            return WrapList<Leader>(Property("relatedLeaders"))
             .Where(x => x.IsPublished);
        }
    }
    public IEnumerable<Market> RelatedMarkets
    {
        get
        {
            return WrapList<Market>(Property("relatedMarkets"))
             .Where(x => x.IsPublished);
        }
    }

    public override string MastHeadTitle
    {
        get { return "Press Release"; }
    }

    protected override bool IncludePageInBreadCrumb
    {
        get { return false; }
    }

    protected override string DocumentTypeAlias
    {
        get { return "Story"; }
    }

    public override bool ShowInNavigation
    {
        get { return false; }
    }

    public static IEnumerable<Story> GetAll()
    {
        return
            Helper.TypedContent(3514)
                .Children.Where(x => x.DocumentTypeAlias == "Story")
                .Select(x => new Story(x))
                .Where(x => x.IsPublished);
    } 
    public static IEnumerable<Story> Find(int market, int location, int leader)
    {
        var stories = GetAll();
        if (market > 0)
            stories = stories.Where(x => x.RelatedMarkets.Any(m => m.Id == market));
        if (location > 0)
            stories = stories.Where(x => x.RelatedLocations.Any(l => l.Id == location));
        if (leader > 0)
            stories = stories.Where(x => x.RelatedLeaders.Any(l => l.Id == leader));
        return stories.OrderByDescending(s => s.DisplayDate);
    } 
}