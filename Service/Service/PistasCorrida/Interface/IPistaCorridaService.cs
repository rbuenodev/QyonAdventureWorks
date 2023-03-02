using Service.PistasCorrida.DTOs;
using Service.PistasCorrida.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.PistasCorrida.Interface
{
    public interface IPistaCorridaService
    {
        Task<PistaCorridaResponse<ResultPistaCorridaDTO>> CreatePistaCorrida(CreatePistaCorridaDTO dto);
        Task<PistaCorridaResponse<ResultPistaCorridaDTO>> UpdatePistaCorrida(UpdatePistaCorridaDTO dto);
        Task<PistaCorridaResponse<ResultPistaCorridaDTO>> GetPistaCorridaById(int id);
        Task<PistaCorridaResponse<List<ResultPistaCorridaDTO>>> GetAllPistaCorrida();
        Task<PistaCorridaResponse<List<ResultPistaCorridaDTO>>> GetAllUsedRacesTrack();
        Task<PistaCorridaResponse<ResultPistaCorridaDTO>> Delete(int id);
    }
}
