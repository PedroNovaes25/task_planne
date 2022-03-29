using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Model;

namespace TaskPlanne.Model
{
    public class PlanilhaDTO 
    {
        public PlanilhaDTO(){}
        public PlanilhaDTO(QuadroDeTarefas quadroDeTarefas)
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
