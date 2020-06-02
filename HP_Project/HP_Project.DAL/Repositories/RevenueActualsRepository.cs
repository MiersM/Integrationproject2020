using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public class RevenueActualsRepository : IRevenueActualsRepository
    {
        private readonly AppDbContext _context;

        public RevenueActualsRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<RevenueActuals> GetAll()
        {
            return _context.RevenueActuals;
        }

        public RevenueActuals GetById(int id)
        {
            return _context.RevenueActuals.Find(id);
        }

        public RevenueActuals Add(RevenueActuals revenueActuals)
        {
            var newRevenueActuals = _context.RevenueActuals.Add(revenueActuals);

            if (newRevenueActuals != null && newRevenueActuals.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newRevenueActuals.Entity;
                }
            }

            return null;
        }

        public RevenueActuals Update(RevenueActuals revenueActuals)
        {
            var newRevenueActuals = _context.RevenueActuals.Update(revenueActuals);

            if (newRevenueActuals != null && newRevenueActuals.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newRevenueActuals.Entity;
                }
            }

            return null;
        }

        public RevenueActuals Delete(int id)
        {
            var revenueActuals = _context.RevenueActuals.Find(id);

            if (revenueActuals != null)
            {
                var deletedRevenueActuals = _context.RevenueActuals.Remove(revenueActuals);

                if (deletedRevenueActuals != null && deletedRevenueActuals.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedRevenueActuals.Entity;
                    }
                }
            }

            return null;
        }
    }
}
