using Domain.PistasCorrida.Entities;

namespace Service.PistasCorrida.DTOs
{
    public class ResultPistaCorridaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public static ResultPistaCorridaDTO MapToDTO(PistaCorrida entity)
        {
            return new ResultPistaCorridaDTO() { Id = entity.Id, Descricao = entity.Descricao };
        }
    }
}
