using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IPreviewBlock
/// </summary>
public interface IPreviewBlock
{
     string PreviewTitle { get; }
     string PreviewImage { get; }
     string PreviewUrl { get; }
}