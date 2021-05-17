using System.Collections.Generic;

namespace ScientificDatabase.Models.TypeObject
{
    public class TypeObject: BaseEntity
    {
        public string Name { set; get; }
        public int SectionId { set; get; }
        public virtual ICollection<Property> Properties { set; get; } = new List<Property>();
    }
}