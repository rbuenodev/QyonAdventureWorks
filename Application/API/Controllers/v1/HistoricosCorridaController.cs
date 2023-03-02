using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Service.HistoricosCorrida.DTOs;
using Service.HistoricosCorrida.Interface;
using Service.HistoricosCorrida.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/historicoCorrida")]
    public class HistoricosCorridaController:ControllerBase
    {
        private readonly ILogger<HistoricosCorridaController> _logger;
        private readonly IHistoricoCorridaService _historicoCorridaService;
        private readonly IMemoryCache _cache;

        public HistoricosCorridaController(ILogger<HistoricosCorridaController> logger,IHistoricoCorridaService historicoCorridaService, IMemoryCache cache)
        {
            _logger = logger;   
            _cache = cache;
            _historicoCorridaService = historicoCorridaService;            
        }


        [HttpGet()]
        public async Task<ActionResult<HistoricoCorridaResponse<List<ResultHistoricoCorridaDTO>>>> GetAllHistoricoCorrida()
        {
            var cacheEntry = await _cache.GetOrCreateAsync<ActionResult<HistoricoCorridaResponse<List<ResultHistoricoCorridaDTO>>>>("historicoCorridaCache", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                entry.SetPriority(CacheItemPriority.High);

                var res = await _historicoCorridaService.GetAllHistoricoCorrida();

                if (res.HasErrors) return StatusCode(500, res);
                if (res.Success) return Ok(res);

                _logger.LogError("response com erros desconhecidos", res);
                return StatusCode(500);
            });

            return cacheEntry;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>>> GetHistoricoCorridaById([FromRoute] int id)
        {
            if (id == 0) return BadRequest();

            var res = await _historicoCorridaService.GetHistoricoCorridaById(id);

            _cache.Remove("historicoCorridaCache");
            

            if (res.Message == "Historico corrida não encontrado") return NotFound(res);

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response com erros desconhecidos", res);
            return StatusCode(500);
        }

        [HttpPost()]
        public async Task<ActionResult<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>>> PostHistoricoCorrida([FromBody] CreateHistoricoCorridaDTO dto)
        {
            if (dto == null) return BadRequest();

            var res = await _historicoCorridaService.CreateHistoricoCorrida(dto);
            _cache.Remove("historicoCorridaCache");

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response com erros desconhecidos", res);
            return StatusCode(500);
        }

        [HttpPut()]
        public async Task<ActionResult<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>>> PutHistoricoCorrida([FromBody] UpdateHistoricoCorridaDTO dto)
        {
            if (dto == null) return BadRequest();

            var res = await _historicoCorridaService.UpdateHistoricoCorrida(dto);
            _cache.Remove("historicoCorridaCache");            

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response com erros desconhecidos", res);
            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HistoricoCorridaResponse<ResultHistoricoCorridaDTO>>> DeleteHistoricoCorridaById([FromRoute] int id)
        {
            if (id == 0) return BadRequest();

            var res = await _historicoCorridaService.Delete(id);
            _cache.Remove("historicoCorridaCache");

            if (res.Message == "Historico de corrida não encontrado") return NotFound(res);

            if (res.HasErrors) return StatusCode(500, res);

            if (res.Success) return Ok(res);

            _logger.LogError("response with unknown error", res);
            return StatusCode(500);
        }

    }
}
