using System;

namespace SharpPaste
{
    public class Paste
	{
	    private int _webViews = 0;
	    private int _jsonHits = 0;
	    private string _uploadedBy = "API"; // Possible values are: "API", "WEB", "CLI".
	    public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LongId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public string Language { get; set; }
	    public int WebViews
	    {
	        get { return _webViews; }
	        set { _webViews = value; }
	    }
	    public int JsonHits
	    {
	        get { return _jsonHits; }
	        set { _jsonHits = value; }
	    }
	    public string UploadedBy
	    {
	        get { return _uploadedBy; }
	        set { _uploadedBy = value; }
	    }
	}
}
