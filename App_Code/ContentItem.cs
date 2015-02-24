using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using umbraco.providers.members;
using Umbraco.Web;

/// <summary>
/// Summary description for ContentItem
/// </summary>
public class ContentItem
{

    public ContentItem(IPublishedContent content)
    {
        Content = content;
    }




    [JsonIgnore]
    protected IPublishedContent Content;

    [JsonProperty]
    public string Name
    {
        get { return Content.Name; }
    }

    public virtual string HtmlId
    {
        get
        {
           
            return Name.ToLower().Replace(' ', '-').Replace("-&-", "-");
        }
    }

    public int Id
    {
        get { return Content.Id; }
    }

    protected bool Equals(ContentItem other)
    {
        if (Content == null)
            return false;
        return this.Id == other.Id;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ContentItem) obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }


    protected T Property<T>(string alias) 
    {
        var property = Content.GetProperty(alias);
        if (property == null || !property.HasValue)
            return default (T);
        return (T) property.Value;
    }

    internal protected string Property(string alias)
    {
        return Property<string>(alias);
    }

    internal protected T PropertyOfType<T>(string alias) where T : ContentItem
    {
        var id = Property<int>(alias);
        if (id <= 0)
            return default(T);

        var content = Helper.TypedContent(id);
        return Wrap<T>(content);
    }

    public IEnumerable<T> Children<T>() where T:ContentItem
    {
        return Content.Children
            .Select(Wrap<T>);
    }

    public IEnumerable<T> Children<T>(string docTypeAlias) where T : ContentItem
    {
        return Content.Children.Where(x => x.DocumentTypeAlias == docTypeAlias)
            .Select(Wrap<T>);
    }

    public IEnumerable<PageItem> ChildPages
    {
        get
        {
            return Content.Children
           .Select(CreatePageItem).Where(x => x.IsPublished);
        }
    }

    public IEnumerable<PageItem> ChildPagesForNavigation
    {
        get { return ChildPages.Where(x => x.ShowInNavigation); }
    } 

    public IEnumerable<T> GetGroup<T>(IList<T> items, int col, int totalCols)
    {
        var take = items.Count() / totalCols;
        if (col != totalCols - 1 && items.Count() % totalCols > 0)
            take++;
        var skip = col * take;
        return items.Skip(skip).Take(take);
    }

    protected IEnumerable<RelatedLink> RelatedLinks(string alias)
    {
        var links = new List<RelatedLink>();
        if (!Content.HasProperty(alias))
            return links;

        var relatedLinks = Content.AsDynamic().GetPropertyValue(alias);
        foreach (var relatedLink in relatedLinks)
        {
            links.Add(new RelatedLink(){Caption = relatedLink.caption, Url = relatedLink.link, OpenInNewWindow = relatedLink.newWindow});
        }
        return links;
    } 


    protected T Wrap<T>(IPublishedContent content) where T : ContentItem
    {
        return (T) Activator.CreateInstance(typeof(T), content);
    }

    protected IEnumerable<T> WrapList<T>(string idString) where T : ContentItem
    {
        if (String.IsNullOrWhiteSpace(idString))
            return new List<T>();
        var ids = idString.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
        return ids.Select(id => Helper.TypedContent(id))
            .Where(content => content != null && content.Id != 0)
            .Select(Wrap<T>);
    }

    protected string ImageUrl(int mediaId)
    {
        if (mediaId <= 0)
            return String.Empty;
        var media = Helper.TypedMedia(mediaId);
        if (media == null)
            return String.Empty;
        return media.Url;
    }

    protected string ImageUrlProperty(string propertyAlias)
    {
        return ImageUrl(Property<int>(propertyAlias));
    }

    protected IEnumerable<string> ImageUrlsProperty(string propertyAlias)
    {
        var idString = Property(propertyAlias);
        var ids = idString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        return ids.Select(x => ImageUrl(int.Parse(x)));
    }

    protected IEnumerable<PublishedMedia> MultipleMediaProperty(string alias)
    {
        var idString = Property(alias);
        if (string.IsNullOrEmpty(idString))
            return new List<PublishedMedia>();
        var ids = idString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        return ids.Select(x => new PublishedMedia(Helper.TypedMedia(x)));
    }

    public ContentItem Parent
    {
        get { return Wrap<ContentItem>(Content.Parent); }
    }

    public PageItem ParentPage
    {
        get { return CreatePageItem(Content.Parent); }
    }

    public virtual string Url
    {
        get { return Content.Url; }
    }

    public bool IsPublished
    {
        get { return Id > 0; }
    }

    public string ChildPageUrl(string docType)
    {
        var page = Content.Children.FirstOrDefault(x => x.DocumentTypeAlias == docType);
        if (page == null)
            return String.Empty;
        return page.Url;
    }

    protected IContentService ContentService
    {
        get
        {
            return ApplicationContext.Current.Services.ContentService;
        }
    }

    public static UmbracoHelper Helper
    {
        get
        {
            return new UmbracoHelper(UmbracoContext.Current); 
        }
        
    }

    public virtual bool ShowChildrenInNavigation
    {
        get { return true; }
    }

    public virtual bool ShowInNavigation
    {
        get
        {
            if (Content.HasValue("hideFromNavigation"))
                return !Property<bool>("hideFromNavigation");
            return true;
        }
    }
    protected virtual string DocumentTypeAlias
    {
        get { return null; }
    }

    protected static PageItem CreatePageItem(IPublishedContent content)
    {
        switch (content.DocumentTypeAlias)
        {
            case "Story": return new Story(content);
            case "Leader": return new Leader(content);
            case "LeaderCategory":
                return new LeaderCategory(content);
            case "Press": return new PressPage(content);
            case "CareerOpportunities":
                return new OpportunitiesPage(content);
            case "Services":
                return new ServicesPage(content);
            case "Community":
                return new CommunityPage(content);
            case "Service":
                return new Service(content);
            case "CommunityStory":
                return new CommunityStory(content);
            case "About":
                return new AboutPage(content);
            case "People":
                return new PeoplePage(content);
            case "Culture":
                return new CulturePage(content);
            case "PeopleFolder":
                return new PeopleFolder(content);
            case "FaqTopic":
                return new FaqTopic(content);
            default:
                return new PageItem(content);
        }
    }
}