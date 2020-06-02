using HP_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public interface IInstallBaseRepository
    {
        InstallBase GetById(int id);
        IEnumerable<InstallBase> GetAll();
        InstallBase Add(InstallBase apolloRow);
        InstallBase Update(InstallBase apolloRow);
        InstallBase Delete(int id);
    }
}
