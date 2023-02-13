using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oauth.Models
{
    public class UserProject
    {

        [Key]
        [Column(Order =1)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProjectId { get; set; }
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}