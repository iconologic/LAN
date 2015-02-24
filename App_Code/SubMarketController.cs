using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.WebApi;

/// <summary>
/// Summary description for SubMarketController
/// </summary>
public class SubMarketController : UmbracoApiController
{
    public object Get(int marketId)
    {
        var market = new Market(Umbraco.Content(marketId));
        return market.SubMarkets.Select(x => new {name = x.Name, id = x.Id});
    }
}