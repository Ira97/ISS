using System.Collections.Generic;

namespace ScientificDatabase.Models.Hierarchy
{
    /// <summary>
    /// Область науки
    /// </summary>
    public class Area:BaseEntity
    {
        public string Name { set; get; }
        public virtual List<Section> Section { set; get; }
        public string ImageName { get; set; }
        public Area()
        {
            Section = new List<Section>();
        }
    }
}