using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace paneleo.Share.Models
{
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override string Id { get; set; }
        //public virtual List<ApplicationUserProject> UserProjects { get; set; }
        public bool IsDeleted { get; set; }
        public string ProfilePhoto { get; set; }
        //public List<Notification> Notifications { get; set; }
    }
}
