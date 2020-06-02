using HP_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public interface ITerritoryCompanyRepository
    {
        TerritoryCompany GetById(int id);
        IEnumerable<TerritoryCompany> GetAll();
        TerritoryCompany Add(TerritoryCompany apolloRow);
        TerritoryCompany Update(TerritoryCompany apolloRow);
        TerritoryCompany Delete(int id);
    }
}
