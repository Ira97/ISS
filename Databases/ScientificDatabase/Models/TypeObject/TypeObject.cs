using System.Collections.Generic;

namespace ScientificDatabase.Models.TypeObject
{
    public class TypeObject : BaseEntity
    {
        public string Name { set; get; }
        public int SectionId { set; get; }
        public virtual List<Properties> PropertiesList { set; get; }
        public virtual List<DataObject> DataObjects { set; get; }

        public TypeObject()
        {
            PropertiesList = new List<Properties>();
            DataObjects = new List<DataObject>();
        }
    }
}