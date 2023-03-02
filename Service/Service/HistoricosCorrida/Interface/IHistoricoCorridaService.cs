using Service.HistoricosCorrida.DTOs;
using Service.HistoricosCorrida.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.HistoricosCorrida.Interface
{
    public interface IHistoricoCorridaService
    {
        Task<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>> CreateHistoricoCorrida(CreateHistoricoCorridaDTO dto);
        Task<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>> UpdateHistoricoCorrida(UpdateHistoricoCorridaDTO dto);
        Task<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>> GetHistoricoCorridaById(int id);
        Task<HistoricoCorridaResponse<List<ResultHistoricoCorridaDTO>>> GetAllHistoricoCorrida();
        Task<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>> Delete(int id);
    }
}
