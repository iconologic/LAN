using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for Tag
/// </summary>
public class Category : ContentItem
{
    public Category(IPublishedContent content) : base(content)
    {
    }

    public IEnumerable<Project> Projects
    {
        get
        {
            return WrapList<Project>(Property("projects"));

        }
    }

}