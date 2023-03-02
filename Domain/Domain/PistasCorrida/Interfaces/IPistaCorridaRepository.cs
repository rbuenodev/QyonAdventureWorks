using Domain.PistasCorrida.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.PistasCorrida.Interfaces
{
    public interface IPistaCorridaRepository : IRepository<PistaCorrida>
    {
        Task<PistaCorrida?> Get(int id);
        Task<List<PistaCorrida>> GetAll();
        Task Delete(int id);
        Task<PistaCorrida> Save(PistaCorrida entity);
        Task<List<PistaCorrida>> UsedRacesTrack();
    }
}
