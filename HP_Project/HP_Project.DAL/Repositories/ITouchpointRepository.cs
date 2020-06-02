using HP_Project.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HP_Project.DAL.Repositories
{
    public interface ITouchpointRepository
    {
        Touchpoint Add(Touchpoint touchpoint);
        Touchpoint Delete(int id);
        Task<IEnumerable<Touchpoint>> GetAllAsync();
        Touchpoint GetById(int id);
        Touchpoint Update(Touchpoint touchpoint);
    }
}