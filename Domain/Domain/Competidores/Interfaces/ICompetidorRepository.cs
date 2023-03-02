
using Domain.Competidores.Entities;
using Domain.Competidores.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Competidores.Interfaces
{
    public interface ICompetidorRepository : IRepository<Competidor>
    {
        Task<Competidor?> Get(int id);
        Task<List<Competidor>> GetAll();
        Task Delete(int id);
        Task<Competidor> Save(Competidor registry);
        Task<List<CompetidorTempoMedio>> GetCompetidorsWithAvarageTime();
        Task<List<Competidor>> GetCompetidorsWithoutRaces();
    }
}
