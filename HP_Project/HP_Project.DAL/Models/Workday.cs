using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class Workday
    {
        public int Id { get; set; }
        public int AccountStId { get; set; }
        public string SalesLetterName { get; set; }
        public string FsrPc { get; set; }
        public string IsrPc { get; set; }
        public string PcHunter { get; set; }
    }
}
