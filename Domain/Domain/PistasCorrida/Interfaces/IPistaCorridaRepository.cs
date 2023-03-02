using Domain.PistasCorrida.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.PistasCorrida.Interfaces
{
    public interface IPistaCorridaRepository : IRepository
    {
        Task<PistaCorrida?> Get(int id);
        Task<PistaCorrida?> GetAggragate(int id);
        Task<List<PistaCorrida>> GetAll(Filter filters);
        Task Delete(int id);
        Task<PistaCorrida> Save(PistaCorrida registry);
    }
}
