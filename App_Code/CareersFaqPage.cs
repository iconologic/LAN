using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for CareersFaqPage
/// </summary>
public class CareersFaqPage : PageItem
{
    public CareersFaqPage(IPublishedContent content) : base(content)
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

    public override bool ShowChildrenInNavigation
    {
        get { return true; }
    }

    public IEnumerable<FaqTopic> Topics
    {
        get { return Children<FaqTopic>(); }
    } 
}