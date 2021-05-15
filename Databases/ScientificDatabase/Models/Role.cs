using System.Collections.Generic;

namespace ScientificDatabase.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string AltName { get; set; }
        public virtual List<UserRole> Roles { get; set; }
    }
}
