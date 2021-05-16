namespace ScientificDatabase.Models.TypeObject
{
    public class ValuePropertiesObject: BaseEntity
    {
        public int ObjectId { set; get; }
        public  int PropertiesId { set; get; }
        public string Value { set; get; }
    }
}