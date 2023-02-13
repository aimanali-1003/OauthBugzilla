using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oauth.Models
{
    public enum Status
    {
        New,
        Started,
        Completed,
        Resolved
    }

    public enum Field
    {
        Feature,
        Bug
    }
    public class Bug
    {
        public int BugId { get; set; }
        public string title { get; set; }

        [Required]
        public Status status { get; set; }

        [Required]
        public Field type { get; set; }

        [Display(Name = "Date of birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime deadline { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }

        public int ProjectId { get; set; }
        public virtual Project project { get; set; }
    }
}