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
        public IActionResult CriarQuadro([FromBody] QuadroInfoDTO quadroInfoDTO)
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

        [HttpGet]
        [Route("")]
        public IActionResult PegarQuadros()
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

        [HttpGet]
        [Route("{idQuadro}")]
        public async Task<IActionResult> PegarQuadro(int idQuadro)
        {
            try
            {
                var quadro = await _quadroDeTarefasServico.PegarQuadroPorId(idQuadro);
                if (quadro == null)
                    return NoContent();
                
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
        public IActionResult DeletarQuadro(int idQuadro)
        {
            try
            {
                //Procurar no banco onde tem um quadro com idQuadro existente
                //if (existequadro == null)
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
        public IActionResult AtualizarQuadro(int idQuadro, [FromBody] object tarefaDetalheDTO)
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
