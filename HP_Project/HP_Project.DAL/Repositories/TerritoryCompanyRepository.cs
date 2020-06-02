using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public class TerritoryCompanyRepository : ITerritoryCompanyRepository
    {
        private readonly AppDbContext _context;

        public TerritoryCompanyRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<TerritoryCompany> GetAll()
        {
            return _context.TerritoryCompany;
        }

        public TerritoryCompany GetById(int id)
        {
            return _context.TerritoryCompany.Find(id);
        }

        public TerritoryCompany Add(TerritoryCompany territoryCompany)
        {
            var newTerritoryCompany = _context.TerritoryCompany.Add(territoryCompany);

            if (newTerritoryCompany != null && newTerritoryCompany.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newTerritoryCompany.Entity;
                }
            }

            return null;
        }

        public TerritoryCompany Update(TerritoryCompany territoryCompany)
        {
            var newTerritoryCompany = _context.TerritoryCompany.Update(territoryCompany);

            if (newTerritoryCompany != null && newTerritoryCompany.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newTerritoryCompany.Entity;
                }
            }

            return null;
        }

        public TerritoryCompany Delete(int id)
        {
            var territoryCompany = _context.TerritoryCompany.Find(id);

            if (territoryCompany != null)
            {
                var deletedTerritoryCompany = _context.TerritoryCompany.Remove(territoryCompany);

                if (deletedTerritoryCompany != null && deletedTerritoryCompany.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedTerritoryCompany.Entity;
                    }
                }
            }

            return null;
        }
    }
}
