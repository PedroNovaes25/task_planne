using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Model
{
    public class QuadroDeTarefas
    {
        public int IdQuadro { get; set; }
        public string Titulo { get; set; }
        public List<Tarefa> Tarefas { get; set; }

    }
}
