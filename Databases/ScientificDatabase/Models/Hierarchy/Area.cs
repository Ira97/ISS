using System.Collections.Generic;

namespace ScientificDatabase.Models.Hierarchy
{
    /// <summary>
    /// Область науки
    /// </summary>
    public class Area:BaseEntity
    {
        public string Name { set; get; }
        public virtual List<AreaSection> Section { set; get; }
    }
}