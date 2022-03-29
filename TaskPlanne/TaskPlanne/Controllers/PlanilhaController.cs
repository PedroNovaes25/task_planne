using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanne.Model;
using TaskPlanner.Model;

namespace TaskPlanne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanilhaController : Controller
    {

        [HttpGet]
        [Route("Quadros")]
        public IActionResult PegarQuadros()
        {
            try
            {
                List<QuadroDeTarefas> quadros = new List<QuadroDeTarefas>();
                for (int i = 1; i <= 3; i++)
                {
                    quadros.Add(ListarQuadro(i));
                }

                if (quadros == null || quadros.Count == 0)
                    return NoContent();


                List<PlanilhaDTO> planilhaDTO = new List<PlanilhaDTO>();

                foreach (var quadro in quadros)
                {
                    planilhaDTO.Add(new PlanilhaDTO(quadro));
                }

                return Ok(planilhaDTO);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Quadro/{idQuadro}")]
        public IActionResult PegarQuadro(int idQuadro)
        {
            try
            {
                var quadroDeTarefas = ListarQuadro(idQuadro);

                if (quadroDeTarefas == null)
                    return NoContent();

                return Ok(quadroDeTarefas.ConverterParaDto());
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Quadro/{idQuadro}")]
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
        public IActionResult AtualizarQuadro(int idQuadro, [FromBody] TarefaDetalheDTO tarefaDetalheDTO)
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


        [HttpGet]
        [Route("Tarefa/{idTarefa}")]
        public IActionResult PegarTarefa(int idTarefa)
        {
            try
            {
                var tarefa = TarefaPorId(idTarefa);
                if (tarefa == null)
                    return NoContent();

                return Ok(new TarefaDetalheDTO(tarefa));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Tarefa")]
        public IActionResult CriarTarefa([FromBody] TarefaDetalheDTO tarefa)
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
        [Route("Tarefa/{idTarefa}")]
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
        [Route("Tarefa/{idQuadro}")]
        public IActionResult AtualizarTarefa(int idQuadro, [FromBody] TarefaDetalheDTO tarefaDetalheDTO)
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




        [NonAction]
        public QuadroDeTarefas ListarQuadro(int idQuadro)
        {
            return new QuadroDeTarefas
            {
                IdQuadro = idQuadro,
                Titulo = $"Tarefas {idQuadro}° semana",
                Tarefas = ListarTarefas(idQuadro)
            };
        }

        [NonAction]
        public List<Tarefa> ListarTarefas(int idQuadro)
        {
            return new List<Tarefa>()
            {
                new Tarefa { IdTarefa = 1, QuadroId = 1, Titulo = "1° Segunda-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(1), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 2, QuadroId = 1, Titulo = "1° Terça-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(2), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 3, QuadroId = 1, Titulo = "1° Quarta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(3), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 4, QuadroId = 1, Titulo = "1° Quinta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(4), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 5, QuadroId = 1, Titulo = "1° Sexta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(5), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 6, QuadroId = 1, Titulo = "1° Sábado", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(6), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 8"},
                new Tarefa { IdTarefa = 7, QuadroId = 1, Titulo = "1° Domingo", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(7), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 9"},

                new Tarefa { IdTarefa = 8, QuadroId = 2, Titulo = "2° Segunda-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(8), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 9, QuadroId = 2, Titulo = "2° Terça-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(9), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 10, QuadroId = 2, Titulo = "2° Quarta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(10), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 11, QuadroId = 2, Titulo = "2° Quinta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(11), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 12, QuadroId = 2, Titulo = "2° Sexta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(12), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 13, QuadroId = 2, Titulo = "2° Sábado", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(13), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 8"},
                new Tarefa { IdTarefa = 14, QuadroId = 2, Titulo = "2° Domingo", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(14), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 9"},

                new Tarefa { IdTarefa = 15, QuadroId = 3, Titulo = "3° Segunda-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(15), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 16, QuadroId = 3, Titulo = "3° Terça-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(16), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 17, QuadroId = 3, Titulo = "3° Quarta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(17), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 18, QuadroId = 3, Titulo = "3° Quinta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(18), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 19, QuadroId = 3, Titulo = "3° Sexta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(19), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 20, QuadroId = 3, Titulo = "3° Sábado", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(20), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 8"},
                new Tarefa { IdTarefa = 21, QuadroId = 3, Titulo = "3° Domingo", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(21), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 9"}

            }.Where(x => x.QuadroId == idQuadro).ToList();
        }

        [NonAction]
        public Tarefa TarefaPorId(int idTarefa)
        {
            return new List<Tarefa>()
            {
                new Tarefa { IdTarefa = 1, QuadroId = 1, Titulo = "1° Segunda-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(1), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 2, QuadroId = 1, Titulo = "1° Terça-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(2), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 3, QuadroId = 1, Titulo = "1° Quarta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(3), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 4, QuadroId = 1, Titulo = "1° Quinta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(4), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 5, QuadroId = 1, Titulo = "1° Sexta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(5), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 6, QuadroId = 1, Titulo = "1° Sábado", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(6), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 8"},
                new Tarefa { IdTarefa = 7, QuadroId = 1, Titulo = "1° Domingo", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(7), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 9"},

                new Tarefa { IdTarefa = 8, QuadroId = 2, Titulo = "2° Segunda-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(8), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 9, QuadroId = 2, Titulo = "2° Terça-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(9), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 10, QuadroId = 2, Titulo = "2° Quarta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(10), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 11, QuadroId = 2, Titulo = "2° Quinta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(11), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 12, QuadroId = 2, Titulo = "2° Sexta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(12), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 13, QuadroId = 2, Titulo = "2° Sábado", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(13), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 8"},
                new Tarefa { IdTarefa = 14, QuadroId = 2, Titulo = "2° Domingo", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(14), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 9"},

                new Tarefa { IdTarefa = 15, QuadroId = 3, Titulo = "3° Segunda-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(15), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 16, QuadroId = 3, Titulo = "3° Terça-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(16), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 17, QuadroId = 3, Titulo = "3° Quarta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(17), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6"},
                new Tarefa { IdTarefa = 18, QuadroId = 3, Titulo = "3° Quinta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(18), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 19, QuadroId = 3, Titulo = "3° Sexta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(19), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7"},
                new Tarefa { IdTarefa = 20, QuadroId = 3, Titulo = "3° Sábado", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(20), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 8"},
                new Tarefa { IdTarefa = 21, QuadroId = 3, Titulo = "3° Domingo", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(21), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 9"}

            }.Where(x => x.IdTarefa == idTarefa).FirstOrDefault();
        }
    }
}
