using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        [NotMapped]
        public string Refreshtoken { get; set; }
        [NotMapped]
        public DateTime tokenexpired { get; set; }
        [NotMapped]
        public DateTime tokencreated { get; set; }
    }
}
