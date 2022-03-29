using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Dominio
{
    public class QuadroDeTarefas
    {
        [Key]
        public int IdQuadro { get; set; }
        public string Titulo { get; set; }
        public List<Tarefa> Tarefas { get; set; }

    }
}
