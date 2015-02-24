using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for MediaKit
/// </summary>
public class MediaKit : PageItem
{
    public MediaKit(IPublishedContent content) : base(content)
    {
    }

    public string Heading
    {
        get { return Helper.ReplaceLineBreaksForHtml(Property("heading")); }
    }

    public string Heading2
    {
        get { return Property("heading2"); }
    }
    public string RecognitionHeading    
    {
        get { return Property("recognitionHeading"); }
    }
    public IHtmlString Copy
    {
        get { return Property<IHtmlString>("copy"); }
    }
    public IHtmlString RecognitionColumn1
    {
        get { return Property<IHtmlString>("recognitionColumn1"); }
    }
    public IHtmlString RecognitionColumn2
    {
        get { return Property<IHtmlString>("recognitionColumn2"); }
    }

    public override string MastHeadImage
    {
        get { return ImageUrlProperty("heroImage"); }
    }

    public IEnumerable<PublishedMedia> Downloads
    {
        get { return MultipleMediaProperty("downloads").OrderBy(x => x.Title); }
    }

    public IEnumerable<PublishedMedia> DownloadsForColumn1
    {
        get
        {
            var take = Downloads.Count()/2;
            if (Downloads.Count()%2 > 0)
                take++;
            return Downloads.Take(take);
        }
    }

    public IEnumerable<PublishedMedia> DownloadsForColumn2
    {
        get
        {
            var skip = Downloads.Count() / 2;
            if (Downloads.Count() % 2 > 0)
                skip++;
            return Downloads.Skip(skip); 
        }
    } 

    public string DownloadInstructions
    {
        get { return Property("downloadInstructions"); }
    }
}