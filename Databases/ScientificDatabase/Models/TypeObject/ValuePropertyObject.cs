namespace ScientificDatabase.Models.TypeObject
{
    public class ValuePropertyObject: BaseEntity
    {
        public virtual  DataObject DataObject { set; get; }
        public  virtual Property Property { set; get; }
        public string Value { set; get; }
    }
}