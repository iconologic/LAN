using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for AboutOverviewPage
/// </summary>
public class AboutOverviewPage : PageItem
{
    public AboutOverviewPage(IPublishedContent content) : base(content)
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

    public IHtmlString Copy
    {
        get { return Property<IHtmlString>("copy"); }
    }

    public string PhilosophyHeading
    {
        get { return Property("philosophyHeading"); }
    }

    public string Philosophy1
    {
        get { return Property("philosophy1"); }
    }
    
    public string Philosophy3Icon
    {
        get { return ImageUrlProperty("philosophy3Icon"); }
    }
    public string Philosophy2Icon
    {
        get { return ImageUrlProperty("philosophy2Icon"); }
    }

    public string Philosophy1Icon
    {
        get { return ImageUrlProperty("philosophy1Icon"); }
    }

    public IHtmlString Philosophy1Copy
    {
        get { return Property<IHtmlString>("philosophy1Copy"); }
    }

    public string Philosophy2
    {
        get { return Property("philosophy2"); }
    }

    public IHtmlString Philosophy2Copy
    {
        get { return Property<IHtmlString>("philosophy2Copy"); }
    }

    public string Philosophy3
    {
        get { return Property("philosophy3"); }
    }

    public IHtmlString Philosophy3Copy
    {
        get { return Property<IHtmlString>("philosophy3Copy"); }
    }

    public string VisionStatement
    {
        get { return Property("visionStatement"); }
    }

    public IHtmlString VisionCopy
    {
        get { return Property<IHtmlString>("visionCopy"); }
    }


}