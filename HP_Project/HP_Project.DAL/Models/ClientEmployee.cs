using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class ClientEmployee
    {
        public int Id { get; set; }
        public int SalesTerritoryId { get; set; }
        public string SalesTerritoryName { get; set; }
        public int AmountEmployee { get; set; }
        public double ITspendByYear { get; set; }
        [NotMapped]
        public double ITspendByEmployee { get => ITspendByYear/AmountEmployee; }
    }
}
