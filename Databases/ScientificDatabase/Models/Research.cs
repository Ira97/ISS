using ScientificDatabase.Models.Hierarchy;
using ScientificDatabase.Models.TypeObject;
using System.Collections.Generic;

namespace ScientificDatabase.Models
{
    public class Research : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
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
        public ICollection<DataObject> DataObjects { get; set; }
        public Section Section { get; set; }
    }
}
