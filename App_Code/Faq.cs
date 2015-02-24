using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for Faq
/// </summary>
public class Faq : ContentItem
{
    public Faq(IPublishedContent content) : base(content)
    {
    }

    public string Question
    {
        get { return Property("question"); }
    }

    public IHtmlString Answer
    {
        get { return Property<IHtmlString>("answer"); }
    }

    public override string HtmlId
    {
        get { return "question" + Id; }
    }
}