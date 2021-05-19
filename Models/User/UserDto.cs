using System.Collections.Generic;

namespace Models.User
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public virtual RoleDto Role { get; set; }
    }
}