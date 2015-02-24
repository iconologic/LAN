using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for PeoplePage
/// </summary>
public class PeoplePage : PageItem
{
    public PeoplePage(IPublishedContent content) : base(content)
    {
    }

    public string HeroImage
    {
        get { return ImageUrlProperty("heroImage"); }
    }

    public override string MastHeadImage
    {
        get { return HeroImage; }
    }
}