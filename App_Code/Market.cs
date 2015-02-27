using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for Market
/// </summary>
public class Market : PageItem, IPreviewBlock
{
    public Market(IPublishedContent content)
        : base(content)
    {
    }

    public IEnumerable<Project> FeaturedProjects
    {
        get
        {
            return WrapList<Project>(Property("featuredProjects"))
                .Where(x => x.IsPublished);
        }
    }

    public IEnumerable<Project> RelatedProjects
    {
        get
        {
            return WrapList<Project>(Property("relatedProjects"))
                .Where(x => x.IsPublished);
        }
    }




    public string BackgroundImage
    {
        get
        {
            var image = ImageUrlProperty("backgroundImage");
            if (string.IsNullOrEmpty(image))
                return "/images/image-mainbg.jpg";
            return image;
        }
    }

    public string HeroImage
    {
        get { return ImageUrlProperty("sliderImage"); }
    }

    public IEnumerable<Leader> Leaders
    {
        get
        {
            return WrapList<Leader>(Property("leaders"))
               .Where(x => x.IsPublished); 
        }
    }

    public IEnumerable<CallToAction> Outlook
    {
        get
        {
            return WrapList<CallToAction>(Property("outlook"))
               .Where(x => x.IsPublished);  
        }
    } 
    public string Heading
    {
        get { return Helper.ReplaceLineBreaksForHtml(Property("contentTitle")); }
    }

    public Quiz Quiz
    {
        get { return PropertyOfType<Quiz>("quiz"); }
    }

    public string PreviewTitle
    {
        get { return Name; }
    }

    public string PreviewImage
    {
        get
        {
            var project = RandomProject;
            if (project == null)
                return string.Empty;
            return project.Thumbnail;
        }
    }

    private Project RandomProject
    {
        get
        {
            var projects = RelatedProjects.ToList();
            if (!projects.Any())
                return null;
            var randomIndex = new Random().Next(projects.Count() - 1);
            return projects.ElementAt(randomIndex);
        }
    }

    public string PreviewUrl
    {
        get { return "/portfolio?type=Featured&market=" + this.Id; }
    }

    public string RelatedProjectsHeading
    {
        get { return Parent.Property("relatedProjectsHeading"); }
    }


    public static IEnumerable<Market> GetAll()
    {
        var parent = Helper.TypedContent(3930);
        return parent.Children
            .Where(x => x.DocumentTypeAlias == "Market")
            .Select(x => new Market(x))
            .Where(x => x.IsPublished);
    } 
}