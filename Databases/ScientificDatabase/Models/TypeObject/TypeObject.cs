using System.Collections.Generic;

namespace ScientificDatabase.Models.TypeObject
{
    public class TypeObject: BaseEntity
    {
        public string Name { set; get; }
        public virtual List<Property> Properties { set; get; } = new List<Property>();
        public virtual List<DataObject> DataObjects { set; get; } = new List<DataObject>();
    }
}