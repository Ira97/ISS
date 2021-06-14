using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Search
{
    public class SearchResult
    {
        public string Value { get; set; }
        public List<Entry> EntryList = new List<Entry>();
        public SearchRequest SearchRequest = new SearchRequest();
        public List<DataObjectDto> DataObjectList { get; set; }
        public List<MethodDto> MethodList { get; set; }
        public List<DataObjectDto> ThingList { get; set; }
        public List<PropertyDto> PropertyList { get; set; }
        public List<SectionDto> SectionList { get; set; }
    }
}
