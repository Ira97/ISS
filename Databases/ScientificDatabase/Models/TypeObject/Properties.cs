using System.Collections.Generic;

namespace ScientificDatabase.Models.TypeObject
{
    public class Properties: BaseEntity
    {
        public string Name { set; get; }
        public List<TypeObject> TypeObjects { set; get; }

        public Properties()
        {
            TypeObjects = new List<TypeObject>();
        }
    }
}