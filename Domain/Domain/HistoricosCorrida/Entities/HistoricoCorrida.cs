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


        private bool Validate()
        {
            var errors = "";
            if (DataCorrida == null)
                errors = "Data não pode ser vazio; ";

            if (DataCorrida == default(DateTime))
                errors += "Data não pode ser vazio; ";

            if (DataCorrida > DateTime.Now)
                errors += "A data não pode ser maior que a data atual; ";

            if (TempoGasto <= 0)
                errors += "Tempo gasto deve ser maior que zero; ";

            if (Competidor == null)
                errors += "Competidor não pode ser vazio; ";

            if (PistaCorrida == null)
                errors += "Pista não pode ser vazio;";

            if (!string.IsNullOrEmpty(errors))
                throw new Exception(errors);

            return true;
        }


        public bool IsValid()
        {
            return Validate();
        }
    }
}
