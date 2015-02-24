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

    public string HeadingOverlay
    {
        get { return Property("pageTitle"); }
    }

    public string CurrentTime
    {
        get
        {
            //var prop = _content.GetProperty("timezone");
            var timezone = TimeZoneInfo.FindSystemTimeZoneById(Property("timezone"));
            var localTime = TimeZoneInfo.ConvertTime(DateTime.Now, timezone);
            return localTime.ToShortTimeString();
        }
    }

    public bool IsWeatherAvailable
    {
        get { return CurrentTemperature != null; }
    }

    public string CurrentTemperature
    {
        get
        {
            try
            {
                var city = string.IsNullOrEmpty(Property("cityForTemperature")) ? HeadingOverlay : Property("cityForTemperature");

                var weather = WeatherService.GetWeather(city);
                return ((int)Math.Round(weather.Temperature)).ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public string StatementLine1
    {
        get { return string.IsNullOrEmpty(Property("statementLine1")) ? "Today, we are working on:" : Property("statementLine1"); }
    }

    public string StatementLine2
    {
        get { return Property("statementLine2"); }
    }

    public IHtmlString Overview
    {
        get { return Property<IHtmlString>("overview"); }
    }

    public string ContactName
    {
        get { return Property("contactName"); }
    }

    public string ContactTitle
    {
        get { return Property("contactTitle"); }
    }

    public string ContactEmail
    {
        get { return Property("contactEmail"); }
    }

    public IHtmlString ContactAddress
    {
        get { return Property<IHtmlString>("contactAddress"); }
    }

    public string ContactPhone
    {
        get { return Property("contactPhone"); }
    }

    public string ContactFax
    {
        get { return Property("contactFax"); }
    }

    public IEnumerable<Leader> Leaders
    {
        get { return WrapList<Leader>(Property("leaders")); }
    }

    public string RelatedProjectsHeading
    {
        get { return Parent.Parent.Property("relatedProjectsHeading"); }
    }

    public IEnumerable<Project> RelatedProjects
    {
        get
        {
            return WrapList<Project>(Property("relatedProjects"))
                .Where(x => x.IsPublished);
        }
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