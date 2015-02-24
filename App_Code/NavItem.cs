using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

/// <summary>
/// Summary description for NavItem
/// </summary>
public class NavItem
{
    private IPublishedContent _content;

    private NavItem(IPublishedContent content)
    {
        _content = content;
    }

    public string Title
    {
        get { return (string)_content.GetPropertyValue("navigationName", string.Empty); }
    }

    public IEnumerable<NavItem> Children
    {
        get
        {
            return _content.Children
                .Where(x => x.TemplateId > 0 && (bool) x.GetPropertyValue("hideFromNavigation") != true)
                .Select(x => new NavItem(x));
        }
    }

    public bool IsCurrentPage
    {
        get
        {
            var pageId = UmbracoContext.Current.PageId;
            return pageId.HasValue && pageId.Value == _content.Id;
        }
    }

    public static NavItem Root
    {
        get
        {
            return new NavItem(Helper.TypedContent(1053));
        }
    }

    private static UmbracoHelper Helper
    {
        get
        {
            return new Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current);
        }

    }
}