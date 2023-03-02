using Domain.Competidores.Entities;

namespace Service.Competidores.DTOs
{
    public class ResultCompetidorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public decimal TemperaturaMediaCorpo { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }


        public static ResultCompetidorDTO MapToDTO(Competidor competidor)
        {
            return new ResultCompetidorDTO()
            {
                Id = competidor.Id,
                Nome = competidor.Nome,
                Sexo = competidor.Sexo,
                Altura = competidor.Altura,
                Peso = competidor.Peso,
                TemperaturaMediaCorpo = competidor.TemperaturaMediaCorpo,
            };
        }
    }
}
