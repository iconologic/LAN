using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco;
using Umbraco.Core.Models;
using Umbraco.Web;

/// <summary>
/// Summary description for Page
/// </summary>
public class PageItem : ContentItem
{
    public PageItem(IPublishedContent content)
        : base(content)
    {
    }



    public virtual string NavigationTitle
    {
        get
        {
            var title = Property("navigationName");
            return string.IsNullOrWhiteSpace(title) ? Name : title;
        }
    }

    public bool IsCurrentPage
    {
        get { return UmbracoContext.Current.PageId != null && UmbracoContext.Current.PageId.Value == this.Id; }
    }

    public virtual string MastHeadImage
    {
        get { return "/media/2238/locations.jpg"; }
    }

    public virtual string MastHeadTitle
    {
        get { return NavigationTitle; }
    }

    public bool HasTemplate
    {
        get { return Content.TemplateId > 0; }
    }
    public IEnumerable<PageItem> Breadcrumb
    {
        get
        {
            var breadCrumb = new List<PageItem>();
            var content = Content;
            do
            {
                var pageItem = CreatePageItem(content);
                if (pageItem.HasTemplate && pageItem.IncludePageInBreadCrumb) // exlcude items that aren't actually pages
                {
                    breadCrumb.Insert(0, pageItem);
                }

                content = content.Parent;
            } while (content != null);

            return breadCrumb;
        }
    }

    protected virtual bool IncludePageInBreadCrumb
    {
        get { return true; }
    }

    public bool HasNext
    {
        get { return Next() != null; }
    }

    public PageItem Next()
    {
         IPublishedContent content = DocumentTypeAlias != null ? Content.Next(DocumentTypeAlias) : Content.Next();
        if (content == null)
            return null;
        return CreatePageItem(content);
    }

    public bool HasPrevious
    {
        get { return Previous() != null; }
    }
    public PageItem Previous()
    {
        IPublishedContent content = DocumentTypeAlias != null ? Content.Previous(DocumentTypeAlias) : Content.Previous();
        if (content == null)
            return null;
        return CreatePageItem(content);
    }

    public virtual PageItem NavigationPage
    {
        get { return ParentPage; }
    }
}