using Domain.Competidores.Interfaces;
using Service.Competidores.DTOs;
using Service.Competidores.Interface;
using Service.Competidores.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Competidores
{
    public class CompetidorService : ICompetidorService
    {
        private readonly ICompetidorRepository _competidorRepository;
        public CompetidorService(ICompetidorRepository competidorRepository)
        {
            _competidorRepository = competidorRepository;
        }

        public async Task<CompetidorResponse<ResultCompetidorDTO>> CreateCompetidor(CreateCompetidorDTO dto)
        {
            try
            {
                var competidor = CreateCompetidorDTO.MapToEntity(dto);
                competidor.IsValid();

                await _competidorRepository.Save(competidor);
                return new CompetidorResponse<ResultCompetidorDTO> { Success = true, Data = ResultCompetidorDTO.MapToDTO(competidor) };
            }
            catch (Exception e)
            {
                return new CompetidorResponse<ResultCompetidorDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<CompetidorResponse<ResultCompetidorDTO>> Delete(int id)
        {
            try
            {
                await _competidorRepository.Delete(id);

                return new CompetidorResponse<ResultCompetidorDTO>
                {
                    Success = true,
                    HasErrors = false
                };
            }
            catch (Exception e)
            {
                return new CompetidorResponse<ResultCompetidorDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<CompetidorResponse<List<ResultCompetidorDTO>>> GetAllCompetidores()
        {
            try
            {
                var list = await _competidorRepository.GetAll();
                if (list == null)
                    return new CompetidorResponse<List<ResultCompetidorDTO>> { Success = true, Data = new List<ResultCompetidorDTO>() };

                var result = list.Select(x => ResultCompetidorDTO.MapToDTO(x)).ToList();
                return new CompetidorResponse<List<ResultCompetidorDTO>> { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new CompetidorResponse<List<ResultCompetidorDTO>>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<CompetidorResponse<ResultCompetidorDTO>> GetCompetidorById(int id)
        {
            try
            {
                var competidor = await _competidorRepository.Get(id);
                if (competidor != null)
                    return new CompetidorResponse<ResultCompetidorDTO> { Success = true, Data = ResultCompetidorDTO.MapToDTO(competidor) };

                return new CompetidorResponse<ResultCompetidorDTO> { Success = false, Message = "Competidor não encontrado" };
            }
            catch (Exception e)
            {
                return new CompetidorResponse<ResultCompetidorDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<CompetidorResponse<List<ResultCompetidorTempoMedioDTO>>> GetCompetidorsWithAvarageTime()
        {
            try
            {
                var list = await _competidorRepository.GetCompetidorsWithAvarageTime();
                if (list == null)
                    return new CompetidorResponse<List<ResultCompetidorTempoMedioDTO>> { Success = true, Data = new List<ResultCompetidorTempoMedioDTO>() };

                var result = list.Select(x => ResultCompetidorTempoMedioDTO.MapToDTO(x)).ToList();
                return new CompetidorResponse<List<ResultCompetidorTempoMedioDTO>> { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new CompetidorResponse<List<ResultCompetidorTempoMedioDTO>>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<CompetidorResponse<List<ResultCompetidorDTO>>> GetCompetidorsWithoutRaces()
        {
            try
            {
                var list = await _competidorRepository.GetCompetidorsWithoutRaces();
                if (list == null)
                    return new CompetidorResponse<List<ResultCompetidorDTO>> { Success = true, Data = new List<ResultCompetidorDTO>() };

                var result = list.Select(x => ResultCompetidorDTO.MapToDTO(x)).ToList();
                return new CompetidorResponse<List<ResultCompetidorDTO>> { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new CompetidorResponse<List<ResultCompetidorDTO>>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<CompetidorResponse<ResultCompetidorDTO>> UpdateCompetidor(UpdateCompetidorDTO dto)
        {
            try
            {
                var competidor = UpdateCompetidorDTO.MapToEntity(dto);
                competidor.IsValid();

                await _competidorRepository.Save(competidor);
                return new CompetidorResponse<ResultCompetidorDTO> { Success = true, Data = ResultCompetidorDTO.MapToDTO(competidor) };
            }
            catch (Exception e)
            {

                return new CompetidorResponse<ResultCompetidorDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }
    }
}
