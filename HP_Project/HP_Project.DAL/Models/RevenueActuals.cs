using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class RevenueActuals
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Quarter { get; set; }
        public int Month { get; set; }
        public string Country { get; set; }
        public string SubBusinessGroupL3 { get; set; }
        public string BusinessUnitL5 { get; set; }
        public string Ba { get; set; }
        public string SalesChannelName { get; set; }
        public string FulfillmentModel { get; set; }
        public string PsoacMcCode { get; set; }
        public string EndCustomerName { get; set; }
        public string Amid2Customer { get; set; }
        public string ClassCode { get; set; }
        public double RevKSadj { get; set; }
        public double CosKSadj { get; set; }
        public int Units { get; set; }
        public int DealId { get; set; }
        public string Dataflow { get; set; }

    }
}
