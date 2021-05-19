using ScientificDatabase.Models.TypeObject;

namespace Models
{
    public class ValuePropertyObjectDto
    {
        public int Id { get; set; }
        public int DataObjectId { get; set; }
        public int  PropertyId { set; get; }
        public virtual PropertyDto Property { set; get; }
        public string Value { set; get; }
    }
}