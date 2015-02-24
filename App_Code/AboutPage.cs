using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

/// <summary>
/// Summary description for AboutPage
/// </summary>
public class AboutPage : PageItem
{
    public AboutPage(IPublishedContent content) : base(content)
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
        get { return Property("intro"); }
    }

    public string OverviewHeading
    {
        get { return Property("overviewHeading"); }
    }

    public IHtmlString OverviewCopy
    {
        get { return Property<IHtmlString>("overviewCopy"); }
    }

    public string OverviewImage
    {
        get { return ImageUrlProperty("overviewImage"); }
    }

    public string OverviewReadMoreButtonText
    {
        get { return Property("overviewReadMoreButtonText"); }
    }

    public string HistoryBackgroundImage
    {
        get { return ImageUrlProperty("historyBackgroundImage"); }
    }


    public string HistoryHeading
    {
        get { return Property("historyHeading"); }
    }

    public IHtmlString HistoryCopy
    {
        get { return Property<IHtmlString>("historyCopy"); }
    }

    public string HistoryReadMoreButtonText
    {
        get { return Property("historyReadMoreButtonText"); }
    }

    public string ServicesHeading
    {
        get { return Property("servicesHeading"); }
    }

    public IHtmlString ServicesCopy
    {
        get { return Property<IHtmlString>("servicesCopy"); }
    }

    public string PressBackgroundImage
    {
        get { return ImageUrlProperty("pressBackgroundImage"); }
    }

    public string PressHeading
    {
        get { return Property("pressHeading"); }
    }

    public IHtmlString PressCopy
    {
        get { return Property<IHtmlString>("pressCopy"); }
    }

    public string PeopleBackgroundImage
    {
        get { return ImageUrlProperty("peopleBackgroundImage"); }
    }

    public string PeopleHeading
    {
        get { return Property("peopleHeading"); }
    }

    public IHtmlString PeopleCopy
    {
        get { return Property<IHtmlString>("peopleCopy"); }
    }

    public string PeopleReadMoreButtonText
    {
        get { return Property("peopleReadMoreButtonText"); }
    }

    public string PeopleUrl
    {
        get { return ChildPageUrl("People"); }
    }

    public string OverviewUrl
    {
        get { return ChildPageUrl("AboutOverview"); }
    }

    public IEnumerable<Service> Services
    {
        get { return Content.Descendants("Service")
            .Select(x => new Service(x))
            .Where(x => x.IsPublished); }
    }

    
}