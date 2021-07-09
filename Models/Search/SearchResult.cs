using System.Collections.Generic;

namespace Models.Search
{
    public class SearchResult
    {
        public string Value { get; set; }
        public List<Entry> EntryList = new List<Entry>();
        public List<SectionDto> SectionList { get; set; }
        public List<ContactTypeDto> ContactList { get; set; }
        public List<ContactTypeDto> SecondContactList { get; set; }
        public List<MethodDto> MethodList { get; set; }
        public int SelectedMethod { get; set; }
        public int SelectedSection { get; set; }
        public int SelectedContact { get; set; }
        public bool ResearchSearch { get; set; }
        public bool MethodSearch { get; set; }
        public bool PropertySearch { get; set; }
        public bool AuthorSearch { get; set; }
        public bool ThingSearch { get; set; }
        public List<Entry> SecondEntryList { get; set; }
        public List<Entry> ThirdEntryList { get; set; }
    }
}
