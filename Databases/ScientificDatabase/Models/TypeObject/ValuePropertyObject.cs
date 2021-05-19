namespace ScientificDatabase.Models.TypeObject
{
    public class ValuePropertyObject: BaseEntity
    {
        public virtual  DataObject DataObject { set; get; }
        public  virtual Property Property { set; get; }
        public int  PropertyId { set; get; }
        public int DataObjectId { get; set; }
        public string Value { set; get; }
    }
}