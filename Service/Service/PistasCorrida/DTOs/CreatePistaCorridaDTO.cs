using Domain.PistasCorrida.Entities;

namespace Service.PistasCorrida.DTOs
{
    public class CreatePistaCorridaDTO
    {
        public string Descricao { get; set; }

        public static PistaCorrida MapToEntity(CreatePistaCorridaDTO dto)
        {
            return new PistaCorrida() { Descricao = dto.Descricao };
        }
    }
}
