using HP_Project.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HP_Project.ViewModels
{
    public class HomeIndexViewModel
    {
        public ApolloRow apolloRow { get; set; }
        public ClientEmployee clientEmployee { get; set; }
        public InstallBase installBase { get; set; }
        //public ProductHierarchy productHierarchy { get; set; }
        public RAD rAD { get; set; }
        public RevenueActuals revenueActuals { get; set; }
        public TerritoryCompany territoryCompany { get; set; }
        //public Workday workday { get; set; }

        public int MaxDesktop { get => 0; }

        public IEnumerable<SelectListItem> ApolloFilterItems { get; set; }
    }
}
