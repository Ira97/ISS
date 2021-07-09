using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ContactViewModel
    {
        public int ResearchId { get; set; }
        public int SelectedObject { get; set; }
        public int SelectedContact { get; set; }
        public int SelectedSection { get; set; }
        public List<DataObjectDto> DataObjectList { get; set; }
        public List<DataObjectDto> SecondDataObjectList { get; set; }
        public List<SectionDto>  SectionList { get; set; }
        public List<ContactTypeDto> ContactList { get; set; }
    }
}