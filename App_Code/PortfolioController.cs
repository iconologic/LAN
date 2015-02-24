using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Umbraco.Web.WebApi;

/// <summary>
/// Summary description for PortfolioController
/// </summary>
public class PortfolioController : UmbracoApiController
{
	public PortfolioController()
	{


	}

    public object Get(string type, string market, string subMarket)
    {
        return Project.Search(new ProjectSearchCriteria()
        {
            Market = market,
            ProjectType = type,
            SubMarket = subMarket,
        })
        .Select(v => new {title=v.Title, image=Website.ImageUrl(v.Thumbnail, 370, 234), url=v.Url})
        .ToList();
    }
    public object Get(string market, string service)
    {
        return Project.Search(new ProjectSearchCriteria()
        {
            Market = market,
            Service = service
        })
        .Select(v => new {title=v.Title, image=Website.ImageUrl(v.Thumbnail, 370, 234), url=v.Url})
        .ToList();
    }
}