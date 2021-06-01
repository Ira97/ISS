using System;
using System.Collections.Generic;

namespace ScientificDatabase.Models.Hierarchy
{
    /// <summary>
    /// Раздел науки 
    /// </summary>
    public class Section : BaseEntity
    {
        public string Name { set; get; }
        public string Description { get; set; }
        public DateTime? UpdateDateTime {get;set;}
        public virtual Area Area { set; get; }
        public int AreaId { set; get;}
        public int ParentId { set; get;}
        public  virtual List<TypeObject.TypeObject> TypeObjects { set; get; }
        public virtual ICollection<Research> Researches { set; get; }
    }
    
}