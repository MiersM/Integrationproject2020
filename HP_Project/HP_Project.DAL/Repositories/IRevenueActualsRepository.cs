using HP_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public interface IRevenueActualsRepository
    {
        RevenueActuals GetById(int id);
        IEnumerable<RevenueActuals> GetAll();
        RevenueActuals Add(RevenueActuals apolloRow);
        RevenueActuals Update(RevenueActuals apolloRow);
        RevenueActuals Delete(int id);
    }
}
