using Domain.HistoricosCorrida.Entities;
using System;

namespace Service.HistoricosCorrida.DTOs
{
    public class ResultHistoricoCorridaDTO
    {
        public int Id { get; set; }
        public DateTime DataCorrida { get; set; }
        public decimal TempoGasto { get; set; }
        public int IdCompetidor { get; set; }
        public int IdPistaCorrida { get; set; }

        public static ResultHistoricoCorridaDTO MapToDTO(HistoricoCorrida historicoCorrida)
        {
            return new ResultHistoricoCorridaDTO()
            {
                Id = historicoCorrida.Id,
                DataCorrida = historicoCorrida.DataCorrida,
                IdCompetidor = historicoCorrida.Competidor.Id,
                IdPistaCorrida = historicoCorrida.PistaCorrida.Id,
                TempoGasto = historicoCorrida.TempoGasto
            };
        }
    }
}
