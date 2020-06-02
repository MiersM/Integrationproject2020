using HP_Project.DAL.Models;
using HP_Project.ViewModels.ContactInfo;
using System.Collections.Generic;

namespace HP_Project.ViewModels
{
    public class ContactInfoViewModel
    {
        public List<Contact> Contacts { get; set; }
        public List<Touchpoint> Touchpoints { get; set; }
    }
}
