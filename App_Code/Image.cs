using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for Image
/// </summary>
public class PublishedMedia : ContentItem
{
    public PublishedMedia(IPublishedContent content) : base(content)
    {
    }


    public override string Url
    {
        get { return Property("umbracoFile"); }
    }

    public string Title
    {
        get { return Property("title"); }
    }


}