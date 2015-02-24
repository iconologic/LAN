using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for FaqTopic
/// </summary>
public class FaqTopic : PageItem
{
    public FaqTopic(IPublishedContent content) : base(content)
    {
    }

    public override bool ShowInNavigation
    {
        get { return true; }
    }

    public IEnumerable<Faq> Faqs
    {
        get { return Children<Faq>(); }
    }

    public override string Url
    {
        get { return "#" + HtmlId; }
    }
}