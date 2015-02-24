using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for SearchPage
/// </summary>
public class SearchPage : PageItem
{
    public SearchPage(IPublishedContent content) : base(content)
    {
    }

}