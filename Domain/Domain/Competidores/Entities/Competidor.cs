namespace Domain.Competidores.Entities
{
    public class Competidor : BaseEntity
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public decimal TemperaturaMediaCorpo { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
    }
}
