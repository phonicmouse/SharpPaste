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
		public static string DBPATH = string.Format(@"{0}db\Pastes.db", AppDomain.CurrentDomain.BaseDirectory);
		//public static string DBPATH = @"C:\Users\Leonardo\Documents\GitHub\SharpPaste\bin\Pastes.db";
		
		///----Paste Config----///
		public static int TOKENLENGTH = 23;
	}
}
