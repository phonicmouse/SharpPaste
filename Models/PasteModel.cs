using System;

namespace SharpPaste
{
    public class Paste
	{
	    public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LongId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public string Language { get; set; }
	}
}
