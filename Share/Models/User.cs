using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using paneleo.Share.ModelsDto;

namespace paneleo.Share.Models
{
    public class User : IdentityUser
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override string Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsDeleted { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
