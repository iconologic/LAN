using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for CommunityStory
/// </summary>
public class CommunityStory : PageItem
{
    public CommunityStory(IPublishedContent content) : base(content)
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
        get { return Property<bool>("featured"); }
    }

    public string CtaImage
    {
        get { return ImageUrlProperty("ctaImage"); }
    }



    public IHtmlString Copy
    {
        get { return Property<IHtmlString>("copy"); }
    }

    public string Image
    {
        get { return ImageUrlProperty("image"); }
    }


    public override string MastHeadTitle
    {
        get { return "Overview"; }
    }

    protected override bool IncludePageInBreadCrumb
    {
        get { return false; }
    }

    public override bool ShowChildrenInNavigation
    {
        get { return false; }
    }

    protected override string DocumentTypeAlias
    {
        get { return "CommunityStory"; }
    }


    public static IEnumerable<CommunityStory> GetAll()
    {
        return
           Helper.TypedContent(3071)
               .Children.Where(x => x.DocumentTypeAlias == "CommunityStory")
               .Select(x => new CommunityStory(x))
               .Where(x => x.IsPublished);
    }

}