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
        public  List<PropertyDto> PropertyDtos { set; get; }
        public  List<DataObjectDto> DataObjectDtos { set; get; }
        public TypeObjectDto()
        {
            PropertyDtos = new List<PropertyDto>();
            DataObjectDtos = new List<DataObjectDto>();
        }
    }
}