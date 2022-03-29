using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanne.Dominio;

namespace TaskPlanne.Aplicacao
{
    public class PlanilhaMenuDTO 
    {
        public PlanilhaMenuDTO(){}
        public PlanilhaMenuDTO(QuadroDeTarefas quadroDeTarefas)
        {
            this.IdQuadro = quadroDeTarefas.IdQuadro;
            this.Titulo = quadroDeTarefas.Titulo;
            this.QuantidadeTarefas = quadroDeTarefas.Tarefas.Count();
        }

        public int IdQuadro { get; set; }
        public string Titulo { get; set; }
        public int QuantidadeTarefas { get; set; }
    }
}
