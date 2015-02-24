using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for CareersPage
/// </summary>
public class CareersPage : PageItem
{
    public CareersPage(IPublishedContent content) : base(content)
    {
    }

    public string HeroImage
    {
        get { return ImageUrlProperty("heroImage"); }
    }

    public string Heading
    {
        get { return Property("heading"); }
    }

    public string Intro
    {
        get { return Property("Intro"); }
    }

    public string CallToAction
    {
        get { return Property("callToAction"); }
    }

    public string CallToActionUrl
    {
        get { return Property("callToActionUrl"); }
    }

    public string OpportunitiesButtonText
    {
        get { return Property("opportunitiesButtonText"); }
    }

    public string FaqButtonText
    {
        get { return Property("faqButtonText"); }
    }

    public string CultureHeading
    {
        get { return Property("cultureHeading"); }
    }

    public IHtmlString CultureCopy
    {
        get { return Property<IHtmlString>("cultureCopy"); }
    }

    public string YouTubeId
    {
        get { return Property("youtubeID"); }
    }

    public string SeeAllVideosButtonText
    {
        get { return Property("seeAllVideosButtonText"); }
    }

    public string DevelopmentBackgroundImage
    {
        get { return ImageUrlProperty("developmentBackgroundImage"); }
    }
    public string DevelopmentHeading
    {
        get { return Property("developmentHeading"); }
    }

    public IHtmlString DevelopmentCopy
    {
        get
        {
            return Property<IHtmlString>("developmentCopy");
        }
    }

    public string DevelopmentReadMoreText
    {
        get { return Property("readMoreButtonText"); }
    }

    public string CommunityHeading
    {
        get { return Property("communityHeading"); }
    }

    public IHtmlString CommunityCopy
    {
        get { return Property<IHtmlString>("communityCopy"); }
    }

    public string CommunityCta
    {
        get { return Property("communityCta"); }
    }

    public string CommunityUrl
    {
        get { return ChildPageUrl("Community"); }
    }

    public IEnumerable<CommunityStory> CommunityStories
    {
        get { return CommunityStory.GetAll().Where(x => x.IsFeatured).Take(2); }
    } 

    public string ApplyHeading
    {
        get { return Property("applyHeading"); }
    }

    public IHtmlString ApplyCopy
    {
        get { return Property<IHtmlString>("applyCopy"); }
    }

    public string CareersButtonText
    {
        get { return Property("careersButtonText"); }
    }

    public string CultureUrl
    {
        get { return ChildPageUrl("Culture"); }
    }
    
    public string FaqUrl
    {
        get { return ChildPageUrl("CareersFaq"); }
    }

    public string DevAndEduUrl
    {
        get { return ChildPageUrl("Development"); }
    }


}