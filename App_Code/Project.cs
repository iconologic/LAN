using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Web;

/// <summary>
/// Summary description for Project
/// </summary>
public class Project : PageItem
{
    public Project(IPublishedContent content) : base(content)
    {
    }


    public string Title
    {
        get { return Property("projectTitle"); }
    }

    public string Thumbnail
    {
        get
        {
            var thumb = SliderImages.FirstOrDefault();
            if (thumb != null)
                return thumb.Url;
            return string.Empty;
        }
    }

    public string ProjectType
    {
        get { return Property("projectType"); }
    }

    public string Summary
    {
        get { return Property("summary"); }
    }

    [JsonIgnore]
    public IEnumerable<PublishedMedia> SliderImages
    {
        get { return new Slider(Helper.Media(Property<int>("sliderImage"))).Images; }
    }

    public IEnumerable<Market> Markets
    {
        get
        {
            return WrapList<Market>(Property("projectMarket"))
             .Where(x => x.IsPublished);  
        }
    }

    public IEnumerable<Service> Services
    {
        get
        {
            return WrapList<Service>(Property("relatedServices"))
             .Where(x => x.IsPublished);
        }
    }

    public IList<IPreviewBlock> RelatedWork
    {
        get
        {
            var markets = Markets.Cast<IPreviewBlock>().OrderBy(x => x.PreviewTitle).ToList();
            markets.AddRange(Services.OrderBy(x => x.PreviewTitle));
            return markets;
        }
    }

    public string RelatedWorkHeading
    {
        get { return Parent.Property("relatedWorkHeading"); }
    }
    public IHtmlString Testimonial
    {
        get { return Property<IHtmlString>("testimonialText"); }
    }

    public bool HasTestimonial
    {
        get { return Content.HasValue("testimonialText"); }
    }

    public string TestimonialTitle
    {
        get { return Property("testimonialTitle"); }
    }

    public string TestimonialName
    {
        get { return Property("testimonialName"); }
    }

    public string TestimonialLocation
    {
        get { return Property("testimonialLocation"); }
    }

    public string ClientName
    {
        get { return Property("clientName"); }
    }
    public string ProjectLocation
    {
        get { return Property("projectLocation"); }
    }

    public static IEnumerable<Project> Search(ProjectSearchCriteria criteria)
    {
        var portfolio = Helper.TypedContent(1060);

        var projects = portfolio.Children.Where(x => x.DocumentTypeAlias == "Project");
        if (Website.IsLad && !string.IsNullOrWhiteSpace(criteria.ProjectType))
            projects = projects.Where(x => x.GetPropertyValue<string>("projectType") != null && x.GetPropertyValue<string>("projectType").Split(',').Contains(criteria.ProjectType));
        if (Website.IsLad && !string.IsNullOrEmpty(criteria.SubMarket))
        {
            projects =
                projects.Where(x => x.GetPropertyValue<string>("projectSubMarket").Split(',').Contains(criteria.SubMarket));
        }
        else if (!string.IsNullOrWhiteSpace(criteria.Market))
        {
            projects =
                projects.Where(x => x.GetPropertyValue<string>("projectMarket").Split(',').Contains(criteria.Market));
        }
        if (Website.IsLan && !string.IsNullOrEmpty(criteria.Service))
        {
            projects =
                projects.Where(x => x.GetPropertyValue<string>("relatedServices").Split(',').Contains(criteria.Service));
        }
        return projects.Select(x => new Project(x));
    }



}

public class ProjectSearchCriteria
{
    public string ProjectType { get; set; }
    public string Market { get; set; }
    public string SubMarket { get; set; }
    public string Service { get; set; }
}