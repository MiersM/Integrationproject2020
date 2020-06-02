using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Project.ViewModels
{
    public class ApolloEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IndustrySegment { get; set; }
        public string IndustryVertical { get; set; }
        public int AccountSTID { get; set; }
        public string AccountSTName { get; set; }

        public int TopParentSTID { get; set; }
        public string TopParentSTName { get; set; }

        public int OrganizationID { get; set; }
        public int OPSIID { get; set; }
        public string PRMID { get; set; }
        public int BusinessRelationshipID { get; set; }
        public string TaxIdentifier { get; set; }
    }
}
