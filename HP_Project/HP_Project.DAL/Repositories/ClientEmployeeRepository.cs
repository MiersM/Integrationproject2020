using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public class ClientEmployeeRepository : IClientEmployeeRepository
    {
        private readonly AppDbContext _context;

        public ClientEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<ClientEmployee> GetAll()
        {
            return _context.ClientEmployees;
        }

        public ClientEmployee GetById(int id)
        {
            return _context.ClientEmployees.Find(id);
        }

        public ClientEmployee GetByApolloId(int id)
        {
            int apolloSTID = _context.Apollo.Find(id).AccountSTID;

            return _context.ClientEmployees.Find(apolloSTID);
        }

        public ClientEmployee Add(ClientEmployee clientEmployee)
        {
            var newClientEmployee = _context.ClientEmployees.Add(clientEmployee);

            if (newClientEmployee != null && newClientEmployee.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newClientEmployee.Entity;
                }
            }

            return null;
        }

        public ClientEmployee Update(ClientEmployee clientEmployee)
        {
            var newClientEmployee = _context.ClientEmployees.Update(clientEmployee);

            if (newClientEmployee != null && newClientEmployee.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newClientEmployee.Entity;
                }
            }

            return null;
        }

        public ClientEmployee Delete(int id)
        {
            var clientEmployee = _context.ClientEmployees.Find(id);

            if (clientEmployee != null)
            {
                var deletedClientEmployee = _context.ClientEmployees.Remove(clientEmployee);

                if (deletedClientEmployee != null && deletedClientEmployee.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedClientEmployee.Entity;
                    }
                }
            }

            return null;
        }
    }
}
