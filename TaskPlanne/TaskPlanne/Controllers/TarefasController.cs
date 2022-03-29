using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanne.Aplicacao;
using TaskPlanne.Aplicacao._Interfaces;

namespace TaskPlanne.Controllers
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
        public IActionResult PegarTarefa(int idTarefa)
        {
            try
            {
                    return NoContent();

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CriarTarefa([FromBody] TarefaDTO tarefa)
        {
            try
            {
                var tarefaModel = tarefa.CopiaParaModel();
                //código que envia ao banco

                return Ok(tarefaModel);
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
        public IActionResult AtualizarTarefa(int idQuadro, [FromBody] TarefaDTO tarefaDetalheDTO)
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
