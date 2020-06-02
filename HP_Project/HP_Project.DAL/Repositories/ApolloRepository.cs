using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public class ApolloRepository : IApolloRepository
    {
        private readonly AppDbContext _context;

        public ApolloRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public IEnumerable<ApolloRow> GetAll()
        {
            return _context.Apollo;
        }

        public ApolloRow GetById(int id)
        {
            return _context.Apollo.Find(id);
        }

        public ApolloRow Add(ApolloRow apolloRow)
        {
            var newApolloRow = _context.Apollo.Add(apolloRow);

            if (newApolloRow != null && newApolloRow.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newApolloRow.Entity;
                }
            }

            return null;
        }

        public ApolloRow Update(ApolloRow apolloRow)
        {
            var newApolloRow = _context.Apollo.Update(apolloRow);

            if (newApolloRow != null && newApolloRow.State == EntityState.Modified)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newApolloRow.Entity;
                }
            }

            return null;
        }

        public ApolloRow Delete(int id)
        {
            var apolloRow = _context.Apollo.Find(id);

            if (apolloRow != null)
            {
                var deletedApolloRow = _context.Apollo.Remove(apolloRow);

                if (deletedApolloRow != null && deletedApolloRow.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedApolloRow.Entity;
                    }
                }
            }

            return null;
        }
    }
}
