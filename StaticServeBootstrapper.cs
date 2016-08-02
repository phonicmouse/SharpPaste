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
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Static", @"Static"));
			base.ConfigureConventions(nancyConventions);
		}
	}
}
