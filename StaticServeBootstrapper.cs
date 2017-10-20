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
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/css/bootstrap.css", @"packages\bootstrap.3.3.7\content\Content\bootstrap.min.css")); 
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/css/bootstrap-flat.css", @"packages\Bootstrap.Flat.3.3.4\Content\Content\bootstrap-flat.min.css")); 
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/js/bootstrap.js", @"packages\bootstrap.3.3.7\content\Scripts\bootstrap.min.js")); 
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/js/jquery.js", @"packages\jQuery.3.2.1\Content\Scripts\jquery-3.2.1.min.js")); 
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/js", @"Custom\js")); 
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/css", @"Custom\css")); 
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/fonts", @"packages\bootstrap.3.3.7\content\fonts")); 
			base.ConfigureConventions(nancyConventions);
		}
	}
}
