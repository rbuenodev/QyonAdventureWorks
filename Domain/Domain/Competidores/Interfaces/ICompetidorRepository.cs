
using Domain.Competidores.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Competidores.Interfaces
{
    public interface ICompetidorRepository : IRepository
    {
        Task<Competidor?> Get(int id);
        Task<Competidor?> GetAggragate(int id);
        Task<List<Competidor>> GetAll(Filter filters);
        Task Delete(int id);
        Task<Competidor> Save(Competidor registry);
    }
}
