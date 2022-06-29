using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
