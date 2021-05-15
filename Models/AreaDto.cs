using System.Collections.Generic;

namespace Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<AreaSection> Section { set; get; }
    }
}