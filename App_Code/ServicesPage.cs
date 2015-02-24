using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for ServicesPage
/// </summary>
public class ServicesPage : PageItem
{
    public ServicesPage(IPublishedContent content) : base(content)
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

    public IEnumerable<Service> Services
    {
        get { return Children<Service>("Service").Where(x => x.IsPublished); }
    }

    public override bool ShowChildrenInNavigation
    {
        get { return true; }
    }
}