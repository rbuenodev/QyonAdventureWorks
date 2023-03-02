using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Task<BaseEntity> Get(int id);
        Task<BaseEntity> GetAggragate(int id);
        Task<List<BaseEntity>> GetAll(Filter filters);
        Task Delete(int id);
        Task<BaseEntity> Save(BaseEntity registry);
    }
}
