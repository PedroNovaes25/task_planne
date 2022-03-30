using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Aplicacao;
using TaskPlanner.Aplicacao.Interface;

namespace TaskPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuadrosController : Controller
    {
        private readonly IQuadroDeTarefasServico _quadroDeTarefasServico;

        public QuadrosController(IQuadroDeTarefasServico quadroDeTarefasServico)
        {
            _quadroDeTarefasServico = quadroDeTarefasServico;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CriarQuadro([FromBody] QuadroInfoDTO quadroInfoDTO)
        {
            try
            {
                var quadro = await _quadroDeTarefasServico.CriarQuadro(quadroInfoDTO);
                if (quadro == null) return NoContent();

                return Ok(quadro);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> PegarQuadros()
        {
            try
            {
                var quadros = await _quadroDeTarefasServico.PegarQuadros();
                if (quadros == null) return NoContent();

                return  Ok(quadros);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{idQuadro}")]
        public async Task<IActionResult> PegarQuadro(int idQuadro)
        {
            try
            {
                var quadro = await _quadroDeTarefasServico.PegarQuadroPorId(idQuadro);
                if (quadro == null)
                    return NotFound();

                return Ok(quadro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Remover/{idQuadro}")]
        public async Task<IActionResult> DeletarQuadro(int idQuadro)
        {
            try
            {
                var quadro = await _quadroDeTarefasServico.PegarQuadroPorId(idQuadro);
                if (quadro == null) return NoContent();
                if (await _quadroDeTarefasServico.DeletarQuadro(quadro.IdQuadro))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar deletar Tarefa.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPatch]
        [Route("{idQuadro}")]
        public async Task<IActionResult> AtualizarQuadro(int idQuadro, [FromBody] QuadroInfoDTO tarefaDetalheDTO)
        {
            try
            {
                var quadro = await _quadroDeTarefasServico.AtualizarQuadro(idQuadro, tarefaDetalheDTO);
                if (quadro == null) return NoContent();

                return Ok(quadro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }
    }
}
