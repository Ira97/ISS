using System.Collections.Generic;

namespace ScientificDatabase.Models
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
