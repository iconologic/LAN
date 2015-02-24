using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.Profiling.Data;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for CallToAction
/// </summary>
public class CallToAction : ContentItem
{
    public CallToAction(IPublishedContent content) : base(content)
    {
    }

    public string Heading
    {
        get { return Property("heading"); }
    }

    public string Subheading
    {
        get { return Property("subheading"); }
    }
    public IHtmlString Copy
    {
        get { return Property<IHtmlString>("copy"); }
    }

    public string ImageUrl
    {
        get
        {
            var imageId = Property<int>("image");
            if (imageId < 1)
                return string.Empty;
            return Helper.Media(imageId).Url;
        }
    }

    public bool HasLink
    {
        get { return !string.IsNullOrEmpty(LinkToUrl); }
    }


    public string LinkToUrl
    {
        get { return Property("linkToUrl"); }
    }

    public bool OpenLinkInNewWindow
    {
        get { return Property<bool>("openLinkInNewWindow"); }
    }

    public string YouTubeId
    {
        get { return Property("youtubeID"); }
    }

}