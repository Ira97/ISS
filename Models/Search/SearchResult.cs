using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Search
{
    public class SearchResult
    {
        public string Value { get; set; }
        public List<Entry> EntryList = new List<Entry>();
        public bool SectionSearch { get; set; }
        public bool DataObjectSearch { get; set; }
        public bool ResearchSearch { get; set; }
        public bool MethodSearch { get; set; }
        public bool PropertySearch { get; set; }
        public bool AuthorSearch { get; set; }
        public bool ThingSearch { get; set; }
    }
}
