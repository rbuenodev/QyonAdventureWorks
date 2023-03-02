using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Service.PistasCorrida.DTOs;
using Service.PistasCorrida.Interface;
using Service.PistasCorrida.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("v1/api/pistaCorrida")]
    public class PistaCorridaController : ControllerBase
    {


        private readonly ILogger<PistaCorridaController> _logger;
        private readonly IPistaCorridaService _pistaCorridaService;
        private readonly IMemoryCache _cache;

        public PistaCorridaController(ILogger<PistaCorridaController> logger, IPistaCorridaService pistaCorridaService, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
            _pistaCorridaService = pistaCorridaService;
        }

        [HttpGet()]
        public async Task<ActionResult<PistaCorridaResponse<List<ResultPistaCorridaDTO>>>> GetAllPistaCorrida()
        {
            var cacheEntry = await _cache.GetOrCreateAsync<ActionResult<PistaCorridaResponse<List<ResultPistaCorridaDTO>>>>("pistaCorridaCache", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                entry.SetPriority(CacheItemPriority.High);

                var res = await _pistaCorridaService.GetAllPistaCorrida();

                if (res.HasErrors) return StatusCode(500, res);
                if (res.Success) return Ok(res);

                _logger.LogError("response com erros desconhecidos", res);
                return StatusCode(500);
            });

            return cacheEntry;
        }

        [HttpGet("comUso")]
        public async Task<ActionResult<PistaCorridaResponse<List<ResultPistaCorridaDTO>>>> GetAllUsedRacesTrack()
        {
            var cacheEntry = await _cache.GetOrCreateAsync<ActionResult<PistaCorridaResponse<List<ResultPistaCorridaDTO>>>>("pistaCorridaComUsoCache", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                entry.SetPriority(CacheItemPriority.High);

                var res = await _pistaCorridaService.GetAllUsedRacesTrack();

                if (res.HasErrors) return StatusCode(500, res);
                if (res.Success) return Ok(res);

                _logger.LogError("response com erros desconhecidos", res);
                return StatusCode(500);
            });

            return cacheEntry;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PistaCorridaResponse<ResultPistaCorridaDTO>>> GetPistaCorridaById([FromRoute] int id)
        {
            if (id == 0) return BadRequest();

            var res = await _pistaCorridaService.GetPistaCorridaById(id);

            _cache.Remove("pistaCorridaCache");
            _cache.Remove("pistaCorridaComUsoCache");

            if (res.Message == "Pista corrida não encontrado") return NotFound(res);

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response com erros desconhecidos", res);
            return StatusCode(500);
        }

        [HttpPost()]
        public async Task<ActionResult<PistaCorridaResponse<ResultPistaCorridaDTO>>> PostPistaCorrida([FromBody] CreatePistaCorridaDTO dto)
        {
            if (dto == null) return BadRequest();

            var res = await _pistaCorridaService.CreatePistaCorrida(dto);
            _cache.Remove("pistaCorridaCache");
            _cache.Remove("pistaCorridaComUsoCache");

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response com erros desconhecidos", res);
            return StatusCode(500);
        }

        [HttpPut()]
        public async Task<ActionResult<PistaCorridaResponse<ResultPistaCorridaDTO>>> PutPistaCorrida([FromBody] UpdatePistaCorridaDTO dto)
        {
            if (dto == null) return BadRequest();

            var res = await _pistaCorridaService.UpdatePistaCorrida(dto);
            _cache.Remove("pistaCorridaCache");
            _cache.Remove("pistaCorridaComUsoCache");

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response com erros desconhecidos", res);
            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PistaCorridaResponse<ResultPistaCorridaDTO>>> DeletePistaCorridaById([FromRoute] int id)
        {
            if (id == 0) return BadRequest();

            var res = await _pistaCorridaService.Delete(id);
            _cache.Remove("pistaCorridaCache");
            _cache.Remove("pistaCorridaComUsoCache");

            if (res.Message == "Pista corrida não encontrado") return NotFound(res);

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response with unknown error", res);
            return StatusCode(500);
        }
    }
}
