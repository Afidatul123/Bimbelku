using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public Roles Roles { get; set; }
    }

    public class UserDashboard
    {
        public List<User> user { get; set; }
        public List<Roles> roles { get; set; }
        public UserDashboard()
        {
            user = new List<User>();
            roles = new List<Roles>();
        }
    }
}
