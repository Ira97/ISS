using System.Collections.Generic;
using ScientificDatabase.Models.TypeObject;

namespace Models
{
    public class TypeObjectDto
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public int SectionId { set; get; }
        public  int TypeObjectId { set; get; }
        public  List<PropertyDto> Properties { set; get; }
        public  List<DataObjectDto> DataObjects{ set; get; }
        public TypeObjectDto()
        {
            Properties = new List<PropertyDto>();
            DataObjects = new List<DataObjectDto>();
        }
    }
}