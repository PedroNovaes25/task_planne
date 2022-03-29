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
    public class QuadrosController : Controller
    {
        private readonly IQuadroDeTarefasServico _quadroDeTarefasServico;

        public QuadrosController(IQuadroDeTarefasServico quadroDeTarefasServico)
        {
            _quadroDeTarefasServico = quadroDeTarefasServico;
        }

        [HttpPost]
        public IActionResult CriarTarefa([FromBody] QuadroInfoDTO quadroInfo)
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

        [HttpGet]
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
        public IActionResult PegarQuadro(int idQuadro)
        {
            try
            {
                //var quadroDeTarefas = ListarQuadro(idQuadro);

                //if (quadroDeTarefas == null)
                    return NoContent();

                //return Ok(quadroDeTarefas.ConverterParaDto());
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
        [Route("Quadro/{idQuadro}")]
        public IActionResult AtualizarQuadro(int idQuadro, [FromBody] QuadroInfoDTO QuadroInfoDTO)
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
