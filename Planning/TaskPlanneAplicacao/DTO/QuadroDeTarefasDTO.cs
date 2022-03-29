using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanne.Dominio;

namespace TaskPlanne.Aplicacao
{
    public class QuadroDeTarefasDTO
    {
        public QuadroDeTarefasDTO(){}

        public QuadroDeTarefasDTO(QuadroDeTarefas quadroDeTarefas)
        {
            List<TarefaInfoDTO> tarefaInfoDTOs = new List<TarefaInfoDTO>();
            quadroDeTarefas.Tarefas.ForEach(x => tarefaInfoDTOs.Add(new TarefaInfoDTO(x)));

            this.IdQuadro = quadroDeTarefas.IdQuadro;
            this.Titulo = quadroDeTarefas.Titulo;
            this.Tarefas = tarefaInfoDTOs;
            this.TarefasAtivas = quadroDeTarefas.Tarefas.Where(x => x.IsAtivo == true).Count();
            this.TarefasConcluídas = quadroDeTarefas.Tarefas.Where(x => x.IsConcluido == true).Count();
            this.TotalTarefas = quadroDeTarefas.Tarefas.Select(x => x).Count();
        }

        public int IdQuadro { get; set; }
        public string Titulo { get; set; }
        public int TarefasAtivas { get; set; }
        public int TarefasConcluídas { get; set; }
        public int TotalTarefas { get; set; }
        public List<TarefaInfoDTO> Tarefas { get; set; }
    }

    //public static class  QuadroConverterTo
    //{
    //    public static QuadroDeTarefasDTO ConverterParaDto(this QuadroDeTarefas quadroDeTarefas)
    //    {
    //        return new QuadroDeTarefasDTO 
    //        {
    //            IdQuadro = quadroDeTarefas.IdQuadro,
    //            Titulo = quadroDeTarefas.Titulo,
    //            Tarefas =   quadroDeTarefas.Tarefas.ForEach(x => new  x) ConverteParaDto(),
    //            TarefasAtivas = quadroDeTarefas.Tarefas.Where(x => x.IsAtivo == true).Count(),
    //            TarefasConcluídas = quadroDeTarefas.Tarefas.Where(x => x.IsConcluido == true).Count(),
    //            TotalTarefas = quadroDeTarefas.Tarefas.Select(x => x).Count(),
    //        };
    //    }
    //}
}
