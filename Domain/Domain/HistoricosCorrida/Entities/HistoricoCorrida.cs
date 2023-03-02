using Domain._shared;
using Domain.Competidores.Entities;
using Domain.PistasCorrida.Entities;
using System;

namespace Domain.HistoricosCorrida.Entities
{
    public class HistoricoCorrida : BaseEntity
    {

        public DateTime DataCorrida { get; set; }
        public decimal TempoGasto { get; set; }
        public Competidor Competidor { get; set; }
        public PistaCorrida PistaCorrida { get; set; }
    }
}
