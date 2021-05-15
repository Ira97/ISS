using System;
using System.Collections.Generic;
using System.Text;

namespace Models.User
{
    public class RegisterUserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
    }
}
