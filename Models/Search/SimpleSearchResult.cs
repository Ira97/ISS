using System.Collections.Generic;

namespace Models.Search
{
    public class SimpleSearchResult
    {
        public string Value { get; set; }
        public List<Entry> EntryList = new List<Entry>();
    }
}
