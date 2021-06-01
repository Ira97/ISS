using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Search
{
    public class SearchResult
    {
        public string Value { get; set; }
        public List<Entry> EntryList = new List<Entry>();
    }
}
