using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using umbraco.presentation.webservices;

/// <summary>
/// Summary description for LocationsPage
/// </summary>
public class LocationsPage : PageItem
{
    public LocationsPage(IPublishedContent content) : base(content)
    {
    }

    public string HeroImage
    {
        get { return ImageUrlProperty("heroImage"); }
    }

    public string Heading
    {
        get { return Property("heading"); }
    }

    public string Intro
    {
        get { return Property("intro"); }
    }

    public string LadDescription
    {
        get { return Property("ladDescription"); }
    }

    public string LanDescription
    {
        get { return Property("lanDescription"); }
    }

    public IEnumerable<RelatedLink> GetLadMiddleEast(int col, int totalCols)
    {
        return GetLocations(3872, col, totalCols).Select(x => new RelatedLink(){Caption = x.Name, Url = x.Url});
    }

    private IEnumerable<Location> GetLocations(int parentId, int col, int totalCols)
    {
        var locations = Location.GetAll(parentId).ToList();
        return GetGroup(locations, col, totalCols);

    }

    public IEnumerable<RelatedLink> LanOfficeLinks
    {
        get { return RelatedLinks("lanOfficeLinks"); }
    }

    public int GetNumberOfLanColumns(int colSize)
    {
        var itemCount = LanOfficeLinks.Count();
        return itemCount/colSize + (itemCount%colSize > 0 ? 1 : 0);
    }
  

    public IEnumerable<RelatedLink> GetLanOfficeLinks(int col, int totalCols)
    {
        return GetGroup(LanOfficeLinks.ToList(), col, totalCols);
    } 

    public IEnumerable<RelatedLink> GetLadNorthAmerica(int col, int totalCols)
    {
        return GetLocations(3871, col, totalCols).Select(x => new RelatedLink() { Caption = x.Name, Url = x.Url }); 
    }
}