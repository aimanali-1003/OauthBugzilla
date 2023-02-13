using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Oauth.Models
{
    public class DB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Login> Logins { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Bug> Bugs { get; set; }

        public DbSet<UserProject> UserProjects { get; set; }

    }
}