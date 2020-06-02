using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Models
{
    public class ApolloRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNameLatin { get; set; }
        public AccountType AccountType { get; set; }
        public AccountSubType AccountSubType { get; set; }
        public Status Status { get; set; }
        public string IndustrySegment { get; set; }
        public string IndustryVertical { get; set; }
        public BusinessRelationshipType MyProperty { get; set; }
        public String City { get; set; }
        public String Province { get; set; } //of State
        public String Country { get; set; }
        public String SubRegion1 { get; set; }
        public String Region { get; set; }
        public bool PrivateAccount { get; set; }
        public int AccountSTID { get; set; }
        public String AccountSTName { get; set; }
        public int? TopParentSTID { get; set; }
        public String TopParentSTName { get; set; }
        public int PartialAccountSTID { get; set; }
        public String PartialAccountSTName { get; set; }
        public int OrganizationID { get; set; }
        public int OPSIID { get; set; }
        public String PRMID { get; set; }
        public int BusinessRelationshipID { get; set; }
        public String TaxIdentifier { get; set; }
    }
}
