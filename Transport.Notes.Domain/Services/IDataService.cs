using System.Collections;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable> GetAll();
        Task<Account> Get(int id);
        Task<Account> Create(T entity);
        Task<Account> Update(T entity, int id);
        Task<bool> Delete(int id);
    }
}
