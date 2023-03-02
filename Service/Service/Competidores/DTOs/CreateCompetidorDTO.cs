using Domain.Competidores.Entities;

namespace Service.Competidores.DTOs
{
    public class CreateCompetidorDTO
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public decimal TemperaturaMediaCorpo { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }


        public static Competidor MapToEntity(CreateCompetidorDTO dto)
        {
            return new Competidor()
            {
                Nome = dto.Nome,
                Sexo = dto.Sexo,
                Altura = dto.Altura,
                Peso = dto.Peso,
                TemperaturaMediaCorpo = dto.TemperaturaMediaCorpo,
            };
        }
    }
}
