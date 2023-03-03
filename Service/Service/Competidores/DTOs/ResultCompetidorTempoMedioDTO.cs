using Domain.Competidores.ValueObjects;
using System;

namespace Service.Competidores.DTOs
{
    public class ResultCompetidorTempoMedioDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public decimal TemperaturaMediaCorpo { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal TempoMedio { get; set; }


        public static ResultCompetidorTempoMedioDTO MapToDTO(CompetidorTempoMedio competidor)
        {
            return new ResultCompetidorTempoMedioDTO()
            {
                Id = competidor.Id,
                Nome = competidor.Nome,
                Sexo = competidor.Sexo,
                Altura = competidor.Altura,
                Peso = competidor.Peso,
                TemperaturaMediaCorpo = competidor.TemperaturaMediaCorpo,
                TempoMedio = Math.Round(competidor.TempoMedio,2),
            };
        }
    }
}
