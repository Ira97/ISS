using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class SectionViewModel
    {
        public int ParentId { get; set; }
        public SectionDto Section { get; set; }
    }
}
