using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LAD.Object
{
	/// <summary>
	/// Summary description for ProjectLite
	/// </summary>
	[Serializable]
	public class ProjectLite
	{
		public string Image { get; set; }
		public string Url { get; set; }
		public string Name { get; set; }
		public ProjectLite()
		{
			this.Image = string.Empty;
			this.Url = string.Empty;
			this.Name = string.Empty;
		}
	}
}