using System.Collections.Generic;

namespace Models.Search
{
    public class SearchRequest
    {
        public string Title { get; set; }
        public List<int> SelectedObjectList = new List<int>();
        public List<int> SelectedMethodList = new List<int>();
        public List<int> SelectedThingList = new List<int>();
        public List<int> SelectedPropertyList = new List<int>();
        public List<int> SelectedSectionList = new List<int>();
    }
}
