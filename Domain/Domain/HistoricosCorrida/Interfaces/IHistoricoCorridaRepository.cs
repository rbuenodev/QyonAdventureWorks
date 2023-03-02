using Domain.HistoricosCorrida.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.HistoricosCorrida.Interfaces
{
    public interface IHistoricoCorridaRepository : IRepository<HistoricoCorrida>
    {
        Task<HistoricoCorrida?> Get(int id);
        Task<HistoricoCorrida?> GetAggragate(int id);
        Task<List<HistoricoCorrida>> GetAll();
        Task Delete(int id);
        Task<HistoricoCorrida> Save(HistoricoCorrida entity);
    }
}
