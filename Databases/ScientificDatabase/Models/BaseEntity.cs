using ScientificDatabase.Interfaces;

namespace ScientificDatabase.Models
{
    /// <summary>
    /// Базовый элемент базы данных с идентификатором
    /// </summary>
    public class BaseEntity : IBaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
    }
}
