using Domain.Competidores.Entities;
using Domain.Competidores.Interfaces;
using Domain.Competidores.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Competidores
{
    public class CompetidorRepository : ICompetidorRepository
    {
        private readonly AdventureDBContext _dbContext;
        public CompetidorRepository(AdventureDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CompetidorTempoMedio>> GetCompetidorsWithAvarageTime()
        {
            var list = await (from c in _dbContext.Competidores.AsNoTracking()
                        join h in _dbContext.HistoricosCorrida.AsNoTracking() on c.Id equals h.Competidor.Id into g
                        select new CompetidorTempoMedio
                        {
                            Altura = c.Altura,
                            Id = c.Id,
                            Nome = c.Nome,
                            Peso = c.Peso,
                            Sexo = c.Sexo,
                            TemperaturaMediaCorpo = g.Average(x => x.TempoGasto)
                        }).ToListAsync();

            return list;
        }

        public async Task Delete(int id)
        {
            var entity = _dbContext.Competidores.Where(r => r.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Competidor não encontrado");
            }
        }

        public async Task<Competidor> Get(int id)
        {
            return await _dbContext.Competidores.AsNoTracking().Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Competidor>> GetAll()
        {
            return await _dbContext.Competidores.AsNoTracking().ToListAsync();
        }

        public async Task<Competidor> Save(Competidor entity)
        {
            var existingEntity = _dbContext.Competidores.FirstOrDefault(r => r.Id == entity.Id);
            if (existingEntity != null)
            {
                return await Update(entity, existingEntity);
            }
            else
            {
                return await Insert(entity);
            }
        }

        private async Task<Competidor> Insert(Competidor entity)
        {
            _dbContext.Competidores.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        private async Task<Competidor> Update(Competidor entity, Competidor update)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(update);
            await _dbContext.SaveChangesAsync();
            return update;
        }

        public async Task<List<Competidor>> GetCompetidorsWithoutRaces()
        {
            var list = await (from c in _dbContext.Competidores.AsNoTracking() where !_dbContext.HistoricosCorrida.AsNoTracking().Any(x => x.Competidor.Id == c.Id) select c).ToListAsync();
            return list;
        }
    }
}
