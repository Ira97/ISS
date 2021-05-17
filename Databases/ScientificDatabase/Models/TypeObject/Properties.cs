using System.Collections.Generic;

namespace ScientificDatabase.Models.TypeObject
{
    public class Properties: BaseEntity
    {
        public string Name { set; get; }
        public virtual List<ValuePropertiesObject> ValueProperties { set; get; } 
        public virtual List<TypeObject> TypeObjects { set; get; }

        public Properties()
        {
            TypeObjects = new List<TypeObject>();
        }
    }
}