using System.Collections.Generic;
using ScientificDatabase.Models.Hierarchy;

namespace ScientificDatabase.Models.TypeObject
{
    public class TypeObject: BaseEntity
    {
        public string Name { set; get; }
        public virtual Section Section { set; get; }
        public int SectionId { set; get; }
        public virtual List<Property> Properties { set; get; } = new List<Property>();
        public virtual List<DataObject> DataObjects { set; get; } = new List<DataObject>();
    }
}