using System.Collections.Generic;

namespace ScientificDatabase.Models.TypeObject
{
    public class Property: BaseEntity
    {
        public string Name { set; get; }
        public virtual List<TypeObject> TypeObjects { set; get; } = new List<TypeObject>();
        public virtual List<ValuePropertyObject> ValuePropertyObjects { set; get; } = new List<ValuePropertyObject>();
    }
}