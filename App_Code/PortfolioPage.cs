using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.XPath;
using umbraco.cms.businesslogic.datatype;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for PortfolioPage
/// </summary>
public class PortfolioPage : PageItem
{
    public PortfolioPage(IPublishedContent content) : base(content)
    {
    }

    public IEnumerable<string> ProjectTypes
    {
        get
        {
            XPathNodeIterator iterator = umbraco.library.GetPreValues(1100);
            iterator.MoveNext(); //move to first
            XPathNodeIterator preValues = iterator.Current.SelectChildren("preValue", "");
            var values = new List<string>();
            while (preValues.MoveNext())
            {
                values.Add(preValues.Current.Value);
            }
            return values;
        }
    }

    public IEnumerable<Market> Markets
    {
        get
        {
            var markets = Helper.TypedContent(3930);

            return markets.Children.Where(x => x.DocumentTypeAlias == "Market")
                .Select(x => new Market(x));
        }
    }

    public IHtmlString PortfolioIntro
    {
        get { return Property<IHtmlString>("portfolioIntro"); }
    }
}