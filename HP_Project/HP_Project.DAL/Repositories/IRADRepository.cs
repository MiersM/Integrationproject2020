using HP_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public interface IRADRepository
    {
        RAD GetById(int id);
        IEnumerable<RAD> GetAll();
        RAD Add(RAD apolloRow);
        RAD Update(RAD apolloRow);
        RAD Delete(int id);
    }
}
