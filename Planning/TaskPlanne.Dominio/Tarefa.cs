using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner.Dominio
{
    public class Tarefa
    {
        [Key]
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataInicializacao { get; set; }
        public bool IsAtivo { get; set; }
        public bool IsConcluido { get; set; }
        public string Descricao { get; set; }
        public int QuadroId { get; set; }
        public virtual QuadroDeTarefas Quadro { get; set; }
    }
}
