using System.Collections.Generic;

namespace ScientificDatabase.Models.Hierarchy
{
    /// <summary>
    /// Раздел науки 
    /// </summary>
    public class Section: BaseEntity
    {
        public string Name { set; get; }
         public virtual List<AreaSection> Area { set; get; }
    }
}