using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public class RADRepository : IRADRepository
    {
        private readonly AppDbContext _context;

        public RADRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<RAD> GetAll()
        {
            return _context.RAD;
        }

        public RAD GetById(int id)
        {
            return _context.RAD.Find(id);
        }

        public RAD Add(RAD rAD)
        {
            var newRAD = _context.RAD.Add(rAD);

            if (newRAD != null && newRAD.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newRAD.Entity;
                }
            }

            return null;
        }

        public RAD Update(RAD rAD)
        {
            var newRAD = _context.RAD.Update(rAD);

            if (newRAD != null && newRAD.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newRAD.Entity;
                }
            }

            return null;
        }

        public RAD Delete(int id)
        {
            var rAD = _context.RAD.Find(id);

            if (rAD != null)
            {
                var deletedRAD = _context.RAD.Remove(rAD);

                if (deletedRAD != null && deletedRAD.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedRAD.Entity;
                    }
                }
            }

            return null;
        }
    }
}
