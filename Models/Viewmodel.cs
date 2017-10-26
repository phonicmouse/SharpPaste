using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpPaste
{
    public class PasteView
    {
        public int Id { get; set; }
        public string PasteToken { get; set; }
        public int WebViews { get; set; }
        public int JsonHits { get; set; }
    }
}