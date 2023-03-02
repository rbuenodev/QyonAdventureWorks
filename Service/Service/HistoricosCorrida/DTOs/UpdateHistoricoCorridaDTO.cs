using Domain.Competidores.Entities;
using Domain.HistoricosCorrida.Entities;
using Domain.PistasCorrida.Entities;
using System;

namespace Service.HistoricosCorrida.DTOs
{
    public class UpdateHistoricoCorridaDTO
    {
        public int Id { get; set; }
        public DateTime DataCorrida { get; set; }
        public decimal TempoGasto { get; set; }
        public int IdCompetidor { get; set; }
        public int IdPistaCorrida { get; set; }

        public static HistoricoCorrida MapToEntity(UpdateHistoricoCorridaDTO dto)
        {
            return new HistoricoCorrida()
            {
                Id = dto.Id,
                DataCorrida = dto.DataCorrida,
                TempoGasto = dto.TempoGasto,
                Competidor = new Competidor() { Id = dto.IdCompetidor },
                PistaCorrida = new PistaCorrida() { Id = dto.IdPistaCorrida },
            };
        }
    }
}
