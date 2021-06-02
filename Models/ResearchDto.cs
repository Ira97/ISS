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
        public int SectionId { get; set; }
        /// <summary>
        /// Предмет
        /// </summary>
        public string Thing { get; set; }
        /// <summary>
        /// Объект
        /// </summary>
        public string Object { get; set; }
        /// <summary>
        /// Метод
        /// </summary>
        public string Method { get; set; }
        public List<int> SelectedObjectList { get; set; }
    }
}
