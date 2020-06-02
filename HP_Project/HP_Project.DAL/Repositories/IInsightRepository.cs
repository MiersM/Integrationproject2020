using HP_Project.DAL.Models;
using System.Collections.Generic;

namespace HP_Project.DAL.Repositories
{
    public interface IInsightRepository
    {
        IEnumerable<Insight> GetAll();
        Insight Add(Insight insight);
    }
}