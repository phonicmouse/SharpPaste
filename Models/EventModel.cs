using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpPaste
{
    public class Event
    {
        public int      Id        { get; set; }
        public string   LongId    { get; set; }
        public DateTime Timestamp { get; set; }
        public string   Name      { get; set; }
        public string   Data      { get; set; }
    }
}