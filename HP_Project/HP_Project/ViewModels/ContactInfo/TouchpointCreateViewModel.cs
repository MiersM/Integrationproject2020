using HP_Project.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Project.ViewModels.ContactInfo
{
    public class TouchpointCreateViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SortOfEvent { get; set; }
        public string Description { get; set; }
        public DateTime Reminder { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<SelectListItem> ContactItems { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
