using HP_Project.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HP_Project.DAL.Repositories
{
    public class TouchpointRepository : ITouchpointRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TouchpointRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Touchpoint>> GetAllAsync()
        {
            var touchpoints = _context.Touchpoints;

            foreach (var touchpoint in touchpoints)
            {
                touchpoint.ApplicationUser = await _userManager.FindByIdAsync(touchpoint.ApplicationUserId);
            }


            return touchpoints;
        }

        public Touchpoint GetById(int id)
        {
            return _context.Touchpoints.Find(id);
        }

        public Touchpoint Add(Touchpoint touchpoint)
        {
            var newTouchpoint = _context.Touchpoints.Add(touchpoint);

            if (newTouchpoint != null && newTouchpoint.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newTouchpoint.Entity;
                }
            }

            return null;
        }

        public Touchpoint Update(Touchpoint touchpoint)
        {
            var newTouchpoint = _context.Touchpoints.Update(touchpoint);

            if (newTouchpoint != null && newTouchpoint.State == EntityState.Modified)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newTouchpoint.Entity;
                }
            }

            return null;
        }

        public Touchpoint Delete(int id)
        {
            var touchpoint = _context.Touchpoints.Find(id);

            if (touchpoint != null)
            {
                var deletedTouchpoint = _context.Touchpoints.Remove(touchpoint);

                if (deletedTouchpoint != null && deletedTouchpoint.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedTouchpoint.Entity;
                    }
                }
            }

            return null;
        }
    }
}
