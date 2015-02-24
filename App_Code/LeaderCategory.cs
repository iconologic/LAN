using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for LeaderCategory
/// </summary>
public class LeaderCategory : PageItem
{
    public LeaderCategory(IPublishedContent content)
        : base(content)
    {
    }

    public override string Url
    {
        get { return string.Format("{0}#{1}", ParentPage.Url, HtmlId); }
    }

    protected override string DocumentTypeAlias
    {
        get { return "LeaderCategory"; }
    }
}