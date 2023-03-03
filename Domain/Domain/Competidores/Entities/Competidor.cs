using System;

namespace Domain.Competidores.Entities
{
    public class Competidor : BaseEntity
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public decimal TemperaturaMediaCorpo { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }


        private bool ValidateGenres(string genres)
        {
            switch (genres)
            {
                case "M": return true;
                case "F": return true;
                case "O": return true;
                default:
                    return false;
            }
        }
        private bool Validate()
        {
            var errors = "";
            if (TemperaturaMediaCorpo < 36 || TemperaturaMediaCorpo > 38)
                errors = "Verifique a temperatura; ";

            if (Peso <= 0)
                errors += "Peso deve ser maior que zero; ";

            if (Altura <= 0)
                errors += "Altura deve ser maior que zero; ";

            if (string.IsNullOrEmpty(Sexo))
                errors += "Sexo não pode ser vazio ;";
            else if (!ValidateGenres(Sexo))
                errors += "Sexo deve ser igual a M, F ou O";

            if (string.IsNullOrEmpty(Nome))
                errors += "Nome não pode ser vazio";

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
