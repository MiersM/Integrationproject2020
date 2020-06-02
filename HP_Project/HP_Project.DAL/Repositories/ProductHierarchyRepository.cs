using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public class ProductHierarchyRepository : IProductHierarchyRepository
    {
        private readonly AppDbContext _context;

        public ProductHierarchyRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<ProductHierarchy> GetAll()
        {
            return _context.ProductHierarchy;
        }

        public ProductHierarchy GetById(int id)
        {
            return _context.ProductHierarchy.Find(id);
        }

        public ProductHierarchy GetByRevenueActualsId(int id)
        {
            string apolloSTID = _context.RevenueActuals.Find(id).Ba;

            return _context.ProductHierarchy.Find(apolloSTID);
        }

        public ProductHierarchy Add(ProductHierarchy productHierarchy)
        {
            var newProductHierarchy = _context.ProductHierarchy.Add(productHierarchy);

            if (newProductHierarchy != null && newProductHierarchy.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newProductHierarchy.Entity;
                }
            }

            return null;
        }

        public ProductHierarchy Update(ProductHierarchy productHierarchy)
        {
            var newProductHierarchy = _context.ProductHierarchy.Update(productHierarchy);

            if (newProductHierarchy != null && newProductHierarchy.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newProductHierarchy.Entity;
                }
            }

            return null;
        }

        public ProductHierarchy Delete(int id)
        {
            var productHierarchy = _context.ProductHierarchy.Find(id);

            if (productHierarchy != null)
            {
                var deletedProductHierarchy = _context.ProductHierarchy.Remove(productHierarchy);

                if (deletedProductHierarchy != null && deletedProductHierarchy.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedProductHierarchy.Entity;
                    }
                }
            }

            return null;
        }
    }
}
