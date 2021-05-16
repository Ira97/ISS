using System.Collections.Generic;

namespace Models
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public virtual AreaDto Area { set; get; }
    }
}