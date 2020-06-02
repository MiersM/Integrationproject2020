using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class Insight
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public DateTime? Date { get; set; }

        public string Client { get; set; }
    }
}
