using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for OpportunitiesPage
/// </summary>
public class OpportunitiesPage : PageItem
{
    public OpportunitiesPage(IPublishedContent content) : base(content)
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

    public override string MastHeadImage
    {
        get { return HeroImage; }
    }

    public override string Url
    {
        get { return "https://careers-leoadaly.icims.com/jobs/"; }
    }
}