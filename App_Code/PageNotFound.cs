using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for PageNotFound
/// </summary>
public class PageNotFound : PageItem
{
    public PageNotFound(IPublishedContent content) : base(content)
    {
    }

    public string Heading
    {
        get { return Property("heading"); }
    }


    public IHtmlString Copy
    {
        get { return Property<IHtmlString>("copy"); }
    }
}