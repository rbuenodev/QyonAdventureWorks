using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Service.Competidores.DTOs;
using Service.Competidores.Interface;
using Service.Competidores.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/competidores")]
    public class CompetidoresController : ControllerBase
    {
        private readonly ILogger<CompetidoresController> _logger;
        private readonly ICompetidorService _competidorService;
        private readonly IMemoryCache _cache;

        public CompetidoresController(ILogger<CompetidoresController> logger, ICompetidorService competidorService, IMemoryCache cache)
        {
            _logger = logger;
            _competidorService = competidorService;
            _cache = cache;
        }

        [HttpGet()]
        public async Task<ActionResult<CompetidorResponse<List<ResultCompetidorDTO>>>> GetAllCompetidores()
        {
            var cacheEntry = await _cache.GetOrCreateAsync<ActionResult<CompetidorResponse<List<ResultCompetidorDTO>>>>("competidorCache", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                entry.SetPriority(CacheItemPriority.High);

                var res = await _competidorService.GetAllCompetidores();

                if (res.HasErrors) return StatusCode(500, res);
                if (res.Success) return Ok(res);

                _logger.LogError("response com erros desconhecidos", res);
                return StatusCode(500);
            });

            return cacheEntry;
        }

        [HttpGet("tempoMedio")]
        public async Task<ActionResult<CompetidorResponse<List<ResultCompetidorTempoMedioDTO>>>> GetCompetidorsWithAvarageTime()
        {
            var cacheEntry = await _cache.GetOrCreateAsync<ActionResult<CompetidorResponse<List<ResultCompetidorTempoMedioDTO>>>>("competidorTempoMedioCache", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                entry.SetPriority(CacheItemPriority.High);

                var res = await _competidorService.GetCompetidorsWithAvarageTime();

                if (res.HasErrors) return StatusCode(500, res);
                if (res.Success) return Ok(res);

                _logger.LogError("response com erros desconhecidos", res);
                return StatusCode(500);
            });

            return cacheEntry;
        }

        [HttpGet("semCorrida")]
        public async Task<ActionResult<CompetidorResponse<List<ResultCompetidorDTO>>>> GetCompetidorsWithoutRaces()
        {
            var cacheEntry = await _cache.GetOrCreateAsync<ActionResult<CompetidorResponse<List<ResultCompetidorDTO>>>>("competidorSemCorridaCache", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                entry.SetPriority(CacheItemPriority.High);

                var res = await _competidorService.GetCompetidorsWithoutRaces();

                if (res.HasErrors) return StatusCode(500, res);
                if (res.Success) return Ok(res);

                _logger.LogError("response com erros desconhecidos", res);
                return StatusCode(500);
            });

            return cacheEntry;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CompetidorResponse<ResultCompetidorDTO>>> GetCompetidorById([FromRoute] int id)
        {
            if (id == 0) return BadRequest();

            var res = await _competidorService.GetCompetidorById(id);

            _cache.Remove("competidorCache");
            _cache.Remove("competidorTempoMedioCache");
            _cache.Remove("competidorSemCorridaCache");            

            if (res.Message == "Competidor não encontrado") return NotFound(res);

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response com erros desconhecidos", res);
            return StatusCode(500);
        }

        [HttpPost()]
        public async Task<ActionResult<CompetidorResponse<ResultCompetidorDTO>>> PostCompetidor([FromBody] CreateCompetidorDTO dto)
        {
            if (dto == null) return BadRequest();

            var res = await _competidorService.CreateCompetidor(dto);
            _cache.Remove("competidorCache");
            _cache.Remove("competidorTempoMedioCache");
            _cache.Remove("competidorSemCorridaCache");

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response com erros desconhecidos", res);
            return StatusCode(500);
        }

        [HttpPut()]
        public async Task<ActionResult<CompetidorResponse<ResultCompetidorDTO>>> PutCompetidor([FromBody] UpdateCompetidorDTO dto)
        {
            if (dto == null) return BadRequest();

            var res = await _competidorService.UpdateCompetidor(dto);
            _cache.Remove("competidorCache");
            _cache.Remove("competidorTempoMedioCache");
            _cache.Remove("competidorSemCorridaCache");

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response com erros desconhecidos", res);
            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CompetidorResponse<ResultCompetidorDTO>>> DeleteCompetidorById([FromRoute] int id)
        {
            if (id == 0) return BadRequest();

            var res = await _competidorService.Delete(id);
            _cache.Remove("competidorCache");
            _cache.Remove("competidorTempoMedioCache");
            _cache.Remove("competidorSemCorridaCache");

            if (res.Message == "Competidor não encontrado") return NotFound(res);

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response with unknown error", res);
            return StatusCode(500);
        }
    }
}
