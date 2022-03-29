using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Dominio;

namespace TaskPlanne.Aplicacao
{
    public class TarefaDTO
    {
        public TarefaDTO() { }

        public TarefaDTO(Tarefa tarefa)
        {
            this.IdTarefa = tarefa.IdTarefa;
            this.Titulo = tarefa.Titulo;
            this.DataCriacao = tarefa.DataCriacao;
            this.DataInicializacao = tarefa.DataInicializacao;
            this.IsAtivo = tarefa.IsAtivo;
            this.IsConcluido = tarefa.IsConcluido;
            this.Descricao = tarefa.Descricao;
            this.QuadroId = tarefa.QuadroId;
        }

        public int IdTarefa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Today;
        public DateTime DataInicializacao { get; set; }
        public bool IsAtivo { get; set; } = false;
        public bool IsConcluido { get; set; } = false;

        [Required(ErrorMessage = "Informe o identificador do quadro de tarefas no campo '{0}'")]
        public int QuadroId { get; set; }
        //public QuadroDeTarefas Quadro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"), 
            MinLength(5, ErrorMessage = "A sua tarefa deve conter no minímo 5 carácteres"),
            MaxLength(300, ErrorMessage = "A sua tarefa deve conter no máximo 300 carácteres")]
        public string Descricao { get; set; }


        public Tarefa CopiaParaModel() 
        {
            return new Tarefa
            {
                Titulo = this.Titulo,
                DataCriacao = this.DataCriacao,
                DataInicializacao = this.DataInicializacao,
                IsAtivo = this.IsAtivo,
                IsConcluido = this.IsConcluido,
                QuadroId = this.QuadroId,
                Descricao = this.Descricao,
            };
        }
    }

}
