using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Contact> Contacts { get; set; }
        public IList<Touchpoint> Touchpoints { get; set; }
    }
}
