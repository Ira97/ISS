using ScientificDatabase.Models.TypeObject;
using System.Collections.Generic;

namespace Models
{
    public class DataObjectDto
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public virtual TypeObjectDto TypeObjectDto { set; get; }
        public List<ValuePropertyObjectDto> ValuePropertyObjectDtos { get; set; }
    }
}