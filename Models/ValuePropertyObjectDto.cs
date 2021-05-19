using ScientificDatabase.Models.TypeObject;

namespace Models
{
    public class ValuePropertyObjectDto
    {
        public int Id { get; set; }
        public virtual PropertyDto Property { set; get; }
        public string Value { set; get; }
    }
}