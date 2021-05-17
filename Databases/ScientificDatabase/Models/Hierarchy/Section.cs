using System.Collections.Generic;

namespace ScientificDatabase.Models.Hierarchy
{
    /// <summary>
    /// Раздел науки 
    /// </summary>
    public class Section: BaseEntity
    {
        public string Name { set; get; }
        public virtual Area Area { set; get; }
        public int AreaId { get; set; }
        public int ParentId { set; get; }
        public virtual List<TypeObject.TypeObject> TypeObjects { get; set; }
    }
}