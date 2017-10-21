using System;

namespace SharpPaste
{
	public class Config
	{
		public static string DBPATH = string.Format(@"{0}pastes.db", AppDomain.CurrentDomain.BaseDirectory);

		public static int TOKENLENGTH = 23;
	}
}
