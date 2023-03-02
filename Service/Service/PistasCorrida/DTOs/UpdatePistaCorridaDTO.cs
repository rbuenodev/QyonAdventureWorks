using Domain.PistasCorrida.Entities;

namespace Service.PistasCorrida.DTOs
{
    public class UpdatePistaCorridaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public static PistaCorrida MapToEntity(UpdatePistaCorridaDTO dto)
        {
            return new PistaCorrida() { Id = dto.Id, Descricao = dto.Descricao };
        }
    }
}
