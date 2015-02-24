using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for SubMarket
/// </summary>
public class SubMarket : ContentItem, IPreviewBlock
{
    public SubMarket(IPublishedContent content)
        : base(content)
    {
    }

    public IEnumerable<Project> RelatedProjects
    {
        get
        {
            return WrapList<Project>(Property("projects"))
                .Where(x => x.IsPublished);
        }
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
        get { return "/portfolio?type=Featured&submarket=" + this.Id; }
    }
}