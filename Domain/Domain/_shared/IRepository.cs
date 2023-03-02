using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);        
        Task<List<T>> GetAll();
        Task Delete(int id);
        Task<T> Save(T entity);
    }
}
