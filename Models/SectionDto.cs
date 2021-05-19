using System;
using System.Collections.Generic;

namespace Models
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public int ParentId { set; get;}
        public int AreaId { set; get;}
        public DateTime UpdateDateTime { get; set; }
        public string Description { get; set; }
    }
}