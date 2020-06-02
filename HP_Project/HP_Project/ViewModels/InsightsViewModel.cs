using HP_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Project.ViewModels
{
    public class InsightsViewModel
    {
        public IEnumerable<Insight> Insights { get; set; }

        public string Text { get; set; }
        public string Client { get; set; }

        public DateTime? Date { get; set; }
    }
}
