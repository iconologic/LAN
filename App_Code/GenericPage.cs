using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for GenericPage
/// </summary>
public class GenericPage : PageItem
{
    public GenericPage(IPublishedContent content) : base(content)
    {
    }

    public string HeroImage
    {
        get { return ImageUrlProperty("heroImage"); }
    }

    public string Heading
    {
        get { return Helper.ReplaceLineBreaksForHtml(Property("heading")); }
    }


    public IHtmlString Copy
    {
        get { return Property<IHtmlString>("Copy"); }
    }

}