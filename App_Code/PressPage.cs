using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for PressPage
/// </summary>
public class PressPage : PageItem
{
    public PressPage(IPublishedContent content)
        : base(content)
    {
    }

    public IEnumerable<Story> FeaturedStories
    {
        get
        {
            return Children<Story>()
                .Where(x => x.IsPublished && x.IsFeatured)
                .OrderByDescending(x => x.DisplayDate);
        }
    }

    public IEnumerable<Story> Stories
    {
        get
        {
            return Children<Story>("Story")
                .Where(x => x.IsPublished && !x.IsFeatured)
                .OrderByDescending(x => x.DisplayDate);
        }
    }

    public IEnumerable<Story> StoriesByPage(int pageNumber)
    {
        return Stories.Skip((pageNumber - 1) * StoriesPerPage).Take(StoriesPerPage);
    }

    public int StoriesPerPage
    {
        get { return Property<int>("storiesPerPage"); }
    }
    public int StoryPages
    {
        get { return (Stories.Count() / StoriesPerPage) + ((Stories.Count() % StoriesPerPage > 0) ? 1 : 0); }
    }

    public override bool ShowChildrenInNavigation
    {
        get { return false; }
    }

    protected override string DocumentTypeAlias
    {
        get { return "Press"; }
    }

    public IEnumerable<Leader> LeaderFilter
    {
        get
        {
            return Story.GetAll()
                .SelectMany(x => x.RelatedLeaders)
                .Distinct()
                .OrderBy(x => x.Name);
        }
    }

    public IEnumerable<Location> LocationFilter
    {
        get
        {
            return Story.GetAll()
                .SelectMany(x => x.RelatedLocations)
                .Distinct()
                .OrderBy(x => x.Name);
        }
    }

    public IEnumerable<Market> MarketFilter
    {
        get
        {
            return Story.GetAll()
                .SelectMany(x => x.RelatedMarkets)
                .Distinct()
                .OrderBy(x => x.Name);
        }
    } 
}