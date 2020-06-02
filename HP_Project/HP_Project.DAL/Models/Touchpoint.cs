using System;

namespace HP_Project.DAL.Models
{
    public class Touchpoint
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SortOfEvent { get; set; }
        public string Description { get; set; }
        public DateTime Reminder { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
