using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public class WorkdayRepository : IWorkdayRepository
    {
        private readonly AppDbContext _context;

        public WorkdayRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Workday> GetAll()
        {
            return _context.Workday;
        }

        public Workday GetById(int id)
        {
            return _context.Workday.Find(id);
        }

        public Workday Add(Workday workday)
        {
            var newWorkday = _context.Workday.Add(workday);

            if (newWorkday != null && newWorkday.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newWorkday.Entity;
                }
            }

            return null;
        }

        public Workday Update(Workday workday)
        {
            var newWorkday = _context.Workday.Update(workday);

            if (newWorkday != null && newWorkday.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newWorkday.Entity;
                }
            }

            return null;
        }

        public Workday Delete(int id)
        {
            var workday = _context.Workday.Find(id);

            if (workday != null)
            {
                var deletedWorkday = _context.Workday.Remove(workday);

                if (deletedWorkday != null && deletedWorkday.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedWorkday.Entity;
                    }
                }
            }

            return null;
        }
    }
}
