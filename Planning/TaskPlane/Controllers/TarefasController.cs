using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Aplicacao.Interface;

namespace TaskPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : Controller
    {
        private readonly ITarefaServico _tarefaServico;

        public TarefasController(ITarefaServico tarefaServico)
        {
            _tarefaServico = tarefaServico;
        }

        [HttpGet]
        [Route("{idTarefa}")]
        public async Task<IActionResult> PegarTarefa(int idTarefa)
        {
            try
            {
                var tarefa = await _tarefaServico.PegarTarefaPorId(idTarefa);
                if (tarefa == null)
                    return NoContent();

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult CriarTarefa([FromBody] object tarefa)
        {
            try
            {
                //código que envia ao banco

                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Remover/{idTarefa}")]
        public IActionResult DeletarTarefa(int idTarefa)
        {
            try
            {
                //Procurar no banco onde tem uma tarefa com  IdTarefa existente
                //if (existeTarefa == null)
                //    return NoContent();

                //Chamar o código de remover

                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPatch]
        [Route("{idQuadro}")]
        public IActionResult AtualizarTarefa(int idQuadro, [FromBody] object tarefaDetalheDTO)
        {
            try
            {
                //Pegar do banco onde tarefa tenha idquadro e tarefaDetalhe.id existente

                //Procurar no banco onde tem uma tarefa com idQuadro e IdTarefa existente
                //if (existeTarefa == null)
                //    return NoContent();

                //Chamar o código de atualizacao

                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }
    }
}
