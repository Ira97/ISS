using System.Collections.Generic;

namespace ScientificDatabase.Models.TypeObject
{
    public class TypeObject: BaseEntity
    {
        public string Name { set; get; }
        public int Section { set; get; }
        public List<Properties> PropertiesList { set; get; }

        public TypeObject()
        {
            PropertiesList = new List<Properties>();
        }
    }
}