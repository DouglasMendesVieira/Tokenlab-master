using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tokenlab.Application.Contratos;
using Microsoft.AspNetCore.Http;
using Tokenlab.Application.Dtos;
using System.Net.Mime;

namespace Tokenlab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotesController : ControllerBase
    {
        private readonly ILoteService _loteService;

        public LotesController(ILoteService LoteService)
        {
            _loteService = LoteService;
        }

        /// <summary>
        /// Get the list of lotes by eventId
        /// </summary>
        /// <param name="eventoId"></param>
        /// <returns></returns>
        [HttpGet("{eventoId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                if (eventoId <= 0)
                    return BadRequest();

                var lotes = await _loteService.GetLotesByEventoIdAsync(eventoId);
                if (lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar lotes. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Update an existing lote
        /// </summary>
        /// <param name="eventoId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPut("{eventoId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                if (eventoId <= 0)
                    return BadRequest();

                var lotes = await _loteService.SaveLotes(eventoId, models);
                if (lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar lotes. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Remove a lote by eventId and loteId
        /// </summary>
        /// <param name="eventoId"></param>
        /// <param name="loteId"></param>
        /// <returns></returns>
        [HttpDelete("{eventoId}/{loteId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                if ((eventoId <= 0) || (loteId <= 0))
                    return BadRequest();

                var lote = await _loteService.GetLoteByIdsAsync(eventoId, loteId);
                if (lote == null) return NotFound();

                return await _loteService.DeleteLote(lote.EventoId, lote.Id)
                       ? Ok(new { message = "Lote Deletado!" })
                       : throw new Exception("Ocorreu um problem não específico ao tentar deletar Lote.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar lotes. Erro: {ex.Message}");
            }
        }
    }
}