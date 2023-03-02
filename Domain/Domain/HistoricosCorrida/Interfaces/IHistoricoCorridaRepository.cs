using Domain.HistoricosCorrida.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.HistoricosCorrida.Interfaces
{
    public interface IHistoricoCorridaRepository : IRepository
    {
        Task<HistoricoCorrida?> Get(int id);
        Task<HistoricoCorrida?> GetAggragate(int id);
        Task<List<HistoricoCorrida>> GetAll(Filter filters);
        Task Delete(int id);
        Task<HistoricoCorrida> Save(HistoricoCorrida registry);
    }
}
