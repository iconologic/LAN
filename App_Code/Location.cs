using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

/// <summary>
/// Summary description for Location
/// </summary>
public class Location : PageItem
{
    public Location(IPublishedContent content) : base(content)
    {
    }

    public string Address1
    {
        get { return Property("address1"); }
    }

    public string Address2
    {
        get { return Property("address2"); }
    }

    public string City
    {
        get { return Property("city"); }
    }

    public string State
    {
        get { return Property("state"); }
    }

    public string Zip
    {
        get { return Property("zip"); }
    }

    public string Phone
    {
        get { return Property("phone"); }

    }

    public string Fax
    {
        get { return Property("fax"); }
    }


    public static IEnumerable<Location> GetAll(int parentId)
    {
        
        return Helper.TypedContent(parentId).Descendants("Location")
            .Where(x => x.DocumentTypeAlias == "Location")
            .Select(x => new Location(x))
            .Where(x => x.IsPublished);
    } 
    public static IEnumerable<Location> GetAll()
    {
        return GetAll(1112);
    } 

}