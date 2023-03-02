using Domain.Competidores.Interfaces;
using Domain.HistoricosCorrida.Interfaces;
using Domain.PistasCorrida.Interfaces;
using Service.HistoricosCorrida.DTOs;
using Service.HistoricosCorrida.Interface;
using Service.HistoricosCorrida.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.HistoricosCorrida
{
    public class HistoricoCorridaService : IHistoricoCorridaService
    {
        private readonly IHistoricoCorridaRepository _historicoCorridaRepository;
        private readonly ICompetidorRepository _competidorRepository;
        private readonly IPistaCorridaRepository _pistaCorridaRepository;

        public HistoricoCorridaService(IHistoricoCorridaRepository historicoCorridaRepository, ICompetidorRepository competidorRepository, IPistaCorridaRepository pistaCorridaRepository)
        {
            _historicoCorridaRepository = historicoCorridaRepository;
            _competidorRepository = competidorRepository;
            _pistaCorridaRepository = pistaCorridaRepository;
        }

        public async Task<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>> CreateHistoricoCorrida(CreateHistoricoCorridaDTO dto)
        {
            try
            {
                var historicoCorrida = CreateHistoricoCorridaDTO.MapToEntity(dto);
                var competidor = await _competidorRepository.Get(dto.IdCompetidor);

                var errors = "";
                if (competidor == null) errors += "Necessário informar competidor; ";

                var pista = await _pistaCorridaRepository.Get(dto.IdPistaCorrida);
                if (pista == null) errors += "Necessário informar pista; ";

                if (!string.IsNullOrEmpty(errors))
                {
                    return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO>
                    {
                        Success = false,
                        HasErrors = true,
                        Message = errors
                    };
                }

                historicoCorrida.Competidor = competidor;
                historicoCorrida.PistaCorrida = pista;
                historicoCorrida.IsValid();


                await _historicoCorridaRepository.Save(historicoCorrida);
                return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO> { Success = true, Data = ResultHistoricoCorridaDTO.MapToDTO(historicoCorrida) };
            }
            catch (Exception e)
            {
                return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>> Delete(int id)
        {
            try
            {
                await _historicoCorridaRepository.Delete(id);

                return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO>
                {
                    Success = true,
                    HasErrors = false
                };
            }
            catch (Exception e)
            {
                return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<HistoricoCorridaResponse<List<ResultHistoricoCorridaDTO>>> GetAllHistoricoCorrida()
        {
            try
            {
                var list = await _historicoCorridaRepository.GetAll();
                if (list == null)
                    return new HistoricoCorridaResponse<List<ResultHistoricoCorridaDTO>> { Success = true, Data = new List<ResultHistoricoCorridaDTO>() };

                var result = list.Select(x => ResultHistoricoCorridaDTO.MapToDTO(x)).ToList();
                return new HistoricoCorridaResponse<List<ResultHistoricoCorridaDTO>> { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new HistoricoCorridaResponse<List<ResultHistoricoCorridaDTO>>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>> GetHistoricoCorridaById(int id)
        {
            try
            {
                var historicoCorrida = await _historicoCorridaRepository.GetAggragate(id);
                if (historicoCorrida != null)
                    return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO> { Success = true, Data = ResultHistoricoCorridaDTO.MapToDTO(historicoCorrida) };

                return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO> { Success = false, Message = "Historico de corrida não encontrado" };
            }
            catch (Exception e)
            {
                return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>> UpdateHistoricoCorrida(UpdateHistoricoCorridaDTO dto)
        {
            try
            {                
                var historicoCorrida = UpdateHistoricoCorridaDTO.MapToEntity(dto);
                var competidor = await _competidorRepository.Get(dto.IdCompetidor);

                var errors = "";
                if (competidor == null) errors += "Necessário informar competidor; ";

                var pista = await _pistaCorridaRepository.Get(dto.IdPistaCorrida);
                if (pista == null) errors += "Necessário informar pista; ";

                if (!string.IsNullOrEmpty(errors))
                {
                    return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO>
                    {
                        Success = false,
                        HasErrors = true,
                        Message = errors
                    };
                }

                historicoCorrida.Competidor = competidor;
                historicoCorrida.PistaCorrida = pista;
                historicoCorrida.IsValid();


                await _historicoCorridaRepository.Save(historicoCorrida);
                return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO> { Success = true, Data = ResultHistoricoCorridaDTO.MapToDTO(historicoCorrida) };
            }
            catch (Exception e)
            {
                return new HistoricoCorridaResponse<ResultHistoricoCorridaDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }
    }
}
