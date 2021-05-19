using System.Collections.Generic;

namespace ScientificDatabase.Models.TypeObject
{
    public class DataObject: BaseEntity
    {
        public string Name{set; get; }
        public virtual TypeObject TypeObject { set; get; }
        public List<ValuePropertyObject> ValuePropertyObjects { get; set; }
    }
}