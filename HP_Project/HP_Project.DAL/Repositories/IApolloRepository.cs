using HP_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public interface IApolloRepository
    {
        ApolloRow GetById(int id);
        IEnumerable<ApolloRow> GetAll();
        ApolloRow Add(ApolloRow apolloRow);
        ApolloRow Update(ApolloRow apolloRow);
        ApolloRow Delete(int id);
    }
}
