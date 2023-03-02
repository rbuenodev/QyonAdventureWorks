using Domain.PistasCorrida.Entities;
using Domain.PistasCorrida.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.PistasCorrida
{
    public class PistaCorridaRepository : IPistaCorridaRepository
    {
        private readonly AdventureDBContext _dbContext;
        public PistaCorridaRepository(AdventureDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(int id)
        {
            var entity = _dbContext.PistasCorrida.Where(r => r.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Pista de corrida não encontrada");
            }
        }

        public async Task<PistaCorrida> Get(int id)
        {
            return await _dbContext.PistasCorrida.AsNoTracking().Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PistaCorrida>> GetAll()
        {
            return await _dbContext.PistasCorrida.AsNoTracking().ToListAsync();
        }

        public async Task<PistaCorrida> Save(PistaCorrida entity)
        {
            var existingEntity = _dbContext.PistasCorrida.FirstOrDefault(r => r.Id == entity.Id);
            if (existingEntity != null)
            {
                return await Update(entity, existingEntity);
            }
            else
            {
                return await Insert(entity);
            }
        }

        public async Task<List<PistaCorrida>> UsedRacesTrack()
        {
            var list = await (from p in _dbContext.PistasCorrida
                              join h in _dbContext.HistoricosCorrida on p.Id equals h.PistaCorrida.Id
                              select new PistaCorrida { Id = p.Id, Descricao = p.Descricao }).ToListAsync();

            return list;
        }

        private async Task<PistaCorrida> Insert(PistaCorrida entity)
        {
            _dbContext.PistasCorrida.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        private async Task<PistaCorrida> Update(PistaCorrida entity, PistaCorrida update)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(update);
            await _dbContext.SaveChangesAsync();
            return update;
        }
    }
}
