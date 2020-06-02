using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public bool Mkt { get; set; }
        public string CIOCircle { get; set; }
        public bool InnovationForum { get; set; }
        public bool TAC { get; set; }
        public string PostalAddress { get; set; }
        public string Comments { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IList<Touchpoint> Touchpoints { get; set; }
    }
}
