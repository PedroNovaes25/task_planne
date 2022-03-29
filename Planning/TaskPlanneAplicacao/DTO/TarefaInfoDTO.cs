using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanne.Dominio;

namespace TaskPlanne.Aplicacao
{
    public class TarefaInfoDTO
    {
        public TarefaInfoDTO()
        {}

        public TarefaInfoDTO(Tarefa tarefa)
        {
            this.IdTarefas = tarefa.IdTarefa;
            this.Titulo = tarefa.Titulo;
        }

        public int IdTarefas { get; set; }
        public string Titulo { get; set; }

    }
}
