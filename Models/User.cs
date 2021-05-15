using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public virtual List<UserRole> Roles { get; set; }
    }
}