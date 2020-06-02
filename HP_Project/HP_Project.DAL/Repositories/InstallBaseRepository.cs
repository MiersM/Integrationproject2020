using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public class InstallBaseRepository : IInstallBaseRepository
    {
        private readonly AppDbContext _context;

        public InstallBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<InstallBase> GetAll()
        {
            return _context.InstallBase;
        }

        public InstallBase GetById(int id)
        {
            return _context.InstallBase.Find(id);
        }

        public InstallBase Add(InstallBase installBase)
        {
            var newInstallBase = _context.InstallBase.Add(installBase);

            if (newInstallBase != null && newInstallBase.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newInstallBase.Entity;
                }
            }

            return null;
        }

        public InstallBase Update(InstallBase installBase)
        {
            var newInstallBase = _context.InstallBase.Update(installBase);

            if (newInstallBase != null && newInstallBase.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newInstallBase.Entity;
                }
            }

            return null;
        }

        public InstallBase Delete(int id)
        {
            var installBase = _context.InstallBase.Find(id);

            if (installBase != null)
            {
                var deletedInstallBase = _context.InstallBase.Remove(installBase);

                if (deletedInstallBase != null && deletedInstallBase.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedInstallBase.Entity;
                    }
                }
            }

            return null;
        }
    }
}
