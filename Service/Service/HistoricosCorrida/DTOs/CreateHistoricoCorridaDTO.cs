using Domain.HistoricosCorrida.Entities;
using Domain.Competidores.Entities;
using Domain.PistasCorrida.Entities;
using System;

namespace Service.HistoricosCorrida.DTOs
{
    public class CreateHistoricoCorridaDTO
    {
        public DateTime DataCorrida { get; set; }
        public decimal TempoGasto { get; set; }
        public int IdCompetidor { get; set; }
        public int IdPistaCorrida { get; set; }

        public static HistoricoCorrida MapToEntity(CreateHistoricoCorridaDTO dto)
        {
            return new HistoricoCorrida()
            {
                DataCorrida = dto.DataCorrida,
                TempoGasto = dto.TempoGasto,
                Competidor = new Competidor() { Id = dto.IdCompetidor },
                PistaCorrida = new PistaCorrida() { Id = dto.IdPistaCorrida },
            };
        }
    }
}

