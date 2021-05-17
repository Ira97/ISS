using System.Collections.Generic;
using Models.ViewModels;
using ScientificDatabase.Models.TypeObject;

namespace Models
{
    public class TypeObjectDto
    {
        public string Name { set; get; }
        public int SectionId { set; get; }
        public  List<PropertyDto> PropertyDtos { set; get; } = new List<PropertyDto>();
        public  List<DataObjectDto> DataObjectDtos { set; get; } = new List<DataObjectDto>();
    }
}