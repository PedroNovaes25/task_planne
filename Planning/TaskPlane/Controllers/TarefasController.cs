using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
                    return NotFound();

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
        public async  Task<IActionResult> CriarTarefa([FromBody] TarefaDTO tarefaDto)
        {
            try
            {
                var tarefa = await _tarefaServico.CriarTarefa(tarefaDto);
                if (tarefa == null) return NoContent();

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Remover/{idTarefa}")]
        public async Task<IActionResult> DeletarTarefa(int idTarefa)
        {
            try
            {
                var tarefa = await _tarefaServico.PegarTarefaPorId(idTarefa);
                if (tarefa == null) return NotFound();
                if (await _tarefaServico.DeletarTarefa(idTarefa))
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

        [HttpPatch] //Nao funciona, verificar o pq
        [Route("{idTarefa}")]
        public async Task<IActionResult> AtualizarTarefa(int idTarefa, [FromBody] TarefaDTO tarefaDetalheDTO)
        {
            try
            {
                var tarefa = await _tarefaServico.AtualizarTarefa(idTarefa, tarefaDetalheDTO);
                if (tarefa == null) return NoContent();

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }
    }
}
