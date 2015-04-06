using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

/// <summary>
/// Summary description for Website
/// </summary>
public static class Website
{
    public static string ImageUrl(string path, int width, int height)
    {
        return string.Format("/ImageGen.ashx?image={0}&width={1}&height={2}", path, width, height);
    }

    public static IEnumerable<PageItem> BreadCrumb(IPublishedContent current)
    {
        
        var breadCrumb = new List<PageItem>();
        var content = current;
        do
        {
            if (content.TemplateId > 0) // exlcude items that aren't actually pages
                breadCrumb.Insert(0, new PageItem(content));
            
            content = content.Parent;
        } while (content != null);

        return breadCrumb;
    }

    private static string Obfuscate(string text)
    {
        return String.Concat(text.Select(c => "&#" + ((int) c).ToString("000") + ";").ToArray());
    }

    public static string EmailLink(string emailAddress)
    {
        return string.Format("<a href='{0}{1}'>{1}</a>", Obfuscate("mailto:"), Obfuscate(emailAddress));
    }

    public static bool HasContent(IHtmlString s)
    {
        return s != null && !string.IsNullOrWhiteSpace(s.ToHtmlString());
    }

    public static string ActiveIfPage(int id)
    {
        return UmbracoContext.Current.PageId.HasValue && UmbracoContext.Current.PageId.Value == id
            ? "active"
            : string.Empty;

    }

    public static string If(bool condition, string output)
    {
        if (condition)
            return output;
        return string.Empty;
    }

    public static bool IsLan
    {
        get { return HttpContext.Current.Request.Url.Host.ToLower().Contains("lan"); }
    }

    public static bool IsLad
    {
        get { return !IsLan; }
    }
}