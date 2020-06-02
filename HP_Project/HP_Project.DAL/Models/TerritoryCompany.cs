using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class TerritoryCompany
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int AmountDesktop { get; set; }
        public int AmountThinClient { get; set; }
        public int AmountLaptop { get; set; }
        [NotMapped]
        public int AmountPc { get => AmountDesktop + AmountThinClient + AmountLaptop; }
    }
}
