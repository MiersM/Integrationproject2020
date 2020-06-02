using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class ProductHierarchy
    {
        public int Id { get; set; }
        public String BaCode { get; set; }
        public String PlCode { get; set; }
        public string L6Description { get; set; }
        public string L5Description { get; set; }
        public string L4Description { get; set; }
        public string L3Description { get; set; }
        public string L2Description { get; set; }
    }
}
