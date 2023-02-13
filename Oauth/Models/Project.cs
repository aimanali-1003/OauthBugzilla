using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oauth.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }

    }
}