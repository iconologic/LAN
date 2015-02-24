using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProjectSlider
/// </summary>
public class ProjectSlider
{
	public ProjectSlider()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Heading { get; set; }

    public IEnumerable<Project> Projects { get; set; } 
}