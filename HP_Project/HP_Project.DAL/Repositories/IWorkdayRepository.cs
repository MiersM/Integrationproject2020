using HP_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public interface IWorkdayRepository
    {
        Workday GetById(int id);
        IEnumerable<Workday> GetAll();
        Workday Add(Workday apolloRow);
        Workday Update(Workday apolloRow);
        Workday Delete(int id);
    }
}
