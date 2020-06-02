using HP_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public interface IClientEmployeeRepository
    {
        ClientEmployee GetById(int id);
        ClientEmployee GetByApolloId(int id);
        IEnumerable<ClientEmployee> GetAll();
        ClientEmployee Add(ClientEmployee apolloRow);
        ClientEmployee Update(ClientEmployee apolloRow);
        ClientEmployee Delete(int id);
    }
}
