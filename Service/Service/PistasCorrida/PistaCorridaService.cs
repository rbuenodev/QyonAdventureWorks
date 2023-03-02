using Domain.PistasCorrida.Interfaces;
using Service.PistasCorrida.DTOs;
using Service.PistasCorrida.Interface;
using Service.PistasCorrida.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.PistasCorrida
{
    public class PistaCorridaService : IPistaCorridaService
    {
        private readonly IPistaCorridaRepository _pistaCorridaRepository;
        public PistaCorridaService(IPistaCorridaRepository pistaCorridaRepository)
        {
            _pistaCorridaRepository = pistaCorridaRepository;
        }
        public async Task<PistaCorridaResponse<ResultPistaCorridaDTO>> CreatePistaCorrida(CreatePistaCorridaDTO dto)
        {
            try
            {
                var pistaCorrida = CreatePistaCorridaDTO.MapToEntity(dto);

                await _pistaCorridaRepository.Save(pistaCorrida);
                return new PistaCorridaResponse<ResultPistaCorridaDTO> { Success = true, Data = ResultPistaCorridaDTO.MapToDTO(pistaCorrida) };
            }
            catch (Exception e)
            {
                return new PistaCorridaResponse<ResultPistaCorridaDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<PistaCorridaResponse<ResultPistaCorridaDTO>> Delete(int id)
        {
            try
            {
                await _pistaCorridaRepository.Delete(id);

                return new PistaCorridaResponse<ResultPistaCorridaDTO>
                {
                    Success = true,
                    HasErrors = false
                };
            }
            catch (Exception e)
            {
                return new PistaCorridaResponse<ResultPistaCorridaDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<PistaCorridaResponse<List<ResultPistaCorridaDTO>>> GetAllPistaCorrida()
        {
            try
            {
                var list = await _pistaCorridaRepository.GetAll();
                if (list == null)
                    return new PistaCorridaResponse<List<ResultPistaCorridaDTO>> { Success = true, Data = new List<ResultPistaCorridaDTO>() };

                var result = list.Select(x => ResultPistaCorridaDTO.MapToDTO(x)).ToList();
                return new PistaCorridaResponse<List<ResultPistaCorridaDTO>> { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new PistaCorridaResponse<List<ResultPistaCorridaDTO>>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<PistaCorridaResponse<List<ResultPistaCorridaDTO>>> GetAllUsedRacesTrack()
        {
            try
            {
                var list = await _pistaCorridaRepository.UsedRacesTrack();
                if (list == null)
                    return new PistaCorridaResponse<List<ResultPistaCorridaDTO>> { Success = true, Data = new List<ResultPistaCorridaDTO>() };

                var result = list.Select(x => ResultPistaCorridaDTO.MapToDTO(x)).ToList();
                return new PistaCorridaResponse<List<ResultPistaCorridaDTO>> { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new PistaCorridaResponse<List<ResultPistaCorridaDTO>>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<PistaCorridaResponse<ResultPistaCorridaDTO>> GetPistaCorridaById(int id)
        {
            try
            {
                var pistaCorrida = await _pistaCorridaRepository.Get(id);
                if (pistaCorrida != null)
                    return new PistaCorridaResponse<ResultPistaCorridaDTO> { Success = true, Data = ResultPistaCorridaDTO.MapToDTO(pistaCorrida) };

                return new PistaCorridaResponse<ResultPistaCorridaDTO> { Success = false, Message = "Pista de corrida não encontrada" };
            }
            catch (Exception e)
            {
                return new PistaCorridaResponse<ResultPistaCorridaDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }

        public async Task<PistaCorridaResponse<ResultPistaCorridaDTO>> UpdatePistaCorrida(UpdatePistaCorridaDTO dto)
        {
            try
            {
                var pistaCorrida = UpdatePistaCorridaDTO.MapToEntity(dto);

                await _pistaCorridaRepository.Save(pistaCorrida);
                return new PistaCorridaResponse<ResultPistaCorridaDTO> { Success = true, Data = ResultPistaCorridaDTO.MapToDTO(pistaCorrida) };
            }
            catch (Exception e)
            {
                return new PistaCorridaResponse<ResultPistaCorridaDTO>
                {
                    Success = false,
                    HasErrors = true,
                    Message = e.Message
                };
            }
        }
    }
}
