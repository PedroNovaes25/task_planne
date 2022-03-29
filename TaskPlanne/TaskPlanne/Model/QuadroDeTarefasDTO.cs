using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Model
{
    public class QuadroDeTarefasDTO
    {
        public int IdQuadro { get; set; }
        public string Titulo { get; set; }
        public int TarefasAtivas { get; set; }
        public int TarefasConcluídas { get; set; }
        public int TotalTarefas { get; set; }
        public List<TarefaInfoDTO> Tarefas { get; set; }
    }

    public static class  QuadroConverterTo
    {
        public static QuadroDeTarefasDTO ConverterParaDto(this QuadroDeTarefas quadroDeTarefas)
        {
            return new QuadroDeTarefasDTO 
            {
                IdQuadro = quadroDeTarefas.IdQuadro,
                Titulo = quadroDeTarefas.Titulo,
                Tarefas = quadroDeTarefas.Tarefas.ConverteParaDto(),
                TarefasAtivas = quadroDeTarefas.Tarefas.Where(x => x.IsAtivo == true).Count(),
                TarefasConcluídas = quadroDeTarefas.Tarefas.Where(x => x.IsConcluido == true).Count(),
                TotalTarefas = quadroDeTarefas.Tarefas.Select(x => x).Count(),
            };
        }
    }
}
