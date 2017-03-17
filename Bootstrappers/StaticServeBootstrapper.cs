/*
 * Created by SharpDevelop.
 * User: Phonic Mouse
 * Date: 02/08/2016
 * Time: 17:32
 */
 
using Nancy;
using Nancy.Conventions;

namespace SharpPaste
{
	public class StaticServeBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureConventions(NancyConventions nancyConventions)
		{
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/custom", @"custom")); // Serve custom CSS & JS folder
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/fonts", @"packages\bootstrap.3.3.7\content\fonts")); // Serve bootstrap's fonts folder
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/css/bootstrap.css", @"packages\bootstrap.3.3.7\content\Content\bootstrap.min.css")); // Serve Bootstrap CSS
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/css/bootstrap-flat.css", @"packages\Bootstrap.flat.3.3.4\content\Content\bootstrap-flat.min.css")); // Serve Bootstrap Flat Theme CSS
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/js/bootstrap.js", @"packages\bootstrap.3.3.4\content\scripts\bootstrap.min.js")); // Serve Bootstrap JS
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/js/jquery.js", @"packages\jquery.3.1.1\content\scripts\jquery-3.1.1.min.js")); // Serve jQuery
			base.ConfigureConventions(nancyConventions);
		}
	}
}
