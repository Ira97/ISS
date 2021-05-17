using System.Collections.Generic;

namespace ScientificDatabase.Models.TypeObject
{
    public class Property: BaseEntity
    {
        public string Name { set; get; }
        public virtual ICollection<TypeObject> TypeObjects { set; get; } = new List<TypeObject>();
        public virtual ICollection<ValuePropertyObject> ValuePropertyObjects { set; get; }
    }
}