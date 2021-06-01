using ScientificDatabase.Models.TypeObject;
using System.Collections.Generic;

namespace Models
{
    public class ResearchDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public List<DataObjectDto> DataObjects { get; set; }
    }
}
