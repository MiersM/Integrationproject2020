using HP_Project.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HP_Project.DAL.Repositories
{
    public interface IContactRepository
    {
        Contact Add(Contact contact);
        Contact Delete(int id);
        Task<IEnumerable<Contact>> GetAllAsync();
        Contact GetById(int id);
        Contact Update(Contact contact);
    }
}