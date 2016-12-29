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
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/css", @"Content"));
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/css", @"Content"));
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/fonts", @"Fonts"));
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/js", @"Scripts"));
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/custom", @"Custom"));
			base.ConfigureConventions(nancyConventions);
		}
	}
}
