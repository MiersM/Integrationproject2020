using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class RAD
    {
        public int Id { get; set; }
        public int AccountStId { get; set; }
        public string SalesLetterName { get; set; }
        public string TopSalesTerritoryName { get; set; }
        public string CustSegCode { get; set; }
        public string PcFrameName { get; set; }
        public string PcFrameRadFinal { get; set; }
        public double PcTam { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Vertical { get; set; }
        public double HpSow { get; set; }
    }
}
