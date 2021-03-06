﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for Development
/// </summary>
public class DevelopmentPage : PageItem
{
    public DevelopmentPage(IPublishedContent content) : base(content)
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

    public string HeroImage
    {
        get { return ImageUrlProperty("heroImage"); }
    }

    public IEnumerable<PublishedMedia> Images
    {
        get { return MultipleMediaProperty("images"); }
    }
    public override string MastHeadImage
    {
        get { return HeroImage; }
    }
}