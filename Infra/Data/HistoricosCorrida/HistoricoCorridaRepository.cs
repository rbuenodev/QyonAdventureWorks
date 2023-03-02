using Domain.HistoricosCorrida.Entities;
using Domain.HistoricosCorrida.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.HistoricosCorrida
{
    public class HistoricoCorridaRepository : IHistoricoCorridaRepository
    {
        private readonly AdventureDBContext _dbContext;
        public HistoricoCorridaRepository(AdventureDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(int id)
        {
            var entity = _dbContext.HistoricosCorrida.Where(r => r.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Historico de Corrida não encontrado");
            }
        }

        public async Task<HistoricoCorrida> Get(int id)
        {
            return await _dbContext.HistoricosCorrida.AsNoTracking().Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<HistoricoCorrida> GetAggragate(int id)
        {
            return await _dbContext.HistoricosCorrida.AsNoTracking().Include(p => p.PistaCorrida).Include(c => c.Competidor).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<HistoricoCorrida>> GetAll()
        {
            return await _dbContext.HistoricosCorrida.AsNoTracking().ToListAsync();
        }

        public async Task<HistoricoCorrida> Save(HistoricoCorrida entity)
        {
            var existingEntity = _dbContext.HistoricosCorrida.FirstOrDefault(r => r.Id == entity.Id);
            if (existingEntity != null)
            {
                return await Update(entity, existingEntity);
            }
            else
            {
                return await Insert(entity);
            }
        }
        private async Task<HistoricoCorrida> Insert(HistoricoCorrida entity)
        {
            _dbContext.HistoricosCorrida.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        private async Task<HistoricoCorrida> Update(HistoricoCorrida entity, HistoricoCorrida update)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(update);
            await _dbContext.SaveChangesAsync();
            return update;
        }
    }
}
