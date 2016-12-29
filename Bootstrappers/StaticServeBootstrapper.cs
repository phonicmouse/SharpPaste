/*
 * Created by SharpDevelop.
 * User: Phonic Mouse
 * Date: 02/08/2016
 * Time: 17:32
 */
using System;
using Nancy;
using Nancy.Conventions;

namespace SharpPaste
{
	public class StaticServeBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureConventions(NancyConventions nancyConventions)
		{
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/custom", @"Custom")); // Serve custom CSS & JS folder
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/fonts", @"packages\bootstrap.3.3.4\content\fonts")); // Serve bootstrap's fonts folder
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/js/jquery.js", @"packages\jQuery.3.1.1\Content\Scripts\jquery-3.1.1.min.js")); // Serve jQuery
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/js/jquery.js", @"packages\jQuery.3.1.1\Content\Scripts\jquery-3.1.1.min.js"));
			base.ConfigureConventions(nancyConventions);
		}
	}
}
