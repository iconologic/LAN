using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

public class Leader : PageItem
{
    public Leader(IPublishedContent content) : base(content)
    {
    }

    public string Email
    {
        get { return Property("email"); }
    }

    public string Photo
    {
        get
        {
            var id = Property<int>("photo");
            if (id <= 0)
                return null;
            return Helper.Media(id).Url;
        }
    }
    public string LargePhoto
    {
        get
        {
            var id = Property<int>("largePhoto");
            if (id <= 0)
                return null;
            return Helper.Media(id).Url;
        }
    }

    public string PhotoForDetailPage
    {
        get { return LargePhoto ?? Photo; }
    }

    public IHtmlString Specializations
    {
        get { return Property<IHtmlString>("specializations"); }
    }

    public IHtmlString Profile
    {
        get { return Property<IHtmlString>("profile"); }
    }

    public IHtmlString Education
    {
        get { return Property<IHtmlString>("education"); }
    }

    public IHtmlString Affiliations
    {
        get { return Property<IHtmlString>("affiliations"); }
    }

    public string Credentials
    {
        get { return Property("credentials"); }
    }

    public string AdditionalCredentials
    {
        get { return Property("additionalCredentials"); }
    }

    public string Title
    {
        get { return Property("title"); }
    }

    public string AdditionalTitle
    {
        get
        {
            var additionalTitle = Property("additionalTitle");
            if (additionalTitle == null)
                return string.Empty;
            return Helper.ReplaceLineBreaksForHtml(additionalTitle);
        }
    }

    public string Phone
    {
        get { return Property("phone"); }
    }

    public IList<Project> RelatedProjects
    {
        get {
            return WrapList<Project>(Property("projects")).ToList();
        }
    }

    public IEnumerable<Location> RelatedLocations
    {
        get
        {
            return WrapList<Location>(Property("locations"));
        }
    }

    public string RelatedLocationsSeparatedByComma
    {
        get { return string.Join(", ", RelatedLocations.Select(x => x.Name)); }
    }

    public IEnumerable<Market> RelatedMarkets
    {
        get
        {
            return WrapList<Market>(Property("markets"));
        }
    }

    public string RelatedMarketsSeparatedByComma
    {
        get { return string.Join(", ", RelatedMarkets.Select(x => x.Name)); }
    }

    public override string MastHeadTitle
    {
        get { return "People"; }
    }

    public override string MastHeadImage
    {
        get { return ParentPage.ParentPage.MastHeadImage; }
    }

    public override PageItem NavigationPage
    {
        get { return Content.Parent.DocumentTypeAlias == "LeaderCategory" ? ParentPage.ParentPage : ParentPage; }
    }
}