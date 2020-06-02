using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class InstallBase
    {
        public int Id { get; set; }
        public int SalesTerritoryId { get; set; }
        public IEnumerable<TerritoryCompany> Companies { get; set; }

        // just to make pie chart work atm
        public int Dell { get; set; }
        public int Apple { get; set; }
        public int Hp { get; set; }
        public int Samsung { get; set; }
        public int Msi { get; set; }
    }
}
