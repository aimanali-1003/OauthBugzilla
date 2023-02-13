using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oauth.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }

        public User() 
        {
            UserRoleId = 1; //by default it will 
        }
    }
}