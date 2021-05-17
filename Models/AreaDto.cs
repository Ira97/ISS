using System.Collections.Generic;
using ScientificDatabase.Models.Hierarchy;

namespace Models
{
    public class AreaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<SectionDto> Section { set; get; }
        public string ImageName { get; set; }
    }
}