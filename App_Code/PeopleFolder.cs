using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for PeopleFolder
/// </summary>
public class PeopleFolder : PageItem
{
    public PeopleFolder(IPublishedContent content) : base(content)
    {
    }

    public override bool ShowInNavigation
    {
        get { return true; }
    }

    public override string Url
    {
        get { return ParentPage.Url + "#marketContact"; }
    }

    public override string NavigationTitle
    {
        get
        {
            if (Content.Parent.DocumentTypeAlias == "Location")
                return Content.Parent.Name + " Leadership";
            return base.NavigationTitle;
        }
    }
}