using Domain.Competidores.Entities;
using Domain.HistoricosCorrida.Entities;
using Domain.PistasCorrida.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AdventureDBContext : DbContext
    {
        public AdventureDBContext(DbContextOptions<AdventureDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Competidor> Competidores { get; set; }
        public virtual DbSet<HistoricoCorrida> HistoricosCorrida { get; set; }
        public virtual DbSet<PistaCorrida> PistasCorrida { get; set; }
    }
}
