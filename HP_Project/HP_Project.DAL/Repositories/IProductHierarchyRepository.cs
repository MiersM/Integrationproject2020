using HP_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public interface IProductHierarchyRepository
    {
        ProductHierarchy GetById(int id);
        ProductHierarchy GetByRevenueActualsId(int id);
        IEnumerable<ProductHierarchy> GetAll();
        ProductHierarchy Add(ProductHierarchy apolloRow);
        ProductHierarchy Update(ProductHierarchy apolloRow);
        ProductHierarchy Delete(int id);
    }
}
