using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oauth.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string RoleName { get; set; } 
        public List<User> Users { get; set; } // one to many relationship
    }
}