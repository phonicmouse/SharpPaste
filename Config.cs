/*
 * Created by SharpDevelop.
 * User: Phonic Mouse
 * Date: 02/08/2016
 * Time: 15:16
 */
using System;

namespace SharpPaste
{
	public class Config
	{
		///----Application Config----///
		public static string HOSTINGTYPE = "ASP.NET"; //TODO: Add self-hosting support
		public static string DBPATH = string.Format(@"{0}Pastes.db", AppDomain.CurrentDomain.BaseDirectory);
		
		///----Paste Config----///
		public static int TOKENLENGTH = 23;
	}
}
