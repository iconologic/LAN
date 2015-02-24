using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for Service
/// </summary>
public class Service : PageItem
{
    public Service(IPublishedContent content) : base(content)
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

    public string CtaImage
    {
        get
        {
            return ImageUrlProperty("ctaImage"); 
        }
    }

    public string Heading
    {
        get { return Property("heading"); }
    }

    public IHtmlString Copy
    {
        get { return Property<IHtmlString>("copy"); }
    }


    public IEnumerable<string> Capabilities
    {
        get
        {
            var val = Property("capabilities");
            if (val == null)
                return new string[0];

            return val.Split('\n')
                .Select(x => x.Trim())
                .Where(x => x != string.Empty); 
        }
    }

    public IEnumerable<string> GetCapabilities(int col, int totalCols)
    {
        var take = Capabilities.Count()/totalCols;
        if (col != totalCols - 1 && Capabilities.Count()%totalCols > 0)
            take++;
        var skip = col*take;
        return Capabilities.Skip(skip).Take(take);
    }

    public IEnumerable<Project> RelatedProjects
    {
        get
        {
            return WrapList<Project>(Property("projects"))
                .Where(x => x.IsPublished);
        }
    }

    public override string MastHeadTitle
    {
        get { return "Services"; }
    }

    public static IList<Market> GetAll()
    {
        return Helper.TypedContent(4380).Children.Select(x => new Market(x)).ToList();
    } 
}