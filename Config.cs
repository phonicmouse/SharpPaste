using System;

namespace SharpPaste
{
	public class Config
	{
		public static string DBPATH = string.Format(@"{0}Databases/Paste.db", AppDomain.CurrentDomain.BaseDirectory);
        public static string METADBPATH = string.Format(@"{0}Databases/Meta.db", AppDomain.CurrentDomain.BaseDirectory);
    }
}
