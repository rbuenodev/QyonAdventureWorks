using Domain.Competidores.Entities;
using Service.Competidores.DTOs;
using Service.Competidores.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Competidores.Interface
{
    public interface ICompetidorService
    {
        Task<CompetidorResponse<ResultCompetidorDTO>> CreateCompetidor(CreateCompetidorDTO dto);
        Task<CompetidorResponse<ResultCompetidorDTO>> UpdateCompetidor(UpdateCompetidorDTO dto);
        Task<CompetidorResponse<ResultCompetidorDTO>> GetCompetidorById(int id);
        Task<CompetidorResponse<List<ResultCompetidorDTO>>> GetAllCompetidores();
        Task<CompetidorResponse<ResultCompetidorDTO>> Delete(int id);
        Task<CompetidorResponse<List<ResultCompetidorTempoMedioDTO>>> GetCompetidorsWithAvarageTime();
        Task<CompetidorResponse<List<ResultCompetidorDTO>>> GetCompetidorsWithoutRaces();
    }
}
