using System.Collections.Generic;

namespace Models.ViewModels
{
    public class ResearchViewModel
    {
        public List<DataObjectDto> DataObjectList { get; set; }
        public int AdvancedPropertyCount { get; set; }
        public int SectionId { get; set; }
        public ResearchDto Research { get; set; }
    }
}
